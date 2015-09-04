using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Computing_Giants
{
    internal class Program
    {        
        public static List<Entity> entities = new List<Entity>();
        public static Random rand = new Random(DateTime.Now.Millisecond);
        private static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 74);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread thread = new Thread(handleClient);
                thread.Start(client);
                string output = "";
                Console.WriteLine(output);
            }
            
        }

        public static string genID()
        {
            string chars = "ABCDEFGHIJKLMPQRSTUVWXYZabcdefghijklmpqrstuvwxyz1234567890";
            string output = "";
            for(int i = 0;i < 10;i++)
            {
                output += chars[rand.Next(0, chars.Length - 1)];
            }
            return output.ToString();
        }

        public static string stripEnding(string input)
        {
            string output;
            if (input.ToCharArray()[input.Length - 1] == '\n')
            {
                output = input.Substring(0, input.Length - 2); ;   
            }
            else
            {
                output = input;
            }
            return output;
        }

        public static void handleClient(object data)
        {
            TcpClient client = (TcpClient)data;
            NetworkStream stream = client.GetStream();
            string ID = genID();
            lock(entities) entities.Add(new Entity(ID, "NOT_SET"));
            byte[] bufferTMP = Encoding.ASCII.GetBytes("ID:" + ID.ToString() + "\r\n");
            stream.Write(bufferTMP, 0, bufferTMP.Length);
            while (client.Connected)
            {
                byte[] buffer = new byte[1024];
                Thread.Sleep(1000 / 60);
                if (stream.DataAvailable)
                {
                    stream.Read(buffer, 0, 1024);
                    string input;
                    input = Encoding.ASCII.GetString(buffer);
                    input = input.Split(Convert.ToChar(0))[0];
                    input = stripEnding(input);
                    switch (input.Split(':')[0])
                    {
                        case "getPlayers":
                            string playerData = "";
                            foreach (Entity entity in entities)
                            {
                                lock (entities) playerData = playerData + entity.username + "," + entity.x + "," + entity.y + "," + entity.direction + "," + "\r\n";
                            }
                            buffer = Encoding.ASCII.GetBytes(playerData);
                            stream.Write(buffer, 0, playerData.Length);
                            break;
                        case "setUsername":
                            foreach (Entity entity in entities)
                            {
                                try
                                {
                                    if (entity.key == input.Split(':')[1])
                                    {
                                        entity.username = input.Split(':')[2];
                                        break;
                                    }
                                }
                                catch
                                {

                                }
                            }
                            break;
                        case "Blank":
                            foreach (Entity entity in entities)
                            {
                                try
                                {
                                    if (entity.key == input.Split(':')[1])
                                    {
                                        //Code here
                                        break;
                                    }
                                }
                                catch
                                {

                                }
                            }
                            break;
                    }

                }
            }
        }
    }
}