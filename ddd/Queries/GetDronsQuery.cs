using ddd.Data;
using ddd.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ddd.Queries
{
    public class GetDronsQuery : IRequest<List<GetActiveDronsResponse>>
    {
    }

    public class GetActiveDronsResponse
    {
        public Guid DronId { get; set; }        
        public string DronName { get; set; }        
    }

    public class GetActiveSubscriptionsQueryHandler
        : IRequestHandler<GetDronsQuery, List<GetActiveDronsResponse>>
    {
        private readonly DronContext _context;

        public GetActiveSubscriptionsQueryHandler(DronContext context)
        {
            _context = context;
        }
        public async Task<List<GetActiveDronsResponse>> Handle(GetDronsQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _context.Drons
                .GetActiveSubscriptions()
                .Select(x => new GetActiveDronsResponse
                {
                    DronId = x.Id,
                    DronName = x.Name
                })
                .ToListAsync(cancellationToken);
            return queryResult;
        }
    }
}