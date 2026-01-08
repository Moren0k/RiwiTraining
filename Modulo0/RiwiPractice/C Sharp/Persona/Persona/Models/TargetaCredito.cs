namespace Persona.Models;

public class TargetaCredito : Targeta
{
    public string TipoTargeta { get; set; }
    
    public TargetaCredito(string? numero, double saldo, string tipoTargeta) : base(numero, saldo)
    {
        this.TipoTargeta = tipoTargeta;
    }
}