using System;
using System.Threading;

namespace CozinhaMaldita
{
    internal class Program
    {
        static bool cozinhaAtiva = true;
        static void Main(string[] args)
        {
            Thread cozinheiroPizza = new Thread(() =>
            {
                PrepararRefeicao(800, "pizza");
            });
            Thread cozinheiroLasanha = new Thread(() =>
            {
                PrepararRefeicao(600, "lasanha");
            });
            Thread cozinheiroSalada = new Thread(() =>
            {
                PrepararRefeicao(400, "salada");
            });

            cozinheiroPizza.Start();
            cozinheiroLasanha.Start();
            cozinheiroSalada.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Coordenando a cozinha...");
                Thread.Sleep(1000);
            }
            cozinhaAtiva = false;
            Console.WriteLine("Pedidos prontos!");
        }

        static void PrepararRefeicao(int tempoDePreparo, string nomeDaRefeicao)
        {
            while (cozinhaAtiva)
            {
                Console.WriteLine($"Preparando {nomeDaRefeicao}...");
                Thread.Sleep(tempoDePreparo);
            }
        }
    }
}
