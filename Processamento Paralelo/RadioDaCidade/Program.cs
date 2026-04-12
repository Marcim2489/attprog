using System;
using System.Collections.Generic;
using System.Threading;

namespace RadioDaCidade
{
    internal class Program
    {
        static List<Musica> playList = new List<Musica>()
        {
            new Musica("Imagine - John Lennon", 2000),
            new Musica("Bohemian Rhapsody - Queen", 3000),
            new Musica("Billie Jean - Michael Jackson", 1500),
            new Musica("Smells Like Teen Spirit - Nirvana", 2500),
            new Musica("Shape of You - Ed Sheeran", 1000),
        };

        static void Main(string[] args)
        {
            foreach(Musica musica in playList)
            {
                Thread tocarMusica = new Thread(() =>
                {
                    Thread.Sleep(musica.Duracao);
                });
                tocarMusica.Start();
                Console.WriteLine($"Tocando: {musica.Nome}");
                tocarMusica.Join();
            }
        }
    }

    internal class Musica
    {
        public string Nome { get; private set; }
        public int Duracao { get; private set; }

        public Musica(string nome, int duracao)
        {
            Nome = nome;
            Duracao = duracao;
        }

    }
}
