using Application.Common.Models;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.EventHandlers
{
    public class ReservationCompletedEventHandler : INotificationHandler<DomainEventNotification<ReservationCompletedEvent>>
    {
        private readonly ILogger<ReservationCompletedEventHandler> _logger;

        public ReservationCompletedEventHandler(ILogger<ReservationCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<ReservationCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Reservation Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
