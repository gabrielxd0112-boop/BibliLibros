using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaCircular
    {
        public NodoCircular inicio;

        public void Agregar(string titulo)
        {
            NodoCircular nuevo = new NodoCircular();
            nuevo.titulo = titulo;

            if (inicio == null)
            {
                inicio = nuevo;
                nuevo.siguiente = inicio;
            }
            else
            {
                NodoCircular temp = inicio;
                while (temp.siguiente != inicio)
                    temp = temp.siguiente;
                temp.siguiente = nuevo;
                nuevo.siguiente = inicio;
            }
        }

        public void Mostrar(int vueltas)
        {
            if (inicio == null) return;

            NodoCircular temp = inicio;
            for (int i = 0; i < vueltas; i++)
            {
                do
                {
                    Console.WriteLine("- " + temp.titulo);
                    temp = temp.siguiente;
                } while (temp != inicio);
            }
        }
    }
}
