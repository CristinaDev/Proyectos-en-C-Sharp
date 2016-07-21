using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso;

namespace Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            int posicion = 0; //Posición que nos permitirá recorrer el listado de cursos.
            string respuestaCurso = ""; //Respuesta que permitirá continuar insertando datos respecto a los cursos.
            string respuestaAlumno = ""; //Respuesta que permitirá continuar insertando datos respecto a los alumnos.
            string nombreCurso = ""; //Nombre del curso que utilizaremos para insertar o buscar.
            bool cursoEncontrado = false; //Nos indicará si el curso existe o no.
            bool continuar = true; //Nos permitirá continuar ejecutando el programa o no.
            ConsoleKeyInfo opcion;
            List<Curso.CSCurso> listadoCursos = new List<CSCurso>(); //Listado dinámico de los cursos almacenados.

            while(continuar)
            {
                Console.Clear();
                Console.WriteLine("Opciones:");
                Console.WriteLine("[1] Crear curso nuevo.");
                Console.WriteLine("[2] Registrar alumnos.");
                Console.WriteLine("[3] Calcular porcentaje.");
                Console.WriteLine("[4] Listar cursos.");
                Console.WriteLine("[0] Salir del programa.");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadKey();

                switch (opcion.KeyChar)
                {
                    case '1':
                        nombreCurso = "";
                        respuestaCurso = "S";

                        while(respuestaCurso == "S")
                        {
                            Console.Clear();
                            Console.Write("Introduza el nombre del curso: ");
                            nombreCurso = Console.ReadLine();

                            //Si el nombre del curso tiene información, lo creamos y lo almacenamos en el listado.
                            if(nombreCurso.Length > 0)
                            {
                                Curso.CSCurso nuevoCurso = new CSCurso(nombreCurso);

                                listadoCursos.Add(nuevoCurso);
                            }
                            else
                            {
                                Console.WriteLine("El curso no era válido.");
                            }

                            Console.Write("¿Quiere crear un nuevo curso? (S/N): ");
                            respuestaCurso = Console.ReadLine();
                        }

                        Console.WriteLine();
                        Console.Write("Presione una tecla para volver al menú principal. ");
                        Console.ReadLine();
                        break;
                    case '2':
                        respuestaCurso = "S";

                        while (respuestaCurso == "S")
                        {
                            posicion = 0;
                            cursoEncontrado = false;

                            Console.Clear();
                            Console.Write("Nombre del curso al que pertenece el alumno: ");
                            nombreCurso = Console.ReadLine();

                            if(nombreCurso.Length > 0)
                            {
                                //Mientras no encontremos el curso seguiremos buscando.
                                while ((posicion < listadoCursos.Count) && (!cursoEncontrado))
                                {
                                    //Si el curso existe, pedimos los datos del alumno y lo almacenamos.
                                    if (listadoCursos[posicion].nombreCurso == nombreCurso)
                                    {
                                        respuestaAlumno = "S";

                                        Console.Clear();
                                        while (respuestaAlumno == "S")
                                        {
                                            if (listadoCursos[posicion].insertarAlumno())
                                            {
                                                Console.WriteLine("Se ha registrado el alumno con éxito en el curso: " + nombreCurso);
                                                cursoEncontrado = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error al registrar el alumno.");
                                            }

                                            Console.WriteLine();
                                            Console.Write("¿Quiere registrar un nuevo alumno en el curso actual? (S/N): ");
                                            respuestaAlumno = Console.ReadLine();
                                        }
                                    }

                                    posicion++;
                                }

                                //Si no hemos encontrado el curso, avisamos de que no existe.
                                if(!cursoEncontrado)
                                {
                                    Console.WriteLine("El curso seleccionado no existe.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("El curso no era válido.");
                            }

                            Console.Write("¿Quiere registrar alumnos en un nuevo curso? (S/N): ");
                            respuestaCurso = Console.ReadLine();
                        }

                        Console.WriteLine();
                        Console.Write("Presione una tecla para volver al menú principal. ");
                        Console.ReadLine();
                        break;
                    case '3':
                        respuestaCurso = "S";

                        while(respuestaCurso == "S")
                        {
                            Console.Clear();
                            Console.Write("Nombre del curso del que se quiere sacar el porcentaje: ");
                            nombreCurso = Console.ReadLine();
                            
                            if(nombreCurso.Length > 0)
                            {
                                posicion = 0;
                                cursoEncontrado = false;

                                //Buscamos el curso, si existe calculamos su porcentaje.
                                while((posicion < listadoCursos.Count) && (!cursoEncontrado))
                                {
                                    if(listadoCursos[posicion].nombreCurso == nombreCurso)
                                    {
                                        listadoCursos[posicion].calcularPorcentaje();

                                        cursoEncontrado = true;
                                    }

                                    posicion++;
                                }

                                //Si no hemos encontrado el curso, avisamos de que no existe.
                                if(!cursoEncontrado)
                                {
                                    Console.WriteLine("El curso seleccionado no existe.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("El curso no era válido.");
                            }

                            Console.Write("¿Quiere calcular el porcentaje de otro curso? (S/N): ");
                            respuestaCurso = Console.ReadLine();
                        }

                        Console.WriteLine();
                        Console.Write("Presione una tecla para volver al menú principal. ");
                        Console.ReadLine();
                        break;
                    case '4':
                        Console.Clear();

                        //Mostramos todos los cursos insertados.
                        if(listadoCursos.Count > 0)
                        {
                            Console.WriteLine("Listado de cursos registrados: ");

                            foreach(Curso.CSCurso curso in listadoCursos)
                            {
                                Console.WriteLine("- " + curso.nombreCurso);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se han insertado cursos.");
                            
                        }

                        Console.WriteLine();
                        Console.Write("Presione una tecla para volver al menú principal. ");
                        Console.ReadLine();
                        break;
                    case '0':
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("No se esperaba esa opción.");
                        Console.WriteLine();
                        Console.Write("Presione una tecla para continuar. ");
                        Console.ReadLine();
                        break;
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ha salido del programa con éxito.");

            Console.WriteLine();
            Console.Write("Presione una tecla para finalizar. ");
            Console.ReadLine();
        }
    }
}
