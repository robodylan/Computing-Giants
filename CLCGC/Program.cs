using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLCGC
{
    class Program
    {
        static TcpClient client = new TcpClient();
        static NetworkStream stream = client.GetStream();

        public static void Main()
        {
            bool notValid = true;
            while (notValid)
            {
                Console.Clear();
                Console.WriteLine("        (                          " + "\n" +
                                  "   (    )\\ )   (    (         (    " + "\n" +
                                  "   )\\  (()/(   )\\   )\\ )      )\\   " + "\n" +
                                  " (((_)  /(_))(((_) (()/(    (((_)  " + "\n" +
                                  " )\\___ (_))  )\\___  /(_))_  )\\___  " + "\n" +
                                  "((/ __|| |  ((/ __|(_)) __|((/ __| " + "\n" +
                                  " | (__ | |__ | (__   | (_ | | (__  " + "\n" +
                                  "  \\___||____| \\___|   \\___|  \\___| " + "\n" +
                                  "                                   " + "\n" );
                Console.WriteLine("CLCGC (c) 2015 Dylan Dunn");
                try
                {
                    Console.Write("Enter a server address: ");
                    string input = Console.ReadLine();
                    client = new TcpClient(input, 74);
                    notValid = false;
                }
                catch
                {
                    Console.WriteLine("Error while connecting... Press any key to retry");
                    Console.Read();
                }
            }

            while(client.Connected)
            {

            }
        }

        public void Send(string input)
        {
            byte[] buffer = new byte[input.Length];
            buffer = Encoding.ASCII.GetBytes(input);
            stream.Write(buffer, 0, input.Length);
        }

        public string Receive()
        {
            byte[] buffer = new byte[1024];
            string output = "";
            stream.Read(buffer, 0, buffer.Length);
            output = Encoding.ASCII.GetString(buffer);
            return output;
        }
    }
}
