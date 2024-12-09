using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
    internal class Jogador
    {
        public string nome { get; set; }
        private int posição;
        private int QuantCartas;
        public Stack<Cartas> monte { get; }



        public Jogador(string nome, int posição, int quantCartas)
        { 
            this.nome = nome;
            this.posição = posição;
            this.QuantCartas = quantCartas;
            monte = new Stack<Cartas>();
        }
        public int quantCartas()
        {
            return monte.Count;
        }
        public void AdicionarCarta(Cartas carta)
        {
            monte.Push(carta);
        }
        public Cartas verCarta()
        {
            if (monte.Count == 0)
            {
                return null;
            }
            return monte.Peek();
        }
        public int tamanhoDoMonte()
        {
           
            return monte.Count();
        }
        public void roubarMonte(Jogador outroJogador, Cartas cartaDaVez)
        {
           while(outroJogador.monte.Count > 0)
            {
                monte.Push(outroJogador.monte.Pop());
            }
            monte.Push(cartaDaVez);

        }
        public void inserir (Cartas carta, Cartas cartaDaVez)
        {
            monte.Push(carta);
            monte.Push(cartaDaVez);
        }

    }
}
