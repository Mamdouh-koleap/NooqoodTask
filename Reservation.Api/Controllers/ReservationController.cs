using Application.Features.Reservations.Commands.CreateReserv;
using Application.Features.Reservations.Commands.DeleteReserv;
using Application.Features.Reservations.Commands.UpdateReserv;
using Application.Features.Reservations.Queries.GetReservDetail;
using Application.Features.Reservations.Queries.GetReservsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("GetAllReservations")]
        [HttpGet]
        public async Task<ActionResult<List<ReservationVM>>> GetAllReservations()
        {
            var reservs = await _mediator.Send(new GetReservListQuery());
            return Ok(reservs);
        }
        [Route("GetReservationById")]
        [HttpPost]
        public async Task<ActionResult<ReservationDetailVM>> GetReservationById(Guid id)
        {
            var DetailReserv = new GetReservDetailQuery() {ReservId=id };

            return Ok(await _mediator.Send(DetailReserv));
        }

        [Route("AddReserv")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] ReservCreateVM reservCreateVM)
        {
            //use session to get the curren user is log in the application now 
            reservCreateVM.ReservedBy = HttpContext.Session.GetString("UserNmae");
            Guid id = await _mediator.Send(reservCreateVM);
            return Ok(id);
        }

        [Route("UpdateReserv")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateReservVM updateReservVM)
        {
             await _mediator.Send(updateReservVM);
            return NoContent();
        }

        [Route("deleteReserv")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {

            var deleteReservVM = new DeleteReservVM() {ReversationId=id };
            await _mediator.Send(deleteReservVM);
            return NoContent();
        }
    }
}
