using Domain.Common;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Reservation : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }

        private bool _done;
        public bool Done
        {
            get => _done;
            set
            {
                if (value == true && _done == false)
                {
                    DomainEvents.Add(new ReservationCompletedEvent(this));
                }

                _done = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
