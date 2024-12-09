using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
    internal class Cartas
    {
        public int numero { get; }
        public string naipe { get; }

        public Cartas (int numero, string naipe)
        {
            this.numero = numero;
            this.naipe = naipe;
        }
    }
}
