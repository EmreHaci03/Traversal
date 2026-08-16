using System;

namespace Traversal.EntityLayer.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public string AppUserId { get; set; }     
        public AppUser AppUser { get; set; }

        public int DestinationId { get; set; }     
        public Destination Destination { get; set; }
        public int PersonCount { get; set; } 
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; }
    }
}