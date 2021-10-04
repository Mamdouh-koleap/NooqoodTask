using Application.Features.Reservations.Commands.CreateReserv;
using Application.Features.Reservations.Commands.CreateUser;
using Application.Features.Reservations.Commands.DeleteReserv;
using Application.Features.Reservations.Commands.UpdateReserv;
using Application.Features.Reservations.Queries.GetReservDetail;
using Application.Features.Reservations.Queries.GetReservsList;
using AutoMapper;
using Domain;

namespace Application.Profiles
{
    class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Reservation, ReservationVM>().ReverseMap();
            CreateMap<Reservation, ReservationDetailVM>().ReverseMap();
            CreateMap<Reservation, ReservCreateVM>().ReverseMap();
            CreateMap<Reservation, UpdateReservVM>().ReverseMap();
            CreateMap<Reservation, DeleteReservVM>().ReverseMap();
            CreateMap<User, CreateUserCommandVM>().ReverseMap();
        }
    }
}
