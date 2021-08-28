using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips.Queries.GetTrips
{
    public class TripDto
    {
        public TripDto()
        {
            Reservations = new List<ReservationDto>();
        }
        public int Id { get; set; }
        public string TripName { get; set; }
        public string CityName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public List<ReservationDto> Reservations { get; set; }
    }
}
