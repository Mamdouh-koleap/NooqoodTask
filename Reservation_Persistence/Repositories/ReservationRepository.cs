using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation_Persistence.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ReservationDbContext reservationDbContext):base(reservationDbContext)
        {

        }
        public async Task<IReadOnlyList<Reservation>> GetAllReservationAsync(bool IncludeTrip)
        {
            List<Reservation> Allreservations = new List<Reservation>();
            Allreservations = IncludeTrip ? await _dbContext.Reservations.Include(x => x.trip).ToListAsync()
                : await _dbContext.Reservations.ToListAsync();
            return Allreservations;
        }

        public async Task<Reservation> GetReservationByIdAsync(Guid id, bool includeTripDetail)
        {
            Reservation reservation = new Reservation();
            reservation = includeTripDetail ? await _dbContext.Reservations.Include(x => x.trip).FirstOrDefaultAsync(f => f.ReversationId == id)
            : await GetByIdAsync(id);
            return reservation;
        }
    }
}
