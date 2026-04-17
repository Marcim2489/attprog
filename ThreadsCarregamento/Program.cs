using System;
using System.Threading;

namespace ThreadsCarregamento
{
    internal class Program
    {
        static bool isLoaded = false;
        static void Main(string[] args)
        {
            Thread carregamentoDeTexturas = new Thread(CarregarTexturas);
            carregamentoDeTexturas.IsBackground = true;
            carregamentoDeTexturas.Start();
            while (isLoaded == false)
            {
                Console.WriteLine("Renderizando frame...");
                Thread.Sleep(200);
            }
            Console.WriteLine("Tchauzinho!");
        }

        static void CarregarTexturas()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Carregando texturas...");
                Thread.Sleep(500);
            }
            isLoaded = true;
        }
    }
}
