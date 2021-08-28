using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class ReservationCompletedEvent : DomainEvent
    {
        public ReservationCompletedEvent(Reservation reservation)
        {
            Reservation = reservation;
        }

        public Reservation Reservation { get; }
    }
}
