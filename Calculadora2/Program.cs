using System;

class Program
{
    static void Main(string[] args)
    {
        float valor1 = 0, valor2 = 0;
        int opcao = 0;

        do
        {
            // Método sem retorno para receber valores
            ReceberValores(ref valor1, ref valor2);

            // Método sem retorno para exibir menu
            ExibirMenu();

            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            if (opcao >= 1 && opcao <= 4)
            {
                // Método com retorno
                float resultado = Calcular(valor1, valor2, opcao);
                Console.WriteLine("Resultado: " + resultado);
            }
            else if (opcao != 5)
            {
                Console.WriteLine("Opção inválida!");
            }

            Console.WriteLine();

        } while (opcao != 5);

        Console.WriteLine("Programa encerrado.");
    }

    // Método sem retorno para receber valores
    static void ReceberValores(ref float v1, ref float v2)
    {
        Console.Write("Digite o primeiro valor: ");
        v1 = float.Parse(Console.ReadLine());

        Console.Write("Digite o segundo valor: ");
        v2 = float.Parse(Console.ReadLine());
    }

    // Método sem retorno para exibir menu
    static void ExibirMenu()
    {
        Console.WriteLine("\n=== MENU ===");
        Console.WriteLine("1 - Somar");
        Console.WriteLine("2 - Subtrair");
        Console.WriteLine("3 - Multiplicar");
        Console.WriteLine("4 - Dividir");
        Console.WriteLine("5 - Sair");
    }

    // Método com retorno (recebe 3 parâmetros)
    static float Calcular(float valor1, float valor2, int opcaoCalculo)
    {
        switch (opcaoCalculo)
        {
            case 1:
                return valor1 + valor2;
            case 2:
                return valor1 - valor2;
            case 3:
                return valor1 * valor2;
            case 4:
                if (valor2 != 0)
                    return valor1 / valor2;
                else
                {
                    Console.WriteLine("Erro: divisão por zero!");
                    return 0;
                }
            default:
                return 0;
        }
    }
}