using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaDoble
    {
        private Nodo cabeza;
        private Nodo cola;

        public void Agregar(string titulo, string autor)
        {
            Nodo nuevo = new Nodo(titulo, autor);
            if (cabeza == null)
            {
                cabeza = cola = nuevo;
            }
            else
            {
                cola.sig = nuevo;
                nuevo.ant = cola;
                cola = nuevo;
            }
        }
        public void Mostraradelante()
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine($"{actual.titulo} - {actual.autor}");
                actual = actual.sig;
            }
        }

        //  Versión para interfaz gráfica
        public void MostrarAdelante(ListBox lista)
        {
            lista.Items.Clear();

            Nodo actual = cabeza;
            if (actual == null)
            {
                lista.Items.Add("El catálogo está vacío.");
                return;
            }

            while (actual != null)
            {
                lista.Items.Add($"{actual.titulo} - {actual.autor}");
                actual = actual.sig;
            }
        }
    }
}
