using Application.Common.Models;
using Application.Common.Security;
using Application.Reservations.Commands.CreateReservation;
using Application.Reservations.Commands.DeleteReservation;
using Application.Reservations.Commands.UpdateReservation;
using Application.Reservations.Commands.UpdateReservationDetail;
using Application.Reservations.Queries.GetReservationsWithPagination;
using Application.Trips.Queries.GetTrips;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Authorize]
    public class ReservationsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ReservationDto>>> GetReservationsWithPagination([FromQuery] GetReservationsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateReservationCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateReservationCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateReservationDetails(int id, UpdateReservationDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteReservationCommand { Id = id });

            return NoContent();
        }
    }
}
