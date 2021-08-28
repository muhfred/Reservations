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

namespace Application.Reservations.Commands.UpdateReservationDetail
{
    public class UpdateReservationDetailCommand : IRequest
    {
        public int Id { get; set; }

        public int TripId { get; set; }

        public string Notes { get; set; }
    }

    public class UpdateReservationDetailCommandHandler : IRequestHandler<UpdateReservationDetailCommand> 
    {
        private readonly IApplicationDbContext _context;

        public UpdateReservationDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateReservationDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Reservations.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Reservation), request.Id);
            }

            entity.TripId = request.TripId;
            entity.Notes = request.Notes;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
