using ddd.Events;
using ddd.SharedKernel;
using System;

namespace ddd.Domain
{
    public class Dron : Entity
    {
        public string Name { get; private set; }
        public DronStatus Status { get; private set; }

        private Dron()
        {

        }

        public static Dron Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            var dronId = Guid.NewGuid();

            var dron = new Dron()
            {
                Id = dronId,
                Name = name,
                Status = DronStatus.New
            };
            dron.AddDomainEvent(new DronSubscribedToExternalSystem
            {
                DronId = dron.Id
            });

            return dron;
        }

        public static Dron Update(Guid dronId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (dronId == default(Guid))
            {
                throw new ArgumentNullException(nameof(dronId));
            }

            return new Dron()
            {
                Id = dronId,
                Name = name
            };
        }

        /*private readonly List<Locations> locations;
        public IReadOnlyCollection<Locations> Locations => locations.AsReadOnly();*/

    }
}
