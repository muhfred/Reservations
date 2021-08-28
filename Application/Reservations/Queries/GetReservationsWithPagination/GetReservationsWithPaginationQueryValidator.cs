﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reservations.Queries.GetReservationsWithPagination
{
    public class GetReservationsWithPaginationQueryValidator : AbstractValidator<GetReservationsWithPaginationQuery>
    {
        public GetReservationsWithPaginationQueryValidator()
        {
            RuleFor(x => x.TripId)
                .NotEmpty().WithMessage("TripId is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
