using MediatR;
using System;

namespace ddd.Commands.CreateDron
{
    public class CreateDronRequest : IRequest<CreateDronResponse>
    {
        public string DronName { get; set; }
    }
}
