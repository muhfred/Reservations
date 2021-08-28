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
    public class ReservationCreatedEventHandler : INotificationHandler<DomainEventNotification<ReservationCreatedEvent>>
    {
        private readonly ILogger<ReservationCreatedEventHandler> _logger;

        public ReservationCreatedEventHandler(ILogger<ReservationCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<ReservationCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Reservation Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
