using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traversal.DtoLayer.DTOS.TestimonialDtos
{
    public class GetTestimonialByIdDto
    {
        public int TestimonialId { get; set; }
        public string NameSurname { get; set; }
        public string Comment { get; set; }
        public string ClientImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
