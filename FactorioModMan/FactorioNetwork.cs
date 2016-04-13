using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace FactorioModMan
{
    internal class FactorioNetwork
    {
        public async Task<ServerInfo> RequestModlistFromServerAsync(IPAddress host, ushort port = 34197)
        {
            Task<ServerInfo> internalTask = new Task<ServerInfo>(() => { return RequestModlistFromServer(host, port); });
            return await internalTask;
        }

        public ServerInfo RequestModlistFromServer(IPAddress host, ushort port = 34197)
        {
            ServerInfo serverInfo = new ServerInfo();
            try
            {
                IPEndPoint ep = new IPEndPoint(host, port);
                using (UdpClient c = new UdpClient(port))
                {
                    c.Connect(ep);
                    c.Send(ServerInfo.ServerRequest, ServerInfo.ServerRequest.Length);
                    byte[] rawResult = c.Receive(ref ep);
                    serverInfo.ParseNetworkPacket(rawResult); //could be if-wrapped, but not really needed here
                }
            }
            catch
            {
            }
            return serverInfo;
        }

        public bool TryResolveToIp(string hostnameOrIp, out IPAddress anyFoundIp)
        {
            anyFoundIp = null;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(hostnameOrIp);
                if (hostEntry.AddressList.Length == 1)
                {
                    //do back check
                    anyFoundIp = hostEntry.AddressList[0];
                }
                else if (hostEntry.AddressList.Length > 1)
                {
                    int randomIpIdx = new Random().Next(0, hostEntry.AddressList.Length - 1);
                    anyFoundIp = hostEntry.AddressList[randomIpIdx];
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}