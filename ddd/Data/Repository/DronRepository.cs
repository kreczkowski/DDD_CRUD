using ddd.Domain;
using ddd.Domain.Repository;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ddd.Data.Repository
{
    public class DronRepository: IDronRepository
    {
        private readonly DronContext dronContext;

        public DronRepository(DronContext dronContext)
        {
            this.dronContext = dronContext;
        }

        public async Task<Dron> SaveAsync(Dron dron)
        {
            await dronContext.Drons.AddAsync(dron);
            await dronContext.SaveChangesAsync();

            return dron;
        }

        public async Task DeleteAsync(Guid dronId)
        {
            var dron = dronContext.Drons.FirstOrDefault(o => o.Id == dronId);
            dronContext.Drons.Remove(dron);
            await dronContext.SaveChangesAsync();
        }

        public bool IsDroneExists(Dron dron)
        {
            return dronContext.Drons.Any(x=> x.Id ==  dron.Id);
        }
    }
}
