using Application.Interfaces;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.DeleteReserv
{
    public class DeleteReservCommandHandler : IRequestHandler<DeleteReservVM>
    {
        private readonly IReservationRepository _reservationRepository;


        public DeleteReservCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<Unit> Handle(DeleteReservVM request, CancellationToken cancellationToken)
        {
            Reservation reservation = await _reservationRepository.GetByIdAsync(request.ReversationId);
            await _reservationRepository.DeleteAsync(reservation);
            return Unit.Value;
        }
    }
}
