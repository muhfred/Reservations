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

namespace Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }

    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateReservationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Reservations.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Reservation), request.Id);
            }

            entity.CustomerName = request.CustomerName;
            entity.ReservationDate = request.ReservationDate;
            entity.Notes = request.Notes;
            entity.Done = request.Done;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
