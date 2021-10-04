using Application.Features.Reservations.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Reservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("CreateUser")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserCommandVM createUserCommandVM)
        {
            //set username in session to use it
            //(this is example to set string user name email and use it in any place  )
            HttpContext.Session.SetString("UserNmae",createUserCommandVM.Email);
            Guid id = await _mediator.Send(createUserCommandVM);
            return Ok(id);

        }
    }
}
