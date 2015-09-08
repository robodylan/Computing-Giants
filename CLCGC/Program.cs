using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;

namespace CLCGC
{
    class Program
    {
        static TcpClient client;
        static NetworkStream stream;
        static string private_key;
        static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\CLCGC\player.dat";
        static string opponent_key;
        static bool wait = true;
        static bool success = false;
        static int playerLevel;
        static int enemyLevel;

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
            if (File.Exists(filePath)) Console.WriteLine("Loading settings...");
            Thread.Sleep(10);
            Console.WriteLine("Settings loaded successfully");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\CLCGC\");
            Console.WriteLine(filePath);
            File.WriteAllText(filePath, private_key);
            Console.WriteLine("Connection to server successful");
            Console.WriteLine(Environment.ProcessorCount + " Cores detected");
            Console.WriteLine("Trying to create " + Environment.ProcessorCount + " threads");
            int i = 0;
            while(i < Environment.ProcessorCount)
            {
                Thread thread = new Thread(guessMD5);
                thread.Start(i);
                i++;
                Thread.Sleep(100); 
            }
            Thread.Sleep(100);
            attackRandomPlayer();
            while(true)
            {
                if(!success)
                {
                    Thread.Sleep(200);
                }
                else
                {
                    attackRandomPlayer();
                    success = false;
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public static void attackRandomPlayer()
        {
            bool isValid = false;
            Send("getPlayers:");
            string input = Receive();
            string[] data = input.Split('\n');
            while(!isValid)
            {
                Random random = new Random();
                string theChoosenOne = data[random.Next(0, data.Length - 2)];
                theChoosenOne = theChoosenOne.Substring(0, theChoosenOne.Length - 2);
                string[] props = theChoosenOne.Split(',');
                Send("attackPlayer:" + private_key + ":" + props[2]);
                enemyLevel = Convert.ToInt32(props[1]);
                isValid = true;
                Console.WriteLine("Now attacking: " + props[0] + " Level: " + props[1]);
            }
        }

        public static void Send(string input)
        {
            byte[] buffer = new byte[input.Length];
            buffer = Encoding.ASCII.GetBytes(input);
            stream.Write(buffer, 0, input.Length);
        }

        public static string Receive()
        {
            while (!stream.DataAvailable) { }
            byte[] buffer = new byte[4096];
            string output = "";
            stream.Read(buffer, 0, buffer.Length);
            output = Encoding.ASCII.GetString(buffer);
            output = output.Split((char)0)[0];
            return output;
        }

        public static void guessMD5(object threadNumber)
        {
            Console.WriteLine("Thread " + threadNumber + " Initialized");
            while(true)
            {
                if(!wait)
                {

                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        public static string GetMD5(string source)
        {
            using (MD5 md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(source))).Replace("-", string.Empty).ToLower();
            }
        }
    }
}
