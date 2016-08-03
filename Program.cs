const int MAXNUM = 10; //Cantidad máxima de elementos del array.
            int[] numeros = new int[MAXNUM]; //Array donde almacenaremos los números insertados.
            int numero = 0;
            int contador = 0;

            //Solicitamos números hasta almacenarlos todos.
            do
            {
                numero = 0;

                Console.Clear();
                if(contador < MAXNUM)
                {
                    Console.Write("Introduce un número: ");
                    if(Int32.TryParse(Console.ReadLine(), out numero))
                    {
                        if (numero != 0)
                        {
                            numeros[contador] = numero;
                            contador++;
                        }
                    }
                    else
                    {
                        numero = 1;

                        Console.WriteLine();
                        Console.Write("Se esperaba un entero válido. ");
                        Console.ReadKey();
                    }
                }
            } while ((numero != 0) && (contador < MAXNUM));

            contador = 0;

            //Si se ha almacenado al menos un elemento.
            if(numeros[contador] != 0)
            {
                int[] numerosRepetidos = new int[MAXNUM]; //Array que nos permitirá saber qué números están repetidos.
                int[] cantidades = new int[MAXNUM]; //Array donde se almacena la cantidad de cada número respectivamente.
                int contadorRepetidos = 0;
                int contadorCantidades = 0; //Contador que almacenará la posición de cada número repetido y su cantidad.
                int cantidad = 0;
                bool numeroRepetido = false;

                //Se analizan todos los números insertados.
                while ((contador < MAXNUM) && (numeros[contador] != 0))
                {
                    numeroRepetido = false;
                    contadorRepetidos = 0;
                    cantidad = 0;

                    //Se comprueba si el número actual está repetido o no.
                    while ((!numeroRepetido) && (contadorRepetidos < MAXNUM))
                    {
                        if (numeros[contador] == numerosRepetidos[contadorRepetidos])
                        {
                            numeroRepetido = true;
                        }
                        else
                        {
                            contadorRepetidos++;
                        }
                    }

                    //Si el número actual no está repetido lo registramos como tal, si no, sumamos al contador.
                    if (!numeroRepetido)
                    {
                        cantidad = 1;

                        numerosRepetidos[contadorCantidades] = numeros[contador];
                        cantidades[contadorCantidades] = cantidad;

                        contadorCantidades++;
                    }
                    else
                    {
                        cantidades[contadorRepetidos]++;
                    }

                    contador++;
                }

                //Ordenamos los números dependiendo de las veces que han aparecido.
                int temporal = 0;
                contador = 0;

                while((contador < MAXNUM) && (numerosRepetidos[contador] != 0))
                {
                    contadorCantidades = 0;

                    while((contadorCantidades < (MAXNUM - 1)) && (cantidades[contadorCantidades] != 0))
                    {
                        if(cantidades[contadorCantidades] < cantidades[contadorCantidades + 1])
                        {
                            temporal = cantidades[contadorCantidades];
                            cantidades[contadorCantidades] = cantidades[contadorCantidades + 1];
                            cantidades[contadorCantidades + 1] = temporal;

                            temporal = numerosRepetidos[contadorCantidades];
                            numerosRepetidos[contadorCantidades] = numerosRepetidos[contadorCantidades + 1];
                            numerosRepetidos[contadorCantidades + 1] = temporal;
                        }

                        contadorCantidades++;
                    }
                    contador++;
                }

                Console.WriteLine();

                contador = 0;

                Console.Write("Números insertados: ");
                while((contador < MAXNUM) &&(numeros[contador] != 0))
                {
                    Console.Write("{0} ", numeros[contador]);

                    contador++;
                }

                Console.WriteLine();

                contador = 0;

                //Se muestran los datos almacenados.
                Console.WriteLine("Cantidades: ");

                while ((contador < MAXNUM) && (numerosRepetidos[contador] != 0))
                {
                    if (cantidades[contador] == 1)
                    {
                        Console.WriteLine("El número {0} aparece {1} vez.", numerosRepetidos[contador], cantidades[contador]);
                    }
                    else
                    {
                        Console.WriteLine("El número {0} aparece {1} veces.", numerosRepetidos[contador], cantidades[contador]);
                    }

                    contador++;
                }
            }

            Console.WriteLine();
            Console.ReadKey();
