using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traversal.DtoLayer.DTOS.FavoriteDtos
{
    public class CreateFavoriteDto
    {
        public string AppUserId { get; set; }
        public int DestinationId { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
