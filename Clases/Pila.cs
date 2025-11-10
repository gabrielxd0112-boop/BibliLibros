using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Pila
    {
        public NodoPila cima;

        public void Apilar(string accion)
        {
            NodoPila nuevo = new NodoPila();
            nuevo.accion = accion;
            nuevo.siguiente = cima;
            cima = nuevo;
        }

        public void Mostrar()
        {
            NodoPila temp = cima;
            while (temp != null)
            {
                Console.WriteLine("- " + temp.accion);
                temp = temp.siguiente;
            }
        }
    }
}
