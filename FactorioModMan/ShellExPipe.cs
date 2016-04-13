using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;

namespace FactorioModMan
{
    internal class ShellExPipe : IDisposable
    {
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly uint _numOfThreads;
        //simple way - just using named pipes
        private readonly List<Thread> _pipeServers = new List<Thread>();

        public ShellExPipe(uint numOfThreads = 4)
        {
            _numOfThreads = numOfThreads;

            for (int i = 0; i < _numOfThreads; i++)
            {
                _pipeServers.Add(new Thread(_pipeThread));
            }
            _pipeServers.ForEach(t =>
            {
                t.IsBackground = true;
                t.Start();
            });
        }

        public void Dispose()
        {
            _cts.Cancel();
        }

        public event Action<ModInfo> OnData;

        private async void _pipeThread(object state)
        {
            while (!_cts.IsCancellationRequested)
            {
                using (
                    NamedPipeServerStream pipeServer = new NamedPipeServerStream("FactorioModManUiPipe",
                        PipeDirection.In, (int) _numOfThreads))
                {
                    pipeServer.WaitForConnection();
                    byte[] buffer = new byte[4096];
                    int bytesRead = await pipeServer.ReadAsync(buffer, 0, buffer.Length, _cts.Token);
                    if (bytesRead > 0)
                    {
                        buffer = buffer.Take(bytesRead).ToArray();
                        string incoming = Encoding.ASCII.GetString(buffer);
                        ModInfo urlObj;
                        if (ModInfo.TryParse(incoming, out urlObj))
                        {
                            _processIncoming(urlObj);
                        }
                        else
                        {
                            Console.WriteLine("Invalid data incoming");
                        }
                    }
                }
            }
        }

        private void _processIncoming(ModInfo urlHandler)
        {
            if (OnData != null) OnData(urlHandler);
            else throw new Exception("No handler for data attached");
        }
    }
}