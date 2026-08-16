using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traversal.EntityLayer.Entities
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public string AppUserId { get; set; }     
        public AppUser AppUser { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
