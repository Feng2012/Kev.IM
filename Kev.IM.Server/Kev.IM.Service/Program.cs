using Kev.IM;
using Kev.IM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM
{
    class Program
    {
        static void Main(string[] args)
        {

            UDPServerRouteHelper.GetInstanse().SetDelegate(new LoginSocketDelegate());
            UDPServerRouteHelper.GetInstanse().SetDelegate(new GetUserInfoSocketDelegate());
            UDPServerRouteHelper.GetInstanse().SetDelegate(new GetUserFriendListSocketDelegate());
            UDPServerRouteHelper.GetInstanse().SetDelegate(new ChatTextMessageSocketDelegate());

            UDPServer udpServer = new UDPServer();
            udpServer.BindIPPoint = new IPEndPoint(IPAddress.Any, 7788);

            KevRegister.Add(UDPPrimaryKey.UDPServer, udpServer);

            udpServer.Start();

            while (true)
            {
                Console.WriteLine("Command:");
                bool isContinue = true;
                switch (Console.ReadLine().ToUpper())
                {
                    case "EXIT":
                        isContinue = false;
                        break;
                    default:
                        break;
                }
                if (!isContinue)
                    break;
            }
        }
    }
}
