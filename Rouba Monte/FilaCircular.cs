using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
    internal class FilaCircular
    {
        private Jogador[] array;
        public int tamanho { get; set; }
        private int primeiro, ultimo;
        public FilaCircular(int quantJogadores)
        {
            inicializar(quantJogadores);
        }
        public void inicializar(int tamanho)
        {
            array = new Jogador[tamanho];
            primeiro = 0; ultimo = 0;
            this.tamanho = tamanho;
        }
        public void inserir(Jogador x)
        {
            array[ultimo] = x;
            ultimo = ultimo + 1;
        }
        public Jogador proximoJogador()
        {
            Jogador jogadorAtual = array[primeiro];
            primeiro = (primeiro + 1) % tamanho;
            return jogadorAtual;
        }
        public Jogador VerJogador(int index)
        {

            return array[(primeiro + index) % array.Length];
        }
    }
}
