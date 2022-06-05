using ddd.Services;
using ddd.SharedKernel;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ddd.Events
{
    public class DronSubscribedToExternalSystem : IDomainEvent
    {
        public Guid DronId { get; set; }        
    }

    public class CustomerSubscribedToProductHandler : INotificationHandler<DronSubscribedToExternalSystem>
    {
        private readonly IExternalSystemServices externalSystemServices;

        public CustomerSubscribedToProductHandler(IExternalSystemServices externalSystemServices)
        {
            this.externalSystemServices = externalSystemServices ?? throw new ArgumentNullException(nameof(externalSystemServices));
        }

        public Task Handle(DronSubscribedToExternalSystem notification, CancellationToken cancellationToken)
        {
            externalSystemServices.SendEventToExternalApi("send event to .... ");
            return Task.CompletedTask;
        }
    }
}
