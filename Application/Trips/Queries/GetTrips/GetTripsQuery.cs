using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Trips.Queries.GetTrips
{
    public class GetTripsQuery : IRequest<TripsVm>
    {

    }

    public class GetTripsQueryHandler : IRequestHandler<GetTripsQuery, TripsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetTripsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TripsVm> Handle(GetTripsQuery request, CancellationToken cancellationToken)
        {
            return new TripsVm
            {
                Trips = await _context.Trips
                    .AsNoTracking()
                    .ProjectTo<TripDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.TripName)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
