using MediatR;
using System;

namespace Application.Features.Reservations.Commands.DeleteReserv
{
    public class DeleteReservVM : IRequest
    {
        public Guid ReversationId { get; set; }
    }
}
