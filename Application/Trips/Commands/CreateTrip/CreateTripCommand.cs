using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Trips.Commands.CreateTrip
{
    public class CreateTripCommand : IRequest<int>
    {
        public string TripName { get; set; }
        public string CityName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
    }

    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTripCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var entity = new Trip
            {
                TripName = request.TripName,
                CityName = request.CityName,
                Price = request.Price,
                ImageUrl = request.ImageUrl,
                Content = request.Content
            };

            _context.Trips.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
