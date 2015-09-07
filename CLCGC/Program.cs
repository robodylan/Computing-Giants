﻿using System;
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
        public static void Main()
        {
            Console.Clear();
            bool notValid = true;
            while (notValid)
            {
                TcpClient client;
            NetworkStream stream;
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
                }
                catch
                {
                    Console.WriteLine("Error while connecting... Press any key to retry");
                    Console.Read();
                }
            }
        }
    }
}
