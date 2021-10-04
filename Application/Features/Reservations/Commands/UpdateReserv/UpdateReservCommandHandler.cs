using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.UpdateReserv
{
    class UpdateReservCommandHandler : IRequestHandler<UpdateReservVM>
    {
        private readonly IReservationRepository _reservationRepository;

        private readonly IMapper _mapper;

        public UpdateReservCommandHandler(IReservationRepository reservationRepository,IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

       public async Task<Unit> Handle(UpdateReservVM request, CancellationToken cancellationToken)
        {
            Reservation reservation = _mapper.Map<Reservation>(request);
            await _reservationRepository.UpdateAsync(reservation);
            return Unit.Value;
        }
    }
}
