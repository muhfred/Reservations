using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Trips.Queries.GetTrips;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Queries.GetReservationsWithPagination
{
    public class GetReservationsWithPaginationQuery : IRequest<PaginatedList<ReservationDto>>
    {
        public int TripId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetReservationsWithPaginationQueryHandler : IRequestHandler<GetReservationsWithPaginationQuery, PaginatedList<ReservationDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetReservationsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ReservationDto>> Handle(GetReservationsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Reservations
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.ReservationDate)
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
