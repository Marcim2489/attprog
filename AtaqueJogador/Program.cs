using System;

namespace AtaqueJogador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            inicio:
            Personagem jogador1 = RegistrarJogador(1);
            Personagem jogador2 = RegistrarJogador(2);
            bool receberAviso = true;
            int opcao;
            do
            {
                if (receberAviso && (jogador1.EstaMorto || jogador2.EstaMorto))
                {
                    Console.WriteLine("Um dos jogadores morreu, reiniciar a partida é recomendado.");
                    Console.WriteLine("1 - Reiniciar");
                    Console.WriteLine("2 - Prosseguir");
                    Console.WriteLine("3 - Prosseguir e não receber o aviso novamente");
                    Console.WriteLine("4 - Sair\n");
                    while (int.TryParse(Console.ReadLine(), out opcao) == false || opcao < 1 || opcao > 4)
                    {
                        InvalidarInput();
                    }
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("\nA partida será reiniciada...");
                            EsperarComandoParaLimparConsole();
                            goto inicio;
                        case 2:
                            Console.Clear();
                            break;
                        case 3:
                            receberAviso = false;
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Adeus!");
                            opcao = 5;
                            goto final;
                    }
                }
                Console.WriteLine($"1 - {jogador1.Nome} ataca {jogador2.Nome}");
                Console.WriteLine($"2 - {jogador2.Nome} ataca {jogador1.Nome}");
                Console.WriteLine("3 - Exibir estado dos jogadores");
                Console.WriteLine("4 - Reiniciar partida");
                Console.WriteLine("5 - Sair\n");


                while (int.TryParse(Console.ReadLine(), out opcao) == false || opcao < 1 || opcao > 5)
                {
                    InvalidarInput();
                }
                
                switch (opcao)
                {
                    case 1:
                        AtacarJogador(jogador1, jogador2);
                        break;
                    case 2:
                        AtacarJogador(jogador2, jogador1);
                        break;
                    case 3:
                        Console.WriteLine("\n" + jogador1.RetornarEstado());
                        Console.WriteLine(jogador2.RetornarEstado());
                        break;
                    case 4:
                        Console.WriteLine("\nA partida será reiniciada...");
                        EsperarComandoParaLimparConsole();
                        goto inicio;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Adeus!");
                        break;
                }
                final:
                EsperarComandoParaLimparConsole();
            } while (opcao != 5);
            
        }

        
        static void AtacarJogador(Personagem agressor, Personagem alvo)
        {
            if (agressor.EstaMorto)
            {
                Console.WriteLine($"{agressor.Nome} está morto, não pode atacar!");
                return;
            }
            if (alvo.EstaMorto)
            {
                Console.WriteLine($"{alvo.Nome} já está morto!");
                return;
            }
            alvo.ReceberAtaque(agressor.PotenciaAtaque);
            Console.WriteLine($"\n{alvo.Nome} recebeu {agressor.PotenciaAtaque} de dano!");
            Console.WriteLine(alvo.RetornarEstado());
        }
        static void EsperarComandoParaLimparConsole()
        {
            Console.ReadKey();
            Console.Clear();
        }
        static void InvalidarInput()
        {
            Console.WriteLine("Input inválido!");
        }

        static Personagem RegistrarJogador(int idJogador)
        {
            Console.WriteLine($"Defina o nome do jogador {idJogador}");
            string nome = Console.ReadLine();
            while (nome == null || nome == "")
            {
                InvalidarInput();
                nome = Console.ReadLine();
            }
            Console.WriteLine($"Defina o valor de vida inicial do jogador {idJogador}");
            int vida;
            while (int.TryParse(Console.ReadLine(), out vida) == false || vida <= 0)
            {
                InvalidarInput();
            }
            Console.WriteLine($"Defina a potência de ataque do jogador {idJogador}");
            int ataque;
            while (int.TryParse(Console.ReadLine(), out ataque) == false || ataque <= 0)
            {
                InvalidarInput();
            }
            Console.WriteLine("Jogador registrado!");
            Console.ReadKey();
            Console.Clear();
            return new Personagem(nome, vida, ataque);
        }
    }

    class Personagem
    {
        public string Nome { get; private set; }
        public int Vida { get; private set; }
        public int PotenciaAtaque { get; private set; }
        public bool EstaMorto
        {
            get
            {
                return Vida <= 0;
            }
        }

        public Personagem(string nome, int vida, int ataque)
        {
            Nome = nome;
            Vida = vida;
            PotenciaAtaque = ataque;
        }

        public void ReceberAtaque(int dano)
        {

            Vida -= dano;
            if (Vida < 0)
            {
                Vida = 0;
            }
        }

        public string RetornarEstado()
        {
            if (EstaMorto==false)
            {
                return $"{Nome} está com {Vida} de vida!";
            }
            else
            {
                return $"{Nome} está morto!";
            }
        }
    }
}
