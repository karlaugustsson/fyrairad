using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace FyraIrad
{
    class client
    {
        static Socket sct;

        public static void ClientConnect()
        {
            sct = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint LocalEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                sct.Connect(LocalEndPoint);

            }
            catch
            {

                Console.Write("Unable to coonect to remote endpoint");
            } Console.Write("enter text: ");
            string text = Console.ReadLine();

            byte[] Data = Encoding.ASCII.GetBytes(text);
            sct.Send(Data);
            Console.WriteLine("DATA SEND \r\n"); Console.Read();
            sct.Close();
        }
    }
}
