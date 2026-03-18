using System;

namespace IndiceMassaCorporal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float peso;
            float altura;
            
            Console.WriteLine("Use vírgula para representar os decimais.");
            Console.WriteLine();

            Console.WriteLine("Insira seu peso.");
            while (float.TryParse(Console.ReadLine(), out peso) == false)
            {
                Console.WriteLine("Input inválido! Tente novamente.");
            }
            Console.WriteLine();

            Console.WriteLine("Insira sua altura.");
            while (float.TryParse(Console.ReadLine(), out altura) == false)
            {
                Console.WriteLine("Input inválido! Tente novamente.");
            }
            Console.WriteLine();

            float indiceMassaCorporal= peso / (altura * altura);
            Console.WriteLine("Seu índice de massa corporal é: "+indiceMassaCorporal);

            string classificacao="";
            if (indiceMassaCorporal <= 16) classificacao = "Magreza grau III";
            else if (indiceMassaCorporal <= 16.9f) classificacao = "Magreza grau II";
            else if (indiceMassaCorporal <= 18.4f) classificacao = "Magreza grau I";
            else if (indiceMassaCorporal <= 24.9f) classificacao = "Adequado";
            else if (indiceMassaCorporal <= 29.9f) classificacao = "Pré-obeso";
            else if (indiceMassaCorporal <= 34.9f) classificacao = "Obesidade grau I";
            else if (indiceMassaCorporal <= 39.9f) classificacao = "Obesidade grau II";
            else classificacao = "Obesidade grau III";

            Console.WriteLine("Sua classificação é: "+classificacao);
        }
    }
}
