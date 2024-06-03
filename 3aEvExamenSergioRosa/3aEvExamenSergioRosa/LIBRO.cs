using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3aEvExamenSergioRosa
{
    public class LIBRO
    {
        private string titulo;
        private string autor;
        private string anyoPublicacion;


        public LIBRO()
        {
            this.titulo = "";
            this.autor = "";
            this.anyoPublicacion= "";
        }
        public LIBRO(string titulo, string autor,string anyoPublicacion)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anyoPublicacion= anyoPublicacion;
        }
        public LIBRO(LIBRO libro)
        {
            this.titulo = libro.Titulo;
            this.autor = libro.Autor;
            this.anyoPublicacion = libro.AnyoPublicacion;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string AnyoPublicacion { get => anyoPublicacion; set => anyoPublicacion = value; }




    }
}
