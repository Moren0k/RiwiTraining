using Streaming.Domain.Models;

namespace Streaming.Domain.Interfaces;

public interface ICrud<T> where T : class
{
    void Create(Pelicula contenido);
}