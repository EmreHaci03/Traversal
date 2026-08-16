using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Entities;

namespace Traversal.BusinessLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
        List<Reservation> TGetListByFilterWithDestination(Expression<Func<Reservation, bool>> filter);
        int TReservationByUser(string userId);
        int TActiveReservationCount(string userId);
        List<Reservation> TReservationListWithUser();
    }
}
