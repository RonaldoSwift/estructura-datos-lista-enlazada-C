using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_ESTRUCTURA_DE_DATOS {

    internal class Program {

        static void Main(string[] args)
        {
            Nodo raiz = null;
            string nombre = "";
            string codigoString = "";
            int codigoNumero = 0;
            string correo = "";


            int opcion;
            do
            {
                Console.WriteLine("\n\n************************************************");
                Console.WriteLine("*                 MENU DE OPCIONES             *");
                Console.WriteLine("************************************************");
                Console.WriteLine("*      1)Agregar Nodo                          *");
                Console.WriteLine("*      2)Mostrar todos los Nodos               *");
                Console.WriteLine("*      3)Ordenar Nodo (De forma ascendente)    *");
                Console.WriteLine("*      4)Eliminar Nodo                         *");
                Console.WriteLine("************************************************");
                Console.WriteLine("\nElija una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        

                        // pedimos datos al usuario
                        Console.Clear();
                        Console.WriteLine("  AGREGANDO ESTUDIANTE");
                        Console.WriteLine("Ingrese Nombre: ");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese Codigo de Estudiante: ");
                        codigoString = Console.ReadLine();
                        codigoNumero = obtenerCodigo(codigoString);
                        Console.WriteLine("Ingrese Correo: ");
                        correo = Console.ReadLine();

                        // creamos al estudiante
                        Estudiante estudianteaAgregar = new Estudiante(codigoNumero, nombre, correo);

                        // agregamos el estudiante a la lista enlazada
                         insertarEstudiante(ref raiz, estudianteaAgregar);
                        break;
                    case 2:

                        mostrarListaDeEstudiantes(ref raiz);
                        break;
                    case 3:
                        ordenarListaDeEstudiantes(ref raiz);
                        break;
                    case 4:

                        Console.Clear();
                        Console.WriteLine("   Eliminar Nodo   ");
                        Console.WriteLine("Ingrese Nombre: ");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese Codigo de Estudiante: ");
                        codigoString = Console.ReadLine();
                        codigoNumero = obtenerCodigo(codigoString);



                        Console.WriteLine("Ingrese Correo: ");
                        correo = Console.ReadLine();
                        Estudiante estudianteAEliminar = new Estudiante(codigoNumero, nombre, correo);


                        eliminarEstudiante(ref raiz, estudianteAEliminar);
                        break;
                    default:
                        Console.WriteLine("El numero Ingresado es incorrecto...");
                        break;
                }
            } while (opcion != 0);

        }


        static void insertarEstudiante(ref Nodo raiz, Estudiante data) {
            Nodo nuevo = new Nodo(data, null);
            Nodo tmp = new Nodo();

            if (raiz == null)
            {
                raiz = nuevo;
            }
            else
            {
                tmp = raiz;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = nuevo;
            }
        }

        static void mostrarListaDeEstudiantes(ref Nodo raiz)
        {
            int cantidadTotal = 0;
            Nodo tmp = raiz;
            if (tmp == null)
            {
                Console.WriteLine("La lista esat vacia");
                return;
            }
            while (tmp != null)
            {
                // logica para mostrar la flecha en la consla de manera correcta
                if (cantidadTotal != 0) {
                    Console.Write("\t-->\t");
                }

                Console.Write("Estudiante " + (cantidadTotal + 1) + " ( ");
                Console.Write("Nombre: " + tmp.Data.nombre);
                Console.Write(", Codigo: N00" + tmp.Data.codigo);
                Console.Write(", Correo: " + tmp.Data.correo + " ) ");
                tmp = tmp.Next;
                cantidadTotal++;
            }

            Console.WriteLine("\nEl total es: " + cantidadTotal);
        }


        static void ordenarListaDeEstudiantes(ref Nodo raiz)
        {
            bool cambio;
            do
            {
                cambio = false;
                Nodo ant = null;
                Nodo act = raiz;
                Nodo sig = raiz.Next;
                while (sig != null)
                {
                    if (act.Data.codigo > sig.Data.codigo) // similar al compareTo de la lista simple
                    {
                        //necesitamos cambiar
                        cambio = true;
                        Nodo sig_sig = sig.Next;
                        if (ant != null)
                        {
                            //Caso 2: cuando actual no es igual
                            ant.Next = sig;
                        }
                        else
                        {
                            //caso 1: cuando actual es igual a la raiz
                            raiz = sig;
                        }
                        sig.Next = act;
                        act.Next = sig_sig;
                        ant = sig;
                        sig = act.Next;
                    }
                    else
                    {
                        //necesitamos avanzar los 3 punteros
                        ant = act;
                        act = sig;
                        sig = sig.Next;
                    }
                }
            } while (cambio);
        }

        static void eliminarEstudiante(ref Nodo raiz, Estudiante data)
        {

            Nodo tmp = raiz;
            Nodo aux = raiz;
            bool eliminado = false;
            int contador = 0;

            if (tmp == null)
            {
                Console.WriteLine("La lista esta vacia");
                return;
            }
            while (tmp != null)
            {
                if (tmp.Data.codigo == data.codigo) // similar al equals de la lista simple
                {
                    //Encontre el dato a eliminar, verificar si estamos en la raiz o no
                    if (tmp == raiz)
                    {
                        raiz = tmp.Next;
                    }
                    else
                    {
                        int i = 0;
                        while (i < contador - 1)
                        {
                            aux = aux.Next;
                            i++;
                        }
                        aux.Next = tmp.Next;
                    }
                    tmp = null;
                    eliminado = true;
                    break;
                }
                tmp = tmp.Next;
                contador++;
            }
            if (eliminado)
            {
                Console.WriteLine("Informacion eliminada");
            }
            else
            {
                Console.WriteLine("No se encontro el dato a eliminar");
            }
        }

        //Funcion para Obtener el Codigo Ingresado
        private static int obtenerCodigo(string codigostring)
        {
            int position = codigostring.IndexOf("N00");
            int codigonumero = int.Parse(codigostring.Substring(position + 1));
            return codigonumero;
        }
    }

 }