using System;
using System.Collections.Generic;

namespace VeiculosInsanos
{
    internal class Program
    {
        static List<Veiculo> veiculosCadastrados = new List<Veiculo>();

        static void Main(string[] args)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Selecione a opção desejada.");
                Console.WriteLine("1 - Cadastrar veículo\n2 - Exibir dados\n3 - Sair");
                int opcaoEscolhida = 0;
                while(int.TryParse(Console.ReadLine(), out opcaoEscolhida)==false || opcaoEscolhida <1 || opcaoEscolhida >3)
                {
                    InvalidarInput();
                }
                Console.Clear();
                if (opcaoEscolhida == 1)
                {
                    CadastrarVeiculo();
                }else if(opcaoEscolhida == 2)
                {
                    ExibirVeiculosCadastrados();
                }else
                {
                    break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Adeus!");
            Console.ReadKey();
            Console.Clear();
        }

        static void InvalidarInput()
        {
            Console.WriteLine("Input inválido!");
        }

        static void CadastrarVeiculo()
        {
            Console.WriteLine("Cadastrando veículo...\n");
            Console.WriteLine("Insira o modelo");
            string modelo = Console.ReadLine()!;
            while(modelo==""){
                InvalidarInput();
                modelo = Console.ReadLine()!;
            }
            Console.WriteLine("Insira o fabricante");
            string fabricante = Console.ReadLine()!;
            while(fabricante==""){
                InvalidarInput();
                fabricante = Console.ReadLine()!;
            }
            Console.WriteLine("Insira a cor");
            string cor = Console.ReadLine()!;
            while(cor==""){
                InvalidarInput();
                cor = Console.ReadLine()!;
            }
            Console.WriteLine("Insira o ano de fabricação");
            int anoFabricacao;
            while(int.TryParse(Console.ReadLine()!, out anoFabricacao)==false)
            {
                InvalidarInput();
            }
            Console.WriteLine("Insira o ano do modelo");
            int anoModelo;
            while (int.TryParse(Console.ReadLine()!, out anoModelo)==false)
            {
                InvalidarInput();
            }

            veiculosCadastrados.Add(new Veiculo(modelo, fabricante, cor, anoFabricacao, anoModelo));
            Console.WriteLine("Veículo cadastrado com sucesso!\n");
        }

        static void ExibirVeiculosCadastrados()
        { 
            if (veiculosCadastrados.Count <= 0)
            {
                Console.WriteLine("Não há veículos cadastrados!");
                return;
            }
            Console.WriteLine("Exibindo dados dos veículos cadastrados...");
            foreach (Veiculo veiculo in veiculosCadastrados)
            {
                veiculo.ExibirInformacoes();
            }
        }
    }

    class Veiculo
    {
        string modelo;
        string fabricante;
        string cor;
        int anoFabricacao;
        int anoModelo;

        public void ExibirInformacoes()
        {
            string dados = $"\nModelo: {modelo}\nFabricante: {fabricante}\nCor: {cor}"+
            $"\nAno de fabricação: {anoFabricacao}\nAno do modelo: {anoModelo}";
            Console.WriteLine(dados);
        }

        public Veiculo(string modelo, string fabricante, string cor, int anoFabricacao, int anoModelo)
        {
            this.modelo = modelo;
            this.fabricante = fabricante;
            this.cor = cor;
            this.anoFabricacao = anoFabricacao;
            this.anoModelo = anoModelo;
        }
    }
}
