using Application.Common.Interfaces;
using Application.Common.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Trips.Commands.PurgeTrip
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public class PurgeTripCommand : IRequest
    {
        
    }

    public class PurgeTripCommandHandler : IRequestHandler<PurgeTripCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgeTripCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PurgeTripCommand request, CancellationToken cancellationToken)
        {
            _context.Trips.RemoveRange(_context.Trips);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
