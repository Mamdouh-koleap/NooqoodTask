using MediatR;
using System;

namespace Application.Features.Reservations.Commands.CreateUser
{
    public class CreateUserCommandVM :IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
