static void Main(string[] args)
{
    int numero = 0;

    Console.Write("Introduce un número: ");
    if(Int32.TryParse(Console.ReadLine(), out numero))
    {
        if(numero != 0)
        {
            List<int> divisores = new List<int>(); //Lista en la que almacenaremos todos los divisores.
            int contador = 0;
            int divisor = 0;

            //Calculamos todos los divisores.
            for (contador = 1; contador <= numero; contador++)
            {
                divisor = numero % contador;

                if (divisor == 0)
                {
                    divisores.Add(contador);
                }
            }

            //Podemos mostrar o no por pantalla los resultados almacenados.
            Console.WriteLine("Divisores de {0}: ", numero);
            foreach (int elemento in divisores)
            {
                Console.WriteLine("{0}", elemento);
            }
        }
        else
        {
            Console.WriteLine("Resultado indefinido.");
        }
    }
    else
    {
        Console.WriteLine("Se esperaba un número entero.");
    }

    Console.WriteLine();
    Console.ReadKey();
}
