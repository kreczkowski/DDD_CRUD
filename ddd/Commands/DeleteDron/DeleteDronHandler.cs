using ddd.Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ddd.Commands.CreateDron
{
    public class DeleteDronHandler : IRequestHandler<DeleteDronRequest>
    {
        private readonly IDronRepository dronRepository;

        public DeleteDronHandler(IDronRepository dronRepository)
        {
            this.dronRepository = dronRepository;
        }

        public async Task<Unit> Handle(DeleteDronRequest request, CancellationToken cancellationToken)
        {
            var dron = dronRepository.DeleteAsync(request.DronId);

            return Unit.Value;
        }
    }
}
