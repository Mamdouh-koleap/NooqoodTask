using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Queries.GetReservsList
{
    public class GetReservListQueryHandler : IRequestHandler<GetReservListQuery, List<ReservationVM>>
    {
        private readonly IReservationRepository _reservationRepository;

        private readonly IMapper _mapper;

        public GetReservListQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<List<ReservationVM>> Handle(GetReservListQuery request, CancellationToken cancellationToken)
        {
            var allResevs = await _reservationRepository.GetAllReservationAsync(true);
            return _mapper.Map<List<ReservationVM>>(allResevs);
        }
    }
}
