using ef.Data;
using ef.Models;

namespace ef.Services;

public class EstudianteService
{
    private readonly AppDbContext _context;

    public EstudianteService(AppDbContext context)
    {
        _context = context;
    }

    public void InsertEstudiante(string nombre, int edad, string carrera)
    {
        var estudiante = new Estudiante
        {
            Nombre = nombre,
            Edad = edad,
            Carrera = carrera
        };
        _context.Estudiantes.Add(estudiante);
        _context.SaveChanges();
    }

    public List<Estudiante> GetEstudiantes()
    {
        return _context.Estudiantes.ToList();
    }
}