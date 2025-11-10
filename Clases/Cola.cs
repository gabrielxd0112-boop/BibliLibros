using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Cola
    {
        public NodoCola inicio, fin;

        public void Encolar(string usuario)
        {
            NodoCola nuevo = new NodoCola();
            nuevo.usuario = usuario;

            if (inicio == null)
                inicio = fin = nuevo;
            else
            {
                fin.siguiente = nuevo;
                fin = nuevo;
            }
        }

        public void Atender()
        {
            if (inicio == null)
            {
                Console.WriteLine("Cola vacía");
                return;
            }

            Console.WriteLine("Atendiendo a: " + inicio.usuario);
            inicio = inicio.siguiente;
        }

        public void Mostrar()
        {
            NodoCola temp = inicio;
            while (temp != null)
            {
                Console.WriteLine("- " + temp.usuario);
                temp = temp.siguiente;
            }
        }
    }
}
