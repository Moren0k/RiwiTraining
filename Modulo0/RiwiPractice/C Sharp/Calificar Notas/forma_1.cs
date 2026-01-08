using System;

public class Program
{
    static void Main(string[] args)
    {
        // Calificador de notas
        Console.WriteLine("Please enter your grade: ");
        double grade = double.Parse(Console.ReadLine());

        switch (grade)
        {
            case >= 90:
                Console.WriteLine("Excellent!");
                break;
            case >= 50:
                Console.WriteLine("Very Good!");
                break;
            case >= 30:
                Console.WriteLine("Good!");
                break;
            case <= 30:
                Console.WriteLine("Bad!");
                break;
        }
    }
}