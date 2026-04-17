using System;
using System.Threading;

namespace PrioridadeThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread audio = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    if(i% 1000 == 0)
                    {
                        TocarAudio();
                    }
                }
            });

            Thread pathfindingIa = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    if (i % 1000 == 0)
                    {
                        PathfindingInimigo();
                    }
                }
            });

            audio.Priority = ThreadPriority.Highest;
            pathfindingIa.Priority = ThreadPriority.Lowest;
            pathfindingIa.Start();
            audio.Start();
            
            audio.Join();
            pathfindingIa.Join();
        }

        static void TocarAudio()
        {
            Console.WriteLine("!");
        }

        static void PathfindingInimigo()
        {
            Console.WriteLine(".");
        }
    }

    
}
