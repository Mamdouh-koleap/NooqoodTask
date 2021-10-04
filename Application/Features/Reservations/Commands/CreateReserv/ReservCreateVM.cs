using MediatR;
using System;

namespace Application.Features.Reservations.Commands.CreateReserv
{
   public class ReservCreateVM: IRequest<Guid>
    {
        public Guid ReservId{ get; set; }
        
        public string ReservedBy { get; set; }

        public string CustomerName { get; set; }

        public Guid TripId { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string Notes { get; set; }
    }
}
