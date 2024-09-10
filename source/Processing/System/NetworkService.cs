using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using saor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saor.Processing.System
{
    public class NetworkService : Process
    {
        public DHCPClient Client;
        public NetworkService(bool running = true) : base("net","Network Service, used for connecting to the network using Ethernet and DHCP.")
        {
            try
            {
                Client = new();
                Client.SendDiscoverPacket();
                Console.WriteLine(Events.Success(name, "Connected to network, your IP address is: " + NetworkConfiguration.CurrentAddress.ToString()));
                running = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(Events.Error(name, "Error while connecting to network: " + e.Message));
                Console.WriteLine(Events.Warning(name, "Network disabled."));
                running = false;
            }
        }
    }
}
