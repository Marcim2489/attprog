using System;
using System.Collections.Generic;
using System.Threading;

namespace BattleQuestRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            const string NOME_DO_JOGO = "Topanga Quest RPG - Watch Out For Six Seven";
            const int SIX_SEVEN = 67;
            List<string> sims = new List<string>(8) 
            {
                "sim", "s", "si", "sí", "yes", "y", "yeah", "1"
            };
            List<string> naos = new List<string>(8)
            {
                "não", "nao", "n", "ñ", "no", "not", "2", "nah"
            };

            void MostrarNomeDoJogo()
            {
                Console.WriteLine(NOME_DO_JOGO);
            }

            void ExibirPontuacao(int pontos)
            {
                Console.WriteLine($"Pontos: {pontos}");
            }

            int CalcularDano(int ataque, int defesa)
            {
                int dano = ataque - defesa;
                if (dano > 0)
                {
                    return dano;
                }
                else
                {
                    return 0;
                }
            }

            int GerarPontuacaoInicial()
            {
                return random.Next(1,101);
            }
            
            void DarBroncaNoJogadorQueDigitouErrado()
            {
                Console.WriteLine("Input inválido!");
            }

            void SixSeven()
            {
                while (true)
                {
                    Console.Write(SIX_SEVEN);
                }
            }

            void ProtocoloSixSeven(int numeroAnalisado)
            {
                if(numeroAnalisado != SIX_SEVEN)
                {
                    return;
                }

                for (int i = 0; i < SIX_SEVEN; i++)
                {
                    Thread sixSeven = new Thread(SixSeven);
                    sixSeven.Start();
                }
                SixSeven();
            }

            bool continuar = true;
            do
            {
                MostrarNomeDoJogo();

                int pontuacaoAtual = GerarPontuacaoInicial();
                ExibirPontuacao(pontuacaoAtual);
                ProtocoloSixSeven(pontuacaoAtual);

                Console.WriteLine("Insira seu poder de ataque");
                int ataqueDoJogador;

                while (int.TryParse(Console.ReadLine(), out ataqueDoJogador) == false || ataqueDoJogador < 0)
                {
                    DarBroncaNoJogadorQueDigitouErrado();
                }
                ProtocoloSixSeven(ataqueDoJogador);

                Console.WriteLine("Insira a defesa do inimigo");
                int defesaDoInimigo;

                while (int.TryParse(Console.ReadLine(), out defesaDoInimigo) == false || defesaDoInimigo < 0)
                {
                    DarBroncaNoJogadorQueDigitouErrado();
                }
                ProtocoloSixSeven(defesaDoInimigo);

                Console.WriteLine();
                int danoCausadoNoInimigo = CalcularDano(ataqueDoJogador, defesaDoInimigo);
                Console.WriteLine($"Você causou {danoCausadoNoInimigo} de dano no inimigo!");
                ProtocoloSixSeven(danoCausadoNoInimigo);

                pontuacaoAtual += danoCausadoNoInimigo;
                ExibirPontuacao(pontuacaoAtual);
                ProtocoloSixSeven(pontuacaoAtual);

                Console.WriteLine("Deseja jogar novamente?");
                string resposta;

                while (true)
                {
                    resposta=Console.ReadLine();
                    if (sims.Contains(resposta))
                    {
                        continuar = true;
                        break;
                    }else if (naos.Contains(resposta))
                    {
                        continuar = false;
                        break;
                    }else if(int.TryParse(resposta, out int n))
                    {
                        ProtocoloSixSeven(int.Parse(resposta));
                    }
                    DarBroncaNoJogadorQueDigitouErrado();
                }
                Console.Clear();
            } while (continuar);

            Console.WriteLine("Obrigado por jogar! Cuidado com o six seven...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
