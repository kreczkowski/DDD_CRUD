using MediatR;
using System;

namespace ddd.Commands.CreateDron
{
    public class DeleteDronRequest : IRequest
    {
        public Guid DronId { get; set; }
    }
}
