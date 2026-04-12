using System;
using System.Collections.Generic;
using System.Threading;

namespace Estacionamento
{
    internal class Program
    {
        static int vagasDisponiveis = 3;
        static object lockObject = null;
        static Random random = new Random();
        static List<Thread> threads = new List<Thread>();
        static int quantidadeDeCarros = 6;
        static List<Carro> carros = new List<Carro>(quantidadeDeCarros);

        static void Main(string[] args)
        {
            for (int i = 0; i < quantidadeDeCarros; i++)
            {
                carros.Add(new Carro(i+1));
            }
            foreach (Carro carro in carros) 
            {
                Thread t = new Thread(() =>
                {
                    carro.TentarEstacionar();
                });
                threads.Add(t);
                t.Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        class Carro
        {
            public int Id { get; private set; }
            public Carro(int id)
            {
                Id = id;
            }

            public void TentarEstacionar()
            {
                Thread.Sleep(random.Next(0,2001));
                while (vagasDisponiveis <= 0)
                {
                    Thread.Sleep(1000);
                }
                while(lockObject!=null){ }
                lockObject = new object();
                Console.WriteLine($"Carro {Id} estacionou.");
                vagasDisponiveis--;
                Console.WriteLine($"Vagas disponíveis: {vagasDisponiveis}");
                lockObject = null;
                Thread.Sleep(2000);
                while (lockObject != null){ }
                lockObject = new object();
                Console.WriteLine($"Carro {Id} saiu.");
                vagasDisponiveis++;
                Console.WriteLine($"Vagas disponíveis: {vagasDisponiveis}");
                lockObject = null;
            }
        }
    }

    
}
