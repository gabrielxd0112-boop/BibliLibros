using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaLibros
{
    public  class Program
    {
        static void Main(string[] args)
        {
            ListaSimple usuarios = new ListaSimple();
            ListaDoble catalogo = new ListaDoble();
            ArbolLibros arbol = new ArbolLibros();
            Pila historial = new Pila();
            Cola cola = new Cola();
            Bicola bicola = new Bicola();
            ListaCircular recomendados = new ListaCircular();

            //Libros base del catálogo
            catalogo.Agregar("Cien años de soledad", "García Márquez");
            catalogo.Agregar("Don Quijote de la Mancha", "Cervantes");
            catalogo.Agregar("El Principito", "Saint-Exupéry");
            catalogo.Agregar("1984", "George Orwell");

            //Insertar en el árbol
            arbol.Insertar(ref arbol.raiz, "Cien años de soledad", "García Márquez");
            arbol.Insertar(ref arbol.raiz, "Don Quijote de la Mancha", "Cervantes");
            arbol.Insertar(ref arbol.raiz, "El Principito", "Saint-Exupéry");
            arbol.Insertar(ref arbol.raiz, "1984", "George Orwell");

            // Recomendados del mes (Lista circular)
            recomendados.Agregar("Harry Potter");
            recomendados.Agregar("El Hobbit");
            recomendados.Agregar("Los juegos del hambre");

            string usuarioActual = "";
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE BIBLIOTECA ===");
                Console.WriteLine("Usuario actual: " + (usuarioActual == "" ? "Ninguno" : usuarioActual));
                Console.WriteLine("\n1. Registrarse");
                Console.WriteLine("2. Ver catálogo de libros");
                Console.WriteLine("3. Pedir préstamo de libro");
                Console.WriteLine("4. Devolver libro");
                Console.WriteLine("5. Ver historial de acciones");
                Console.WriteLine("6. Ver lista de recomendados");
                Console.WriteLine("7. Ver solicitudes en espera");
                Console.WriteLine("8. Salir");
                Console.Write("\nSeleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese su nombre para registrarse: ");
                        usuarioActual = Console.ReadLine();
                        usuarios.Agregar(usuarioActual);
                        Console.WriteLine(" Usuario registrado correctamente.");
                        break;

                    case 2:
                        Console.WriteLine("=== CATÁLOGO DE LIBROS ===");
                        catalogo.MostrarAdelante();
                        Console.WriteLine();
                        arbol.MostrarCatalogo();
                        break;

                    case 3:
                        if (usuarioActual == "")
                        {
                            Console.WriteLine("Debe registrarse primero.");
                        }
                        else
                        {
                            Console.WriteLine("=== PEDIR PRÉSTAMO ===");
                            Console.WriteLine("Libros disponibles:");
                            catalogo.MostrarAdelante();
                            Console.Write("\nIngrese el título del libro que desea pedir: ");
                            string tituloPrestamo = Console.ReadLine();

                            // búsqueda rápida con árbol
                            Console.WriteLine("\nBuscando en la base de datos...");
                            if (ArbolLibros.BuscarLibro(arbol.raiz, tituloPrestamo))

                            {
                                historial.Apilar($" Préstamo: '{tituloPrestamo}' por {usuarioActual}");
                                Console.WriteLine(" Préstamo registrado con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Libro no disponible. Se agregó su solicitud a la cola de espera.");
                                cola.Encolar($"{usuarioActual} (espera '{tituloPrestamo}')");
                            }
                        }
                        break;

                    case 4:
                        if (usuarioActual == "")
                        {
                            Console.WriteLine("Debe registrarse primero.");
                        }
                        else
                        {
                            Console.WriteLine("=== DEVOLVER LIBRO ===");
                            Console.Write("Ingrese el título del libro a devolver: ");
                            string tituloDev = Console.ReadLine();
                            historial.Apilar($" Devolución: '{tituloDev}' por {usuarioActual}");
                            Console.WriteLine(" Devolución registrada con éxito.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("=== HISTORIAL DE ACCIONES ===");
                        historial.Mostrar();
                        break;

                    case 6:
                        Console.WriteLine("=== RECOMENDADOS DEL MES ===");
                        recomendados.Mostrar(1);
                        break;

                    case 7:
                        Console.WriteLine("=== SOLICITUDES EN ESPERA ===");
                        cola.Mostrar();
                        break;

                    case 8:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 8);
            Console.ReadKey();
        }
    
    }
}
