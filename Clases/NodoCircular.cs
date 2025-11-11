using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class NodoCircular
    {
        public string titulo;
        public NodoCircular siguiente;

        public NodoCircular(string t)
        {
            titulo = t;
            siguiente = null;
        }
    }
}
