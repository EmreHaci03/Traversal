using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traversal.DtoLayer.DTOS.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public string NameSurname { get; set; }
        public DateTime CommentDate { get; set; }
        public string Content { get; set; }
        public bool CommentStatus { get; set; }
        public string AppUserId { get; set; }
        public string DestinationCity { get; set; }
        public int DestinationId { get; set; }
    }
}
