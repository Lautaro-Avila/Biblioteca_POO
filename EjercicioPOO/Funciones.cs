using EjercicioPoo.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo
{
    public class Funciones
    {

        public static void MostrarMenu()
        {
            Console.WriteLine("*********GESTION DE LIBROS*********");
            Console.WriteLine('\n');
            Console.WriteLine("Ingrese el numero que corresponda");
            Console.WriteLine('\n');
            Console.WriteLine("1- Prestar libro.");
            Console.WriteLine("2- Devolver libros.");
            Console.WriteLine("3-Listar libros y su estado.");
            Console.WriteLine("4-Consultar por estudiante.");
            Console.WriteLine("0-Para salir.");
           


        }
        public static void PrestarLibro (List <Libro> biblioteca, List<Alquileres> alquileres) //funcion que usamos para prestar un libro.
        {
           Console.Clear();
            Console.WriteLine("Por favor seleccione el libro que desea alquilar o presione 0(cero) para salir");
            for (int i = 0; i < biblioteca.Count; i++)
            {
                if (biblioteca[i].Prestado == false) 
                {
                    Console.WriteLine($"{i+1} - {biblioteca[i].Titulo}"); //mostramos todos los titulos disponibles para alquilar 
                }

            }
            int seleccion;
            
            do
            {

              if (int.TryParse(Console.ReadLine(), out seleccion))
                {
                    if (biblioteca[seleccion - 1].Prestado == false) //validamos que este disponible
                    {
                        int dni = validarDni();
                        Alquileres alquiler = new Alquileres(); //instanciamos un objeto con las props del cliente 
                        alquiler.Dni = dni;
                        alquiler.LibroAlquilado = biblioteca[seleccion - 1];
                        alquileres.Add(alquiler); //agregamos el objeto a la lista de alquileres, que contiene datos del cliente
                        biblioteca [seleccion - 1].Prestado = true; // en la lista que contiene todos los libros cambiamos el estado del libro alquilado
                        Console.WriteLine($"Felicidades usted ha alquilado {biblioteca[seleccion - 1].Titulo}");
                    }
                    else
                    {
                        Console.WriteLine("El titulo seleccionado no se encuentra disponible, por favor seleccione uno de la lista");
                    }    
                }
                else
                {
                    Console.WriteLine("Por favor seleccione un numero");
                }
                Console.WriteLine("\n");

            } while ( seleccion != 0 );
            Console.ReadLine();
            return;


        }

        private static int validarDni() //funcion que valida que ingresemos numeros positivos en dni, le faltaria mas validaciones como por ejemplo la cantidad de caracteres etc.
        {
            int dni = -1;
            
            do
            {
                Console.WriteLine("Por favor ingrese su DNI");
                if (int.TryParse(Console.ReadLine(), out dni) && dni>0)
                {
                    return dni;

                }
                else
                {
                    dni = -1;
                    Console.WriteLine("El dni no puede contener letras");
                }
            } while (dni < 0); 
            return dni;
        
        }





        public static void DevolverLibro(List<Alquileres> alquileres, List<Libro> biblioteca) //funcion que usamos para devolver un libro a la biblioteca
        {
            Console.Clear();
            string aDevolver = null;
            int bandera = 0;
            List<string> misAlquileres = new List<string>(); // usamos esta lista de string para guardar los titulos alquilados por el cliente 
            int dni = validarDni();

            for (int i = 0; i < alquileres.Count; i++)
            {
                if (dni == alquileres[i].Dni)
                {
                    misAlquileres.Add(alquileres[i].LibroAlquilado.Titulo);
                    bandera++;
                    Console.WriteLine($"{bandera} - {alquileres[i].LibroAlquilado.Titulo}");
                }
            }

            if (bandera == 0)
            {
                Console.WriteLine("El DNI no posee alquileres");
                return;
            }

            Console.WriteLine("Seleccione libro a devolver");

            int seleccion;
            bool conversion = false;

            while (conversion == false)
            {
                conversion = int.TryParse(Console.ReadLine(), out seleccion);

                if (conversion)
                {
                    if (seleccion >= 1 && seleccion <= misAlquileres.Count)
                    {
                        aDevolver = misAlquileres[seleccion - 1];
                    }
                    else
                    {
                        conversion = false; 
                        Console.WriteLine("Opción incorrecta, por favor vuelva a introducir el libro a devolver");
                    }
                }
                else
                {
                    Console.WriteLine("Opción incorrecta, por favor vuelva a introducir el libro a devolver");
                }
            }

            for (int i = 0; i < alquileres.Count; i++) //mapea la lista de alquileres
            {
                if ( aDevolver == alquileres[i].LibroAlquilado.Titulo) // 
                {
                    misAlquileres.RemoveAt(i);
                    biblioteca[i].Prestado = false;
                    Console.WriteLine("Libro devuelto con exito");                                           
                
                }


            }
            //for (int i = 0; i < alquileres.Count; i++)
            //{
            //    if (aDevolver == biblioteca[i].Titulo)
            //    {
            //        biblioteca[i].Prestado = false;                                           

            //    }


            //}
        }

        public static void ListarTodos(List<Libro> biblioteca) //con esta funcion recorremos la biblioteca y mostramos todos los libros y sus estados
        {   Console.Clear();
            for (int i = 0;i < biblioteca.Count;i++)
            {
                Console.WriteLine($"Titulo: {biblioteca[i].Titulo} ------- Prestado: {biblioteca[i].Prestado}");
                
            }
            return;
        }


        public static void ConsultarEstudiante(List<Alquileres> alquileres) // esta funcion sonsulta por dni de alumno si tiene algun libro alquilado
        {
            Console.Clear();
            bool bandera = true;
            int dni = validarDni();
            for (int i = 0; i < alquileres.Count; i++)
            {
                if (dni == alquileres[i].Dni)
                {
                    bandera = false;
                    Console.WriteLine($"libro alquilado:  {alquileres[i].LibroAlquilado.Titulo}");
                }
                
            }
            if (bandera)
            {
                Console.WriteLine("No posee libros alquilados");
            }


        }


        
       
    
    }


}
