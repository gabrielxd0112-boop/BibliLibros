using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaDoble
    {
        public NodoDoble inicio, fin;

        public void Agregar(string titulo, string autor)
        {
            NodoDoble nuevo = new NodoDoble();
            nuevo.titulo = titulo;
            nuevo.autor = autor;

            if (inicio == null)
                inicio = fin = nuevo;
            else
            {
                fin.siguiente = nuevo;
                nuevo.anterior = fin;
                fin = nuevo;
            }
        }

        public void MostrarAdelante()
        {
            NodoDoble temp = inicio;
            while (temp != null)
            {
                Console.WriteLine($"{temp.titulo} - {temp.autor}");
                temp = temp.siguiente;
            }
        }
    }
}
