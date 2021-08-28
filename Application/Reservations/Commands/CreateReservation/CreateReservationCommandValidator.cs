using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(v => v.CustomerName).MaximumLength(200).NotEmpty();
            RuleFor(v => v.ReservationDate).NotEmpty();
        }
    }
}
