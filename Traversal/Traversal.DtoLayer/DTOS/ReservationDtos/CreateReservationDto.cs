using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traversal.DtoLayer.DTOS.ReservationDtos
{
    public class CreateReservationDto
    {
        public string? AppUserId { get; set; }
        public string PersonCount { get; set; }
        public int DestinationId { get; set; }
        public string DestinationCity {  get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Status { get; set; }
    }
}
