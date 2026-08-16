using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traversal.DtoLayer.DTOS.FavoriteDtos
{
    public class ResultFavoriteDto
    {
        public int FavoriteId { get; set; }
        public int DestinationId { get; set; }
        public string DestinationCity { get; set; }     
        public string DestinationImage { get; set; }     
        public decimal DestinationPrice { get; set; }      
        public DateTime AddedDate { get; set; }
    }
}
