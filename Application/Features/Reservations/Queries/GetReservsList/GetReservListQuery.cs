using MediatR;
using System.Collections.Generic;

namespace Application.Features.Reservations.Queries.GetReservsList
{
    public class GetReservListQuery:IRequest<List<ReservationVM>>
    {

    }
}
