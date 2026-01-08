namespace LlamadoLista;

public class LlamadorLista
{
    public static void IniciarLlamado()
    {
        Console.WriteLine("== Iniciando llamado lista ==");
        string[] lista = { "Kevin", "David", "Jose", "Maria", "Joseph" };
        bool[] presente = new bool[lista.Length];
        
        RegistrarLlamado(lista, presente);
        MostrarResumen(lista, presente);
    }

    public static void RegistrarLlamado(string[] lista, bool[] presente)
    {
        for (int i = 0; i < lista.Length; i++)
        {
            string respuesta;
            do
            {
                Console.Write($"{lista[i]} ¿Está presente? (s/n): ");
                respuesta = Console.ReadLine()?.Trim().ToLower();
            } 
            while (respuesta != "s" && respuesta != "n");

            presente[i] = respuesta == "s";
        }
    }

    public static void MostrarResumen(string[] lista, bool[] presente)
    {
        int contador = 0;
        for (int i = 0; i < lista.Length; i++)
        {
            string estado = presente[i] ? "Presente" : "Ausente";
            Console.WriteLine($"{lista[i]} está {estado}");
            if (presente[i]) contador++;
        }

        double porcentaje = (double)contador / lista.Length * 100.0;
        Console.WriteLine($"Porcentaje de asistencia: {porcentaje:F2}%");
    }
}