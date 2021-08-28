using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<int>
    {
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public int TripId { get; set; }
    }

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateReservationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Reservation
            {
                CustomerName = request.CustomerName,
                ReservationDate = request.ReservationDate,
                Notes = request.Notes,
                TripId = request.TripId,
                Done = false
            };

            entity.DomainEvents.Add(new ReservationCreatedEvent(entity));

            _context.Reservations.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }
    }
}
