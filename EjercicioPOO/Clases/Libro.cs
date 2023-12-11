using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo.Clases
{
    public class Libro
    {
        public Libro(string? titulo, string? autor, string? descrpcion, bool prestado)
        {
            Titulo = titulo;
            Autor = autor;
            Descrpcion = descrpcion;
            Prestado = prestado;
        }

        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Descrpcion { get; set; }
        public bool Prestado { get; set; }
    }
}
