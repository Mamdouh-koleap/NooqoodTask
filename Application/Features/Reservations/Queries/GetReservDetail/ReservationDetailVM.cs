using Domain;
using System;

namespace Application.Features.Reservations.Queries.GetReservDetail
{
    public class ReservationDetailVM
    {
        public Guid ReversationId { get; set; }

        public string ReservedBy { get; set; }

        public string CustomerName { get; set; }

        public Trip trip { get; set; }

        public DateTime ReservationDate { get; set; }

    }
}
