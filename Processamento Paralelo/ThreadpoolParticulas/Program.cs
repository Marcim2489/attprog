using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadpoolParticulas
{
    internal class Program
    {
        static Random random = new Random();
        static int numeroDeParticulas = 100;
        static List<Particula> particulas = new List<Particula>(numeroDeParticulas);
        static void Main(string[] args)
        {
            int contadorDeParticulasProcessadas=0;
            for (int i = 0; i < numeroDeParticulas; i++)
            {
                Particula particula = new Particula(i, 0,0);
                particulas.Add(particula);
                ThreadPool.QueueUserWorkItem(delegate { 
                    particula.AtualizarPosicao(random.NextDouble()*300, random.NextDouble()*300);
                    Console.WriteLine($@" Thread {Environment.CurrentManagedThreadId} - Partícula {particula.Id}: ({particula.PosicaoX},{particula.PosicaoY})");
                    Interlocked.Increment(ref contadorDeParticulasProcessadas);
                });
            }
            while (contadorDeParticulasProcessadas < numeroDeParticulas){ Thread.Sleep(100); }
            Console.WriteLine($"Tchauzinho! Partículas processadas: {contadorDeParticulasProcessadas}");
            Console.ReadKey();
        }
    }

    class Particula
    {
        public int Id { get; private set; }
        public double PosicaoX { get; private set; }
        public double PosicaoY { get; private set; }

        public Particula(int id, double posicaoX, double posicaoY)
        {
            Id = id;
            PosicaoX = posicaoX;
            PosicaoY = posicaoY;
        }

        public void AtualizarPosicao(double variacaoX, double variacaoY)
        {
            PosicaoX += variacaoX;
            PosicaoY += variacaoY;
        }
    }
}
