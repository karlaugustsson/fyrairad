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
        static byte[] Buffer { get; set; }

        public static void ClientConnect()
        {
            sct = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint LocalEndPoint = new IPEndPoint(0, 1234);
            try
            {
                sct.Connect(LocalEndPoint);

            }
            catch
            {
 
       
            }

        }

        public static void ClientRequest(){
            Console.Write("Your name please: ");
            string text = Console.ReadLine();

            byte[] Data = Encoding.ASCII.GetBytes(text);
            sct.Send(Data);


                Socket accepted = sct.Accept();

                Buffer = new byte[accepted.SendBufferSize];
                int BytesRead = accepted.Receive(Buffer);
                byte[] formated = new byte[BytesRead];
                for (int i = 0; i < BytesRead; i++)
                {
                    formated[i] = Buffer[i];
                } string strData = Encoding.ASCII.GetString(formated);

                Console.Write(strData + "\r\n");
        
        }

        
    }
}
