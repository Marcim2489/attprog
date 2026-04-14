using System;
using System.Collections.Generic;
using System.Threading;

namespace MemoriaParalela
{
    internal class Program
    {
        static Random random = new Random();
        static int numerosParaMemorizar = 5;
        static List<int> sequenciaCerta = new List<int>(numerosParaMemorizar);
        static List<(Jogador, List<int>)> tentativas = new List<(Jogador, List<int>)>();
        static List<(Jogador, int)> vencedores = new List<(Jogador, int)>() 
        {
            (null,0)
        };
        static List<Thread> threads = new List<Thread>();
        static object lockObject = new object();

        static List<Jogador> jogadores = new List<Jogador>()
        {
            new Jogador("Cuidadoso", 3000, 85),
            new Jogador("Comum", 2000, 75),
            new Jogador("Afobado", 1000, 60),
            //new Jogador("Mestre", 1000, 95) //banido por ser muito apelão
        };

        static void Main(string[] args)
        {
            string anuncioSequenciaCerta = "A sequência é: ";
            for (int i = 0; i < numerosParaMemorizar; i++)
            {
                sequenciaCerta.Add(random.Next(0,10));
                anuncioSequenciaCerta += $"{sequenciaCerta[i]} ";
            }
            Console.WriteLine(anuncioSequenciaCerta+"\n");

            foreach(Jogador jogador in jogadores)
            {
                Thread t = new Thread(() =>
                {
                    Thread.Sleep(jogador.TempoDeMemorizacao);
                    List<int> sequenciaMemorizada = FazerTentativa(jogador);
                    lock (lockObject)
                    {
                        tentativas.Add((jogador, sequenciaMemorizada));
                    }
                });
                threads.Add(t);
                t.Start();
            }
            foreach(Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine();
            DefinirVencedores();

            if (vencedores[0].Item1 != null)
            {
                if(vencedores.Count <= 1)
                {
                    Console.WriteLine($"\nO vencedor é {vencedores[0].Item1.Nome}!");
                }
                else
                {
                    Console.WriteLine("\nOs vencedores empataram:");
                    foreach((Jogador, int) vencedor in vencedores)
                    {
                        Console.WriteLine(vencedor.Item1.Nome);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("\nNão houveram vencedores! Ninguém acertou nada, avassalador...");
            }
        }

        static List<int> FazerTentativa(Jogador jogador)
        {
            
            List<int> sequenciaMemorizada = new List<int>(sequenciaCerta.Count);
            sequenciaMemorizada.AddRange(sequenciaCerta);
            for(int i =0; i < sequenciaMemorizada.Count; i++)
            {
                int chanceDeErro = random.Next(1, 101);
                if(chanceDeErro > jogador.Precisao)
                {
                    sequenciaMemorizada.RemoveAt(i);
                    sequenciaMemorizada.Insert(i, random.Next(0, 10));
                }
            }
            
            string fala = $"{jogador.Nome}: ";
            for(int i = 0; i< sequenciaMemorizada.Count; i++)
            {
                fala +=$"{sequenciaMemorizada[i]} ";
            }
            Console.WriteLine(fala);
            return sequenciaMemorizada;
        }

        static void DefinirVencedores()
        {
            foreach((Jogador, List<int>) tentativa in tentativas)
            {
                int acertos = 0;
                for (int i = 0; i < tentativa.Item2.Count; i++)
                {
                    if (tentativa.Item2[i] == sequenciaCerta[i])
                    {
                        acertos++;
                    }
                }
                Console.WriteLine($"{tentativa.Item1.Nome}: {acertos} acertos em {tentativa.Item1.TempoDeMemorizacao/1000f} segundos!");
                if (acertos <= 0)
                {
                    continue;
                }
                if(vencedores[0].Item1 == null)
                {
                    vencedores[0] = (tentativa.Item1, acertos);
                    continue;
                }
                if (acertos < vencedores[0].Item2)
                {
                    continue;
                }
                if (acertos > vencedores[0].Item2)
                {
                    vencedores.Clear();
                    vencedores.Add((tentativa.Item1, acertos));
                    continue;
                }
                if(acertos == vencedores[0].Item2)
                {
                    if(tentativa.Item1.TempoDeMemorizacao > vencedores[0].Item1.TempoDeMemorizacao)
                    {
                        continue;
                    }else if(tentativa.Item1.TempoDeMemorizacao < vencedores[0].Item1.TempoDeMemorizacao)
                    {
                        vencedores.Clear();
                        vencedores.Add((tentativa.Item1, acertos));
                    }
                    else
                    {
                        vencedores.Add((tentativa.Item1, acertos));
                    }
                }
            }
        }
    }

    class Jogador
    {
        public string Nome { get; private set; }
        public int TempoDeMemorizacao { get; private set; }
        public int Precisao { get; private set; }

        public Jogador(string nome, int tempoDeMemorizacao, int precisao)
        {
            Nome = nome;
            TempoDeMemorizacao = tempoDeMemorizacao;
            Precisao = precisao;
        }
    }
}
