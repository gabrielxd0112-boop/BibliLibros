using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    
        public class ListaCircular
        {
            public NodoCircular inicio = null;

            public void Agregar(string titulo)
            {
                NodoCircular nuevo = new NodoCircular(titulo);

                if (inicio == null)
                {
                    inicio = nuevo;
                    inicio.siguiente = inicio;
                }
                else
                {
                    NodoCircular actual = inicio;
                    while (actual.siguiente != inicio)
                    {
                        actual = actual.siguiente;
                    }
                    actual.siguiente = nuevo;
                    nuevo.siguiente = inicio;
                }
            }

            public void Mostrar(ListBox lista)
            {
                lista.Items.Clear();

                if (inicio == null)
                {
                    lista.Items.Add("No hay libros recomendados actualmente.");
                    return;
                }

                NodoCircular actual = inicio;
                do
                {
                    lista.Items.Add($"- {actual.titulo}");
                    actual = actual.siguiente;
                } while (actual != inicio);
            }
        }
    
}
