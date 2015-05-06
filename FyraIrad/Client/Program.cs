using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Client
{
    class Client
    {
        static Socket sct;
        static void Main(string[] args)
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
                Main(args);
            }
            Console.Write("enter text: ");
            string text = Console.ReadLine();

            byte[] Data = Encoding.ASCII.GetBytes(text);
            sct.Send(Data);
            Console.WriteLine("DATA SEND \r\n");
            Console.Read();
            sct.Close();
        }
    }
}
