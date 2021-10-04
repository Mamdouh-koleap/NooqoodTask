using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Reservation_Persistence
{
   public class ReservationDbContext :DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext>options) :base(options)
        {

        }

        public DbSet<Reservation>Reservations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var UserGuid = Guid.Parse("{d5a11f41-2e72-4b08-b02b-f0250f540654}");
            var TripGuid = Guid.Parse("{860764f2-d405-4142-86d1-efc7bb8c9672}");
            var ReservationGuid = Guid.Parse("{cc505b3b-d35f-4e74-935b-38b42271ec4a}");
            var UserEmail = "mamdouh.koleap@gmail.com";
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = UserGuid,
                Email =UserEmail ,
                Password = "mamdouh123"
            }) ;

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                TripId=TripGuid,
                CityName="hurghada",
                Name="break trip",
                price=1000,
                CreationDate=DateTime.Now,
                content=" Accepts HTML Format",
                ImageUrl=null
            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                ReversationId=ReservationGuid,
                ReservationDate=DateTime.Now,
                ReservedBy= UserEmail,
                CreationDate=DateTime.Now,
                CustomerName="Ali Nadi Ali",
                TripId=TripGuid,
                Notes="no notes"
            });
           

        }
    }
}
