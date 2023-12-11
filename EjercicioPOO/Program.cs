using EjercicioPoo.Clases;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EjercicioPoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Carga de datos
            string data = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"data.json")   );

            #endregion
           
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
            List <Libro> biblioteca = JsonSerializer.Deserialize  <List<Libro>>(data, options)!;  // deserealizando a lista de objetos
            List<Alquileres> alquileres = new List<Alquileres>();  // en esta lista gurdamos los datos de clientes
            
            int seleccion;

            do
            {
                Funciones.MostrarMenu();
                if (int.TryParse(Console.ReadLine(), out seleccion))
                {
                    switch (seleccion)
                    {
                        case 1:
                            Funciones.PrestarLibro(biblioteca, alquileres );
                        break;

                        case 2:
                                Funciones.DevolverLibro(alquileres, biblioteca);
                        break;
                        
                        case 3:
                            Funciones.ListarTodos(biblioteca);
                        break;

                        case 4:
                            Funciones.ConsultarEstudiante(alquileres);
                        break;
                        case 0:
                            break;
                        break;
                    }
                }else
                {
                    Console.WriteLine("Por favor seleccione un numero");
                }
                Console.WriteLine("\n");

            } while (seleccion != 0);
            //Console.ReadLine();
            
            
          
            
            
            



            











            //Gestionar los prestamos de libros de una biblioteca
            // se debe poder prestar libros a estudiantes: 
            //  *  solo hay una copia por libro y hay que verificar a la hora de prestarlo si lo tenemos disponible o no
            // Se debe poder devolver libros 
            // Se debe poder listar todos los libros  y los que se prestaron
            // Se debe poder consultar los libros que tiene prestado un estudiante en particular 
            


        }


        
        
     
    }
}