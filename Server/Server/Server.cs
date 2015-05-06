using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace FyraIrad
{
    class Server
    {
        static byte[] Buffer { get; set; }
        static Socket sct;

        static void Main(string[] args)
        {
            sct = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sct.Bind(new IPEndPoint(0, 1234));
            sct.Listen(100);

            Socket accepted = sct.Accept();
            Buffer = new byte[accepted.SendBufferSize];
            int BytesRead = accepted.Receive(Buffer);
            byte[] formated = new byte[BytesRead];
            for (int i = 0; i < BytesRead; i++)
            {
                formated[i] = Buffer[i];
            }
            string strData = Encoding.ASCII.GetString(formated);
            Console.Write(strData + "\r\n");
            Console.Read();
            sct.Close();
            accepted.Close();
        }
    }
}