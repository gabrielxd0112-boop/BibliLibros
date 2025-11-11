using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Nodo
    {
        public string titulo;
        public string autor;
        public Nodo sig;
        public Nodo ant;

        public Nodo(string t, string a)
        {
            titulo = t;
            autor = a;
            sig = ant = null;
        }
    }
}
