using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class NodoArbol
    {
        public string Titulo;
        public string Autor;
        public NodoArbol izquierda;
        public NodoArbol derecha;

        public NodoArbol(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
            izquierda = null;
            derecha = null;
        }
    }
}

