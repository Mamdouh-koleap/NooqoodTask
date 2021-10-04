using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.CreateUser
{
    class CreateUserCommandHandler : IRequestHandler<CreateUserCommandVM, Guid>
    {
        private readonly IAsyncRepository<User> _asyncRepository;

        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IAsyncRepository<User> asyncRepository,IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateUserCommandVM request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);

            user = await _asyncRepository.AddAsync(user);

            return user.UserId;
        }
    }
}
