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

        public void Mostrar(ListBox lista)
        {
            {
                lista.Items.Clear();

                if (inicio == null)
                {
                    lista.Items.Add("No hay solicitudes en espera.");
                    return;
                }

                NodoCola actual = inicio;
                while (actual != null)
                {
                    lista.Items.Add($"- {actual.usuario}");
                    actual = actual.siguiente;
                }
            }
        }

        public bool Vacia()
        {
            return inicio == null;
        }

        public string Peek()
        {
            if (inicio == null) return null;
            return inicio.usuario.ToString();
        }

        public string Desencolar()
        {
            if (inicio == null) return null;
            string valor = inicio.usuario.ToString();
            inicio = inicio.siguiente;
            return valor;
        }
    }
}
