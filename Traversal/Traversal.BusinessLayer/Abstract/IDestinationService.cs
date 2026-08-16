using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Entities;

namespace Traversal.BusinessLayer.Abstract
{
    public interface IDestinationService:IGenericService<Destination>
    {
        List<Destination> TActiveRoutes();
    }
}
