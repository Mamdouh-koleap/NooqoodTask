using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.CreateReserv
{
    public class CreateReservCommandHandler:IRequestHandler<ReservCreateVM, Guid>
    {
        private readonly IReservationRepository _reservationRepository;

        private readonly IMapper _mapper;

        public CreateReservCommandHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(ReservCreateVM request, CancellationToken cancellationToken)
        {
            Reservation CreateReserv = _mapper.Map<Reservation>(request);

            CreateCommandValidator validationRules = new CreateCommandValidator();

            var result = await validationRules.ValidateAsync(request);

            if(result.Errors.Any())
            {
                throw new Exception("Reservation Is Not Valid");
            }

            CreateReserv = await _reservationRepository.AddAsync(CreateReserv);

            return CreateReserv.ReversationId;

        }
    }
}
