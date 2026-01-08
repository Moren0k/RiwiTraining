using ShopWeb.Models;

namespace ShopWeb.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync(); // Obtener todos
    Task<User?> GetByIdAsync(int id); // Obtener por ID
    Task AddAsync(User user); // Agregar
    Task UpdateAsync(User user); // Actualizar
    Task DeleteAsync(int id); // Eliminar
}