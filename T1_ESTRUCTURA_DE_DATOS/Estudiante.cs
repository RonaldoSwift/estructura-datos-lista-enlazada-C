using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_ESTRUCTURA_DE_DATOS
{
    internal class Estudiante
    {
        public int codigo;
        public string nombre;
        public string correo;

        public Estudiante(int codigo, string nombre, string correo)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.correo = correo;
        }
    }
}
