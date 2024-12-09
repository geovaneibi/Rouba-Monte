using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
   
    internal class listaFlexivel
    {
        private Celula primeiro, ultimo;
        private int tamanho;
        public listaFlexivel()
        {
            primeiro = new Celula();
            ultimo = primeiro;
            tamanho = 0;
        }
        public int Tamanho()
        {
            return tamanho;
        }
        public Celula Primeiro { get { return primeiro; } }


        public void Inserir(Cartas cartaDaVez)
        {
            Celula tmp = new Celula(cartaDaVez);
            ultimo.Prox = tmp;
            ultimo = tmp;
            tamanho++;
        }
        public Cartas Remover(Cartas cartaDaVez)
        {
            Celula anterior = primeiro;
            Celula atual = primeiro.Prox;

            while (atual != null)
            {
                if (atual.Carta.numero == cartaDaVez.numero)
                {
                    anterior.Prox = atual.Prox;

                    if ( atual == ultimo)
                    {
                        ultimo = anterior;
                    }
                    tamanho--;
                    return atual.Carta;
                }
                anterior = atual;
                atual = atual.Prox;
            }
            return null;
        }
    }
}
