using Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips.Commands.CreateTrip
{
    public class CreateTripCommandValidator : AbstractValidator<CreateTripCommand>
    {
        public CreateTripCommandValidator()
        {
            RuleFor(v => v.TripName)
                .NotEmpty().WithMessage("Trip Name is required.")
                .MaximumLength(200).WithMessage("Trip Name must not exceed 200 characters.");
        }
    }
}
