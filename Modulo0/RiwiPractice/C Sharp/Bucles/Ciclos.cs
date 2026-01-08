namespace ConsoleApp1;

public class Ciclos
{
    public static void ciclos()
    {
        for (int i = 0; i < 10; i++) /*Para un entero i que comienza en 0,
                                        mientras i sea menor que 10,
                                        incrementa i en 1 en cada vuelta y ejecuta el bloque de código.*/
        {
            Console.WriteLine(i);
        }
        
        // Recorrer notas
        int [] notas = {10,20,30,40,50};
        for (int i = 0; i < notas.Length; i++)
        {
            Console.WriteLine(notas[i]);
        }
        foreach (int i in notas) // Recorrer notas con foreach
        {
            Console.WriteLine($"Foreach i in notas: {i}");
        }
        
        // Contar del 1 al 5
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(i);
        }
        
        // Contar de 2 en 2 hata 20
        /*Para un entero i que empieza en 0, mientras i sea menor o igual a 20, ve aumentando i de 2 en 2 y en cada paso imprime el valor de i*/
        for (int i = 0; i <= 20; i += 2)
        {
            Console.WriteLine($"Contar {i}");
        }
        
        // Decremento de 2 en 2 hasta 0
        /*Para un entero i que empieza en 50, mientras i sea mayor o igual a 0, ve restando i de 2 en 2 y en cada paso imprime el valor de i*/
        for (int i = 50; i >= 0; i -= 2)
        {
            Console.WriteLine($"Decremento {i}");
        }
        
        // Contar de 3 en 3, e imprimir par o impar
        for (int i = 0; i <= 50; i += 3)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
            }
        } // Con ternario
        for (int i = 0; i <= 50; i += 3)
        {
            Console.WriteLine(i % 2 == 0 ? $"{i} es PAR" : $"{i} es IMPAR");
        }
    }
}