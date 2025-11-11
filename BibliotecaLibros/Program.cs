using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace BiliotecaLibros_t3
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
            catalogo.Agregar("Los ríos profundos", "José María Arguedas");
            catalogo.Agregar("El Sexto", "José María Arguedas");
            catalogo.Agregar("La casa verde", "Mario Vargas Llosa");
            catalogo.Agregar("Conversación en La Catedral", "Mario Vargas Llosa");
            catalogo.Agregar("Pantaleón y las visitadoras", "Mario Vargas Llosa");
            catalogo.Agregar("El pez en el agua", "Mario Vargas Llosa");
            catalogo.Agregar("Redoble por Rancas", "Manuel Scorza");
            catalogo.Agregar("Garabombo el invisible", "Manuel Scorza");
            catalogo.Agregar("Historia de Mayta", "Mario Vargas Llosa");
            catalogo.Agregar("Yawar Fiesta", "José María Arguedas");
            catalogo.Agregar("Todas las sangres", "José María Arguedas");
            catalogo.Agregar("Los perros hambrientos", "Ciro Alegría");
            catalogo.Agregar("El mundo es ancho y ajeno", "Ciro Alegría");
            catalogo.Agregar("Duque", "José Diez Canseco");
            catalogo.Agregar("El Tungsteno", "César Vallejo");

            //Insertar en el árbol
            arbol.Insertar(ref arbol.raiz, "Los ríos profundos", "José María Arguedas");
            arbol.Insertar(ref arbol.raiz, "El Sexto", "José María Arguedas");
            arbol.Insertar(ref arbol.raiz, "La casa verde", "Mario Vargas Llosa");
            arbol.Insertar(ref arbol.raiz, "Conversación en La Catedral", "Mario Vargas Llosa");
            arbol.Insertar(ref arbol.raiz, "Pantaleón y las visitadoras", "Mario Vargas Llosa");
            arbol.Insertar(ref arbol.raiz, "El pez en el agua", "Mario Vargas Llosa");
            arbol.Insertar(ref arbol.raiz, "Redoble por Rancas", "Manuel Scorza");
            arbol.Insertar(ref arbol.raiz, "Garabombo el invisible", "Manuel Scorza");
            arbol.Insertar(ref arbol.raiz, "Historia de Mayta", "Mario Vargas Llosa");
            arbol.Insertar(ref arbol.raiz, "Yawar Fiesta", "José María Arguedas");
            arbol.Insertar(ref arbol.raiz, "Todas las sangres", "José María Arguedas");
            arbol.Insertar(ref arbol.raiz, "Los perros hambrientos", "Ciro Alegría");
            arbol.Insertar(ref arbol.raiz, "El mundo es ancho y ajeno", "Ciro Alegría");
            arbol.Insertar(ref arbol.raiz, "Duque", "José Diez Canseco");
            arbol.Insertar(ref arbol.raiz, "El Tungsteno", "César Vallejo");

            // Recomendados del mes (Lista circular)
            recomendados.Agregar("Los ríos profundos - José María Arguedas");
            recomendados.Agregar("Rosa Cuchillo - Óscar Colchado Lucio");
            recomendados.Agregar("La casa verde - Mario Vargas Llosa");
            recomendados.Agregar("Un mundo para Julius - Alfredo Bryce Echenique");
            recomendados.Agregar("Abril rojo - Santiago Roncagliolo");

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
<<<<<<< HEAD
    
=======

>>>>>>> 9e953730458a6f28b52ab556f9f71f59dd1ec510
    }
}

