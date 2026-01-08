using System;

public class Program
{
    static void Main(string[] args)
    {
        // Calificador de notas
        Console.WriteLine("Please enter your grade: ");
        double grade = double.Parse(Console.ReadLine());

            string result = (grade < 0 || grade > 100) ? "Invalid grade":
                grade >= 90 ? "Excellent!" :
                grade >= 50 ? "Very Good!" :
                grade >= 30 ? "Good!" :
                "Bad!";
            Console.WriteLine(result);
    }
}