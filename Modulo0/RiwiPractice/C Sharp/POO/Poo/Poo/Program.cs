namespace Poo;

public static class Program
{
    public static void Main()
    {
        var gerrero = new Herencia.Guerrero("kevin", 50, 90, 60, 100, 10, "Oro");
        Herencia.Mago mago1 = new Herencia.Mago(10, "Volar");
        mago1.Libro();
        gerrero.Turno();
    }
}