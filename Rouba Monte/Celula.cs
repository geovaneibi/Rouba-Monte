using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
    class Celula
    {
        private Cartas carta;
        private Celula prox;

        public Celula(Cartas carta)
        {
            this.carta = carta;
            this.prox = null;
        }
        public Celula()
        {
            this.prox = null;
            this.carta = null;
        }
        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }
        public Cartas Carta
        {
            get { return carta; }
            set { carta = value; }

        }
    }
}
