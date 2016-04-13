using System;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace FactorioModMan_ShellExt
{
    /*error codes:
    0 - no error
    -1 - no arguments
    -2 - error while sending to ui app
    -3 - error while calling internal handler
    */
    class Program
    {
        static int Main(string[] args)
        {
            switch (args.Count())
            {
                case 0: return -1; //without arguments just return error
                case 1: return _handleInternal(args); //handle arguments for own function - eg. handler install/uninstall
                default: return _sendToPipe(args); //just push to ui app
            }
        }

        static int _sendToPipe(string[] args)
        {
            string datastring = string.Join(" ", args);
            try
            {
                byte[] buffer;
                buffer = Encoding.ASCII.GetBytes(datastring);
                using (NamedPipeClientStream pipe = new NamedPipeClientStream(".", "FactorioModManUiPipe", PipeDirection.Out, PipeOptions.WriteThrough, TokenImpersonationLevel.Impersonation))
                {
                    pipe.Connect(100);
                    pipe.Write(buffer, 0, buffer.Length);
                }
                return 0;
            }
            catch (Exception)
            {
                return -2;
            }
        }
        static int _handleInternal(string[] args)
        {
            throw new NotImplementedException();
            return 0;
            return -3;
        }
    }
}
