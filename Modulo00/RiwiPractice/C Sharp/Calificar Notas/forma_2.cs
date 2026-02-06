using System;

public class Program
{
    static void Main(string[] args)
    {
        // Calificador de notas
        Console.WriteLine("Please enter your grade: ");
        double grade = double.Parse(Console.ReadLine());

        if (grade >= 90)
        {
            Console.WriteLine("Excellent!");
        } else if (grade >= 50)
        {
            Console.WriteLine("Very Good!");
        } else if (grade >= 30)
        {
            Console.WriteLine("Good!");
        } else if (grade <= 30)
        {
            Console.WriteLine("Bad!");
        }
    }
}