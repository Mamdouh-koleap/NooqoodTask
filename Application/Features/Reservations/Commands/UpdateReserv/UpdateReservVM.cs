using MediatR;
using System;

namespace Application.Features.Reservations.Commands.UpdateReserv
{
   public class UpdateReservVM:IRequest
    {
        public Guid ReversationId { get; set; }

        public string CustomerName { get; set; }

        public Guid TripId { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string Notes { get; set; }
    }
}
