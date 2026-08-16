using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traversal.DtoLayer.DTOS.ReservationDtos
{
    public class ResultReservationDto
    {
        public int ReservationId { get; set; }
        public string AppUserId { get; set; }
        public int PersonCount { get; set; }
        public string DestinationCity { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; }
    }
}
