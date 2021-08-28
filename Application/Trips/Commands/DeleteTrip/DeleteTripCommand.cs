using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Trips.Commands.DeleteTrip
{
    public class DeleteTripCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTripCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Trips
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Trip), request.Id);
            }

            _context.Trips.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
