using ddd.Domain;
using ddd.Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ddd.Commands.CreateDron
{
    public class CreateDronHandlerHandler : IRequestHandler<CreateDronRequest, CreateDronResponse>
    {
        private readonly IDronRepository dronRepository;

        public CreateDronHandlerHandler(IDronRepository dronRepository)
        {
            this.dronRepository = dronRepository;
        }

        public async Task<CreateDronResponse> Handle(CreateDronRequest request, CancellationToken cancellationToken)
        {
            var dron = Dron.Create(request.DronName);

            await dronRepository.SaveAsync(dron);

            return CreateDronResponse.Create(dron.Id, dron.Name);
        }
    }
}
