using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traversal.DtoLayer.DTOS.AppUserDtos
{
    public class ResultAppUserDto
    {
        public string AppUserId { get; set; }
        public string Name {  get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
