using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Bicola
    {
        public NodoBicola inicio, fin;

        public void AgregarInicio(string usuario)
        {
            NodoBicola nuevo = new NodoBicola();
            nuevo.usuario = usuario;
            if (inicio == null)
                inicio = fin = nuevo;
            else
            {
                nuevo.siguiente = inicio;
                inicio = nuevo;
            }
        }

        public void AgregarFinal(string usuario)
        {
            NodoBicola nuevo = new NodoBicola();
            nuevo.usuario = usuario;
            if (inicio == null)
                inicio = fin = nuevo;
            else
            {
                fin.siguiente = nuevo;
                fin = nuevo;
            }
        }

        public void Mostrar()
        {
            NodoBicola temp = inicio;
            while (temp != null)
            {
                Console.WriteLine("- " + temp.usuario);
                temp = temp.siguiente;
            }
        }
    }
}
