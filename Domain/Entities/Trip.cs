using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Trip : AuditableEntity
    {
        public int Id { get; set; }
        public string TripName { get; set; }
        public string CityName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public List<Reservation> Reservations { get; private set; } = new List<Reservation>();
    }
}
