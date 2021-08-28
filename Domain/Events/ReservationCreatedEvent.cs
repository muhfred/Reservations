using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class ReservationCreatedEvent : DomainEvent
    {
        public ReservationCreatedEvent(Reservation reservation)
        {
            Reservation = reservation;
        }

        public Reservation Reservation { get; }
    }
}
