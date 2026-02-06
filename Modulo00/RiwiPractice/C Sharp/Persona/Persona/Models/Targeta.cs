namespace Persona.Models;

public class Targeta
{
    public string? Numero { get; set; }
    public double Saldo { get; set; }

    public Targeta(string? numero, double saldo)
    {
        this.Numero = numero;
        this.Saldo = saldo;
    }
}
