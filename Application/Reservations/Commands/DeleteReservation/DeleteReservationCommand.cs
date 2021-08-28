using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteReservationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Reservations.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Reservation), request.Id);
            }

            _context.Reservations.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
