using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ResultVsAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Parte bloqueante");
            Console.WriteLine($"{CalcularPesado().Result} -- {sw.ElapsedMilliseconds}");


            sw = Stopwatch.StartNew();
            Console.WriteLine("\nParte não bloqueante");

            Task<int> calculo = CalcularPesado();

            while (calculo!=null && !calculo.IsCompleted)
            {
                Console.WriteLine("rodando...");
                await Task.Delay(500);
            }

            Console.WriteLine($"{await calculo} -- {sw.ElapsedMilliseconds}");
        }


        static Task<int> CalcularPesado()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(5000);
                return 0;
            });
            
        }
    }

}
