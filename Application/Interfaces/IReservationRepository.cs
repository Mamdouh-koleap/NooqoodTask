using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
  public  interface IReservationRepository:IAsyncRepository<Reservation>
    {

        Task<IReadOnlyList<Reservation>> GetAllReservationAsync(bool IncludeTrip);

        Task<Reservation> GetReservationByIdAsync(Guid id,bool includeTripDetail);
    }
}
