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

namespace Application.Trips.Commands.UpdateTrip
{
    public class UpdateTripCommand : IRequest
    {
        public int Id { get; set; }
        public string TripName { get; set; }
        public string CityName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
    }

    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTripCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Trips.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Trip), request.Id);
            }

            entity.TripName = request.TripName;
            entity.CityName = request.CityName;
            entity.Price = request.Price;
            entity.ImageUrl = request.ImageUrl;
            entity.Content = request.Content;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
