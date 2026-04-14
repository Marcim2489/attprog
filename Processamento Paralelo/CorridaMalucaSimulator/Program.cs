using System;
using System.Collections.Generic;
using System.Threading;

namespace CorridaMalucaSimulator
{
    internal class Program
    {
        static List<Carro> classificacaoFinal = new List<Carro>();
        static object lockObject = new object();
        static Random random = new Random();
        static int numeroTotalDeVoltas = 10;
        static List<Thread> threads = new List<Thread>();
        static List<Carro> competidores = new List<Carro>()
        {
            new Carro(200, "Ferrari", 200),
            new Carro(300, "McLaren", 80),
            new Carro(250, "Mercedes", 130)
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Lista de corredores:");
            Console.WriteLine();
            foreach (Carro carro in competidores)
            {
                Thread t = new Thread(() =>
                {
                    Correr(carro);
                });
                threads.Add(t);
                Console.WriteLine(carro.Nome);
            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para iniciar a corrida!");
            Console.ReadKey();
            foreach (Thread t in threads)
            {
                t.Start();
            }
            foreach (Thread t in threads)
            {
                t.Join();
            }    

            Console.WriteLine();
            for (int i = 0; i < classificacaoFinal.Count; i++)
            {
                Console.WriteLine($"{i+1}° - {classificacaoFinal[i].Nome}");
            }
        }

        static void Correr(Carro carro)
        {
            int tempoDaVoltaAntesDoPitStop = 0;
            float chanceDePitStop = 50f;
            while (carro.VoltasPercorridas < numeroTotalDeVoltas)
            {
                if(carro.VoltasPercorridas >= 3 && random.Next(0, 101) < chanceDePitStop)
                {
                    tempoDaVoltaAntesDoPitStop = carro.TempoDeCadaVolta/2;
                    Thread.Sleep(tempoDaVoltaAntesDoPitStop);
                    Console.WriteLine($"{carro.Nome} parou no pit stop!");
                    chanceDePitStop *= 0.1f;
                    Thread.Sleep(carro.TempoDePitStop);
                }
                Thread.Sleep(carro.TempoDeCadaVolta-tempoDaVoltaAntesDoPitStop);
                tempoDaVoltaAntesDoPitStop = 0;
                carro.CompletarVolta();
            }
            lock (lockObject) 
            {
                classificacaoFinal.Add(carro);
            }
        }
    }

    class Carro
    {
        public int TempoDeCadaVolta { get; private set; }
        public string Nome { get; private set; }
        public int VoltasPercorridas { get; private set; } = 0;
        public int TempoDePitStop { get; private set; }

        public void CompletarVolta()
        {
            VoltasPercorridas++;
            Console.WriteLine($"{Nome} completou uma volta!");
        }

        public Carro(int tempoPorVolta, string nome, int tempoDePitStop)
        {
            TempoDeCadaVolta = tempoPorVolta;
            Nome = nome;
            TempoDePitStop = tempoDePitStop;
        }
    }
}
