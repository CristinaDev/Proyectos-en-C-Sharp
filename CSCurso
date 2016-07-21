using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso
{
    class CSCurso
    {
        public string nombreCurso; //Nombre del curso actual.
        string[,] listadoAlumnos = new string[30, 2]; //Listado de alumnos actuales.
        int numero; //Número de alumnos que tendremos registrados.

        public CSCurso(string nombre)
        {
            nombreCurso = nombre;
            numero = 0;
        }

        public CSCurso()
        {
            nombreCurso = "Sin definir";
            numero = 0;
        }

        /// <summary>
        ///     Método que nos permite insertar un alumno.
        /// </summary>
        /// <returns>
        ///     Devolverá TRUE cuando se haya insertado, devolverá FALSE si ha habido algún problema.
        /// </returns>
        public bool insertarAlumno()
        {
            bool alumnoInsertado = true;

            //Si podemos añadir alumnos para este curso, añadimos. En caso contrario salimos.
            if(numero >= 30)
            {
                alumnoInsertado = false;
            }
            else
            {
                string nombre = "";
                string sexo = "";

                Console.Write("Introduzca el nombre del alumno: ");
                nombre = Console.ReadLine();
                if(nombre.Length > 0)
                {
                    Console.Write("Introduzca su género (H/M): ");
                    sexo = Console.ReadLine();
                    if(sexo.Length > 0)
                    {
                        listadoAlumnos[numero, 0] = nombre;
                        listadoAlumnos[numero, 1] = sexo;

                        numero++;
                    }
                    else
                    {
                        alumnoInsertado = false;
                    }
                }
                else
                {
                    alumnoInsertado = false;
                }
                
            }

            return (alumnoInsertado);
        }

        /// <summary>
        ///     Método que nos permite calcular el porcentaje de chicos y chicas de un curso.
        /// </summary>
        public void calcularPorcentaje()
        {
            //Comprobamos que tenemos alumnos.
            if(numero > 0)
            {
                int contador = 0;
                int totalAlumnos = numero;
                int cantidadChicos = 0;
                int cantidadChicas = 0;

                for(contador = 0; contador < numero; contador++)
                {
                    if(listadoAlumnos[contador, 1] == "H")
                    {
                        cantidadChicos++;
                    }
                    else
                    {
                        if(listadoAlumnos[contador, 1] == "M")
                        {
                            cantidadChicas++;
                        }
                    }
                }

                int porcentajeChicos = 0;
                int porcentajeChicas = 0;

                porcentajeChicos = (cantidadChicos * 100) / totalAlumnos;
                porcentajeChicas = (cantidadChicas * 100) / totalAlumnos;

                Console.WriteLine("Porcentaje de chicos: {0}%", porcentajeChicos);
                Console.WriteLine("Porcentaje de chicas: {0}%", porcentajeChicas);
            }
            else
            {
                Console.WriteLine("No hay alumnos en este curso.");
            }
        }
    }
}
