using System;

namespace MiniCalculadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcaoEscolhida=0;
            do
            {
                Console.WriteLine("Vamos fazer um cálculo! Represente as decimais com vírgula.");
                Console.WriteLine();

                float primeiroNumero;
                float segundoNumero;

                Console.WriteLine("Insira o primeiro número.");
                while (float.TryParse(Console.ReadLine(), out primeiroNumero)==false)
                {
                    Console.WriteLine("Input inválido! Digite o primeiro número novamente.");
                }
                Console.WriteLine();

                Console.WriteLine("Insira o segundo número.");
                while (float.TryParse(Console.ReadLine(), out segundoNumero) == false)
                {
                    Console.WriteLine("Input inválido!  Digite o segundo número novamente.");
                }
                Console.WriteLine();

                Console.WriteLine("Agora selecione a operação");
                Console.WriteLine("1 - Soma");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.WriteLine("5 - Sair");
                while (int.TryParse(Console.ReadLine(), out opcaoEscolhida) == false || opcaoEscolhida<1 || opcaoEscolhida >5)
                {
                    Console.WriteLine("Input inválido!  Digite a operação desejada novamente.");
                }
                Console.WriteLine();
                switch (opcaoEscolhida) 
                {
                    case 1:
                        Console.WriteLine("O resultado da soma é " + (primeiroNumero + segundoNumero) + "!");
                        break;
                    case 2:
                        Console.WriteLine("O resultado da subtração é " + (primeiroNumero - segundoNumero) + "!");
                        break;
                    case 3:
                        Console.WriteLine("O resultado da multiplicação é " + (primeiroNumero * segundoNumero) + "!");
                        break;
                    case 4:
                        Console.WriteLine("O resultado da divisão é " + (primeiroNumero/segundoNumero) + "!");
                        break;
                    case 5:
                        Console.WriteLine("Adeus!");
                        break;
                    default:
                        Console.WriteLine("Algo deu errado...");
                        break;
                }
                
                Console.ReadKey();
                Console.Clear();

            } while (opcaoEscolhida != 5);
        }
    }
}
