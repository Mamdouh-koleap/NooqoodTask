using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
   public class Reservation
    {
        [Key]
        public Guid ReversationId { get; set; }
        
        public string ReservedBy { get; set; }

        public string CustomerName { get; set; }

        public Trip trip { get; set; }
        [ForeignKey("Trip")]
        public Guid TripId { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string Notes { get; set; }
    }
}
