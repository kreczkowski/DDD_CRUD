using System.Linq;
using ddd.Domain;
using ddd.Infrastructure;

namespace ddd.Specifications
{
    public class ActiveDronSpecification : BaseSpecification<Dron>
    {
        public ActiveDronSpecification()
        {
            Criteria = s => s.Status == DronStatus.Active;
        }
    }

    public static class DronExtension
    {
        public static IQueryable<Dron> GetActiveSubscriptions(this IQueryable<Dron> query)
        {
            return query.Where(new ActiveDronSpecification());
        }
    }
}
