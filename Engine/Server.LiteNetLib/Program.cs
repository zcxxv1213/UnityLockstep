﻿using System;
using System.Diagnostics;
using System.Threading;
using Server.LiteNetLib;

namespace Server
{
    class Program
    {                                   
        static void Main(string[] args)
        {
            int roomSize = 1;
            int waitInSeconds = 1;

            var sw = new Stopwatch();
            sw.Start();
            Console.Write($"Enter room size (defaults to {roomSize} after {waitInSeconds} seconds): ");
            while (!Console.KeyAvailable && sw.Elapsed.Seconds < waitInSeconds)
            {                  
                Thread.Sleep(1);
            }
            sw.Stop();

            if (Console.KeyAvailable)
            {
                roomSize = Console.ReadKey().KeyChar - 48;             
            }
            Console.Write(Environment.NewLine);

            var server = new LiteNetLibServer();

            var room = new Room(server, roomSize);

            room.Open(9050);         

            while (!Console.KeyAvailable)
            {
                server.PollEvents();
                Thread.Sleep(1);
            }
                          
        }       
    }
}