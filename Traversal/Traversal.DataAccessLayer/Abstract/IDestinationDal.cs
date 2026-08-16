using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Entities;

namespace Traversal.DataAccessLayer.Abstract
{
    public interface IDestinationDal:IGenericDal<Destination>
    {
        List<Destination> ActiveRoutes();
}
}