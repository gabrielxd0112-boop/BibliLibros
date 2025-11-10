using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaSimple
    {
        public NodoSimple inicio;

        public void Agregar(string nombre)
        {
            NodoSimple nuevo = new NodoSimple();
            nuevo.nombre = nombre;

            if (inicio == null)
                inicio = nuevo;
            else
            {
                NodoSimple temp = inicio;
                while (temp.siguiente != null)
                    temp = temp.siguiente;
                temp.siguiente = nuevo;
            }
        }

        public void Mostrar()
        {
            NodoSimple temp = inicio;
            while (temp != null)
            {
                Console.WriteLine("- " + temp.nombre);
                temp = temp.siguiente;
            }
        }
    }
}
