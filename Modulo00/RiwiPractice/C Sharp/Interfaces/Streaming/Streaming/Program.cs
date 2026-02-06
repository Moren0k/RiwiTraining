using Streaming.Data;
using Streaming.Domain.Models;
using Streaming.Services;

namespace Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();
            var dbSetPelicula = new PeliculaServices(context);

            dbSetPelicula.Create(new Pelicula
                { Clasificacion = 18, Descripcion = "miedo", IdContenido = 1, Titulo = "matilda" });
        }
    }
}