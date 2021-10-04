using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
   public class Trip
    {
        [Key]
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public int price { get; set; }
        public string ImageUrl { get; set; }
        public string content { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
