using Streaming.Data;
using Streaming.Domain.Interfaces;
using Streaming.Domain.Models;

namespace Streaming.Services;

public class PeliculaServices : ICrud<Pelicula>
{
    private readonly AppDbContext _context;

    public PeliculaServices(AppDbContext context)
    {
        _context = context;
    }
    
    public void Create(Pelicula contenido)
    {
        _context.Peliculas.Add(contenido);
    }
}