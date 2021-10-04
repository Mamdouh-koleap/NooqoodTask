using MediatR;
using System;

namespace Application.Features.Reservations.Queries.GetReservDetail
{
    public class GetReservDetailQuery:IRequest<ReservationDetailVM>
    {
        public Guid ReservId { get; set; }
    }
}
