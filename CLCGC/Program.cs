using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CLCGC
{
    class Program
    {
        static TcpClient client;
        static NetworkStream stream;
        static string private_key;
        static string filePath = Environment.SpecialFolder.DesktopDirectory + @"\CLCGC\player.dat";

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
                    stream = client.GetStream();
                    notValid = false;
                }
                catch
                {
                    Console.WriteLine("Error while connecting... Press any key to retry");
                    Console.ReadKey();
                }
            }
            private_key = Receive().Split(':')[1];            
            Console.Clear();
            Console.WriteLine("created");
            Directory.CreateDirectory(Environment.SpecialFolder.DesktopDirectory + @"\CLCGC\");
            Console.WriteLine(Environment.SpecialFolder.ApplicationData + @"\CLCGC\");
            File.WriteAllText(filePath, private_key);
            Console.WriteLine("Connection to server successful");
            Console.WriteLine(Environment.ProcessorCount + " Cores detected");
            Console.WriteLine("Trying to create " + Environment.ProcessorCount + " threads");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public static void Send(string input)
        {
            while (!stream.DataAvailable) { }
            byte[] buffer = new byte[input.Length];
            buffer = Encoding.ASCII.GetBytes(input);
            stream.Write(buffer, 0, input.Length);
        }

        public static string Receive()
        {
            while (!stream.DataAvailable) { }
            byte[] buffer = new byte[1024];
            string output = "";
            stream.Read(buffer, 0, buffer.Length);
            output = Encoding.ASCII.GetString(buffer);
            output = output.Split(null)[0];
            return output;
        }

        public static void guessMD5(string MD5, int threadNumber)
        {
            Console.WriteLine("Thread #" + threadNumber + " Initialized");
        }
    }
}
