using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips.Queries.GetTrips
{
    public class ReservationDto : IMapFrom<Reservation>
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public int TripId { get; set; }
        public bool Done { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Reservation, ReservationDto>();
        }
    }
}
