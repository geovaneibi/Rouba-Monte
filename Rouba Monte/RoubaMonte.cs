using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
    internal class RoubaMonte
    {
        static void RegistrarLog(string mensagem)
        {
            using (StreamWriter log = new StreamWriter("log_jogo.txt", true))
            {
                log.WriteLine($"{DateTime.Now}: {mensagem}");
            }
        }

        static Stack<Cartas> CriarBaralhoEmbaralha(int quantBaralho)
        {
            string[] naipes = { "Copas", "Espadas", "Ouros", "Paus" };
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            List<Cartas> baralho = new List<Cartas>();
            for (int i = 0; i < quantBaralho; i++)
            {
                foreach (var naipe in naipes)
                {
                    foreach (var num in numeros)
                    {
                        baralho.Add(new Cartas(num, naipe));
                    }
                }
            }

            Random random = new Random();
            for (int i = baralho.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (baralho[i], baralho[j]) = (baralho[j], baralho[i]);
            }

            RegistrarLog($"Baralho criado e embaralhado com {baralho.Count} cartas.");
            return new Stack<Cartas>(baralho);
        }

        static Jogador verificarMonte(FilaCircular filaCircular, Cartas cartaDaVez)
        {
            List<Jogador> jogadores = new List<Jogador>();
            Jogador maiorMonte = null;
            int tamanhoMaiorMonte = 0;

            for (int i = 0; i < filaCircular.tamanho; i++)
            {
                Jogador jogadorAtual = filaCircular.VerJogador(i);
                if (jogadorAtual.verCarta() != null && jogadorAtual.verCarta().numero == cartaDaVez.numero)
                {
                    if (jogadorAtual.tamanhoDoMonte() > tamanhoMaiorMonte)
                    {
                        tamanhoMaiorMonte = jogadorAtual.tamanhoDoMonte();
                        maiorMonte = jogadorAtual;
                    }
                    else if (jogadorAtual.tamanhoDoMonte() == tamanhoMaiorMonte)
                    {
                        jogadores.Add(jogadorAtual);
                    }
                }
            }
            if (jogadores.Count > 0)
            {
                Random random = new Random();
                int indexEscolhido = random.Next(jogadores.Count);
                return jogadores[indexEscolhido];
            }

            return null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("----------------ROUBA MONTE--------------\n\n\n");
            Console.WriteLine("Informe a quantidade de jogadores");
            int quantJogadores = int.Parse(Console.ReadLine());
            FilaCircular filaCirlular = new FilaCircular(quantJogadores);

            List<string> nomesJogadores = new List<string>();
            for (int i = 0; i < quantJogadores; i++)
            {
                Console.WriteLine("Informe o nome do " + (1 + i) + "º jogador");
                string nomeJogador = Console.ReadLine();
                nomesJogadores.Add(nomeJogador);
                Jogador jogador = new Jogador(nomeJogador, i, 0);
                filaCirlular.inserir(jogador);
            }

            RegistrarLog($"Jogadores da partida: {string.Join(", ", nomesJogadores)}.");

            Console.WriteLine("Informe a quantidade de baralhos a ser usado na partida");
            int quantBaralhos = int.Parse(Console.ReadLine());
            Stack<Cartas> monteDeCompras = CriarBaralhoEmbaralha(quantBaralhos);
            listaFlexivel areaDescarte = new listaFlexivel();

            RegistrarLog($"Início da partida com {quantJogadores} jogadores e {quantBaralhos} baralhos.");

            while (monteDeCompras.Count > 0)
            {
                Jogador jogadorDaVez = filaCirlular.proximoJogador();
                RegistrarLog($"Turno do jogador: {jogadorDaVez.nome}.");
                bool continuarJogando = true;
                bool dnv = false;

                while (continuarJogando && monteDeCompras.Count > 0)
                {
                    if (dnv)
                    {
                        Console.WriteLine($"O jogador {jogadorDaVez.nome} deve jogar mais uma vez. Pressione Enter para retirar uma carta do monte de compras.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"É a vez do {jogadorDaVez.nome} jogar. Pressione Enter para retirar uma carta do monte de compras.");
                        Console.ReadLine();
                    }

                    Cartas cartaDaVez = monteDeCompras.Pop();
                    Console.WriteLine($"A carta retirada foi {cartaDaVez.numero} de {cartaDaVez.naipe}");
                    RegistrarLog($"{jogadorDaVez.nome} retirou a carta {cartaDaVez.numero} de {cartaDaVez.naipe} do monte de compras.");

                    Jogador jogadorComCartaIgual = verificarMonte(filaCirlular, cartaDaVez);
                    if (jogadorComCartaIgual != null)
                    {
                        Console.WriteLine("Carta igual encontrada! Pressione Enter para roubar o monte.");
                        Console.ReadLine();
                        Console.WriteLine($"{jogadorDaVez.nome} roubou o monte de {jogadorComCartaIgual.nome}.");
                        RegistrarLog($"{jogadorDaVez.nome} roubou o monte de {jogadorComCartaIgual.nome} com a carta {cartaDaVez.numero}.");
                        jogadorDaVez.roubarMonte(jogadorComCartaIgual, cartaDaVez);
                        dnv = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma carta igual encontrada. Verificando área de descarte...");
                        Cartas cartaAreaDescarte = areaDescarte.Remover(cartaDaVez);
                        if (cartaAreaDescarte != null)
                        {
                            Console.WriteLine($"Carta igual encontrada! Pressione Enter para inseri-la no seu monte.");
                            Console.ReadLine();
                            jogadorDaVez.inserir(cartaAreaDescarte, cartaDaVez);
                            RegistrarLog($"{jogadorDaVez.nome} pegou a carta {cartaAreaDescarte.numero} da área de descarte e adicionou ao seu monte junto com {cartaDaVez.numero}.");
                            dnv = true;
                            continue;
                        }

                        Console.WriteLine("Nenhuma carta igual. A carta será jogada na área de descarte.");
                        areaDescarte.Inserir(cartaDaVez);
                        RegistrarLog($"{jogadorDaVez.nome} descartou a carta {cartaDaVez.numero} na área de descarte.");
                        continuarJogando = false;
                        dnv = false;
                    }
                }
            }

            Jogador jogadorGanhador = null;
            int maiorNumeroDeCartas = 0;
            List<Jogador> vencedores = new List<Jogador>();

            for (int i = 0; i < quantJogadores; i++)
            {
                Jogador jogadorAtual = filaCirlular.proximoJogador();
                if (jogadorAtual.quantCartas() > maiorNumeroDeCartas)
                {
                    vencedores.Clear();
                    vencedores.Add(jogadorAtual);
                    maiorNumeroDeCartas = jogadorAtual.quantCartas();
                }
                else if (jogadorAtual.quantCartas() == maiorNumeroDeCartas)
                {
                    vencedores.Add(jogadorAtual);
                }
            }

            RegistrarLog("Partida encerrada.");
            if (vencedores.Count > 0)
            {
                foreach (var vencedor in vencedores)
                {
                    RegistrarLog($"Vencedor: {vencedor.nome} com {maiorNumeroDeCartas} cartas.");
                    Console.WriteLine($"Jogador vencedor: {vencedor.nome} com {maiorNumeroDeCartas} carta.");
                }
            }
            else
                {
                    RegistrarLog("Nenhum vencedor identificado.");
                }

            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine(); 
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();

        }
    }
}
