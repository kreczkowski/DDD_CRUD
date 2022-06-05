using System;
using System.Threading.Tasks;

namespace ddd.Domain.Repository
{
    public interface IDronRepository
    {
        Task<Dron> SaveAsync(Dron dron);
        Task DeleteAsync(Guid dronId);
        bool IsDroneExists(Dron dron);
    }
}
