using System;
using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Application.Interfaces;

namespace Application.Features.Reservations.Queries.GetReservDetail
{
    public class GetReservDetailQueryHandler : IRequestHandler<GetReservDetailQuery, ReservationDetailVM>
    {
        private readonly IReservationRepository _reservationRepository;

        private readonly IMapper _mapper;

        public GetReservDetailQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }
        public async Task<ReservationDetailVM> Handle(GetReservDetailQuery request, CancellationToken cancellationToken)
        {
            var ReservDetail = await _reservationRepository.GetReservationByIdAsync(request.ReservId,true);
            return _mapper.Map<ReservationDetailVM>(ReservDetail);
        }
    }
}
