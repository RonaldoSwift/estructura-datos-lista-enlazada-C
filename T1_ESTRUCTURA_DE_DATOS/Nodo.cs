using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_ESTRUCTURA_DE_DATOS
{
    internal class Nodo
    {

        private Estudiante data;
        private Nodo next;

        public Nodo() { }

        public Nodo(Estudiante data, Nodo next)
        {
            this.data = data;
            this.next = next;
        }

        public Estudiante Data { get { return data; } set { data = value; } }
        public Nodo Next { get { return next; } set { next = value; } }

    }
}
