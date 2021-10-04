using Domain;
using System;

namespace Application.Features.Reservations.Queries.GetReservsList
{
   public class ReservationVM
    {
        public Guid ReversationId { get; set; }

        public string ReservedBy { get; set; }

        public string CustomerName { get; set; }

        public DateTime ReservationDate { get; set; }

        public Trip trip { get; set; }
    }
}
