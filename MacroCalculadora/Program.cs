using System;
using System.Threading;

namespace MiniCalculadora
{
    internal class Program
    {
        public enum Operacoes
        {
            Soma = 1,
            Subtracao = 2,
            Multiplicacao = 3,
            Divisao = 4,
        }
        static void Main(string[] args)
        {
            int opcaoEscolhida=0;
            decimal valorUm;
            decimal valorDois;
            const int SIX_SEVEN = 67;

            void AguardarComandoParaReiniciar()
            {
                Console.WriteLine("Pressione qualquer tecla para reiniciar.");
                Console.ReadKey();
                Console.Clear();
            }

            void ExibirMenu()
            {
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("1 - Soma");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.WriteLine("5 - Sair");
            }

            void ReceberValores()
            {
                Console.WriteLine("Insira o primeiro valor.");
                while (decimal.TryParse(Console.ReadLine(), out valorUm) == false)
                {
                    Console.WriteLine("Input inválido! Digite o primeiro número novamente.");
                }
                ProtocoloSixSeven(valorUm);
                Console.WriteLine();

                Console.WriteLine("Insira o segundo valor.");
                while (decimal.TryParse(Console.ReadLine(), out valorDois) == false)
                {
                    Console.WriteLine("Input inválido!  Digite o segundo número novamente.");
                }
                ProtocoloSixSeven(valorDois);
                Console.WriteLine();
            }

            decimal Calcular(decimal valor1, decimal valor2, Operacoes operacao)
            {
                decimal resultado=0;
                switch (operacao)
                { 
                    case Operacoes.Soma:
                        resultado = valor1+valor2;
                        break;
                    case Operacoes.Subtracao:
                        resultado = valor1 - valor2;
                        break;
                    case Operacoes.Multiplicacao:
                        resultado = valor1 * valor2;
                        break;
                    case Operacoes.Divisao:
                        resultado = valor1 / valor2;
                        break;
                }
                ProtocoloSixSeven(resultado);
                return resultado;
            }

            void SixSeven()
            {
                while (true)
                {
                    Console.Write(SIX_SEVEN);
                }
            }

            void ProtocoloSixSeven(decimal numero)
            {
                if (numero != SIX_SEVEN)
                {
                    return;
                }
                for(int i=0; i<SIX_SEVEN; i++)
                {
                    Thread sixSeven = new Thread(SixSeven);
                    sixSeven.Start();
                }
                SixSeven();
            }

            while(true)
            {
                Console.WriteLine("Vamos fazer um cálculo! Represente as decimais com vírgula.");
                Console.WriteLine();

                ExibirMenu();

                while (int.TryParse(Console.ReadLine(), out opcaoEscolhida) == false || opcaoEscolhida < 1 || opcaoEscolhida > 5)
                {
                    ProtocoloSixSeven(opcaoEscolhida);
                    Console.WriteLine("Input inválido!  Digite a operação desejada novamente.");
                }
                Console.WriteLine();
                if (opcaoEscolhida == 5)
                {
                    break;
                }
                
                ReceberValores();

                if(valorDois==0 && (Operacoes)opcaoEscolhida == Operacoes.Divisao)
                {
                    Console.WriteLine("Não é possível dividir por zero!");
                    AguardarComandoParaReiniciar();
                    continue;
                }

                Console.WriteLine($"O resultado da operação é: {Calcular(valorUm, valorDois, (Operacoes)opcaoEscolhida)}");
                Console.WriteLine();
                AguardarComandoParaReiniciar();
            }
            Console.Clear();
            Console.WriteLine("Adeus!");
        }
    }
}
