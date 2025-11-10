using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ArbolLibros
    {
        public NodoArbol raiz;

        public ArbolLibros()
        {
            raiz = null;
        }

        //Insertar libro 
        public void Insertar(ref NodoArbol raiz, string titulo, string autor)
        {
            InsertarLibro(ref raiz, titulo, autor);
        }

        private void InsertarLibro(ref NodoArbol nodo, string titulo, string autor)
        {
            if (nodo == null)
            {
                nodo = new NodoArbol(titulo, autor);
                return;
            }

            int comp = string.Compare(titulo.ToLower(), nodo.Titulo.ToLower());
            if (comp < 0)
            {
                InsertarLibro(ref nodo.izquierda, titulo, autor);
            }
            else if (comp > 0)
            {
                InsertarLibro(ref nodo.derecha, titulo, autor);
            }
        }

        //Buscar libro
        public static bool BuscarLibro(NodoArbol raiz, string titulo)
        {
            return BuscarLibroRec(raiz, titulo);
        }

        private static bool BuscarLibroRec(NodoArbol nodo, string titulo)
        {
            if (nodo == null) return false;

            int comp = string.Compare(titulo.ToLower(), nodo.Titulo.ToLower());
            if (comp == 0) return true;
            else if (comp < 0) return BuscarLibroRec(nodo.izquierda, titulo);
            else return BuscarLibroRec(nodo.derecha, titulo);
        }

        //Mostrar catálogo
        public void MostrarCatalogo()
        {
            if (raiz == null)
            {
                Console.WriteLine("\n El catálogo está vacío.");
                return;
            }

            Console.WriteLine("\n--- Catálogo de Libros ---");
            MostrarInOrden(raiz);
        }

        private void MostrarInOrden(NodoArbol nodo)
        {
            if (nodo != null)
            {
                MostrarInOrden(nodo.izquierda);
                Console.WriteLine($"Título: {nodo.Titulo} | Autor: {nodo.Autor}");
                MostrarInOrden(nodo.derecha);
            }
        }
    }
}
