using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Entities;

namespace Traversal.DataAccessLayer.Abstract
{
    public interface IReservationDal:IGenericDal<Reservation>
    {
        List<Reservation> GetListByFilterWithDestination(Expression<Func<Reservation, bool>> filter);
        int ReservationByUser(string userId);
        int ActiveReservationCount(string userId);
        List<Reservation> ReservationListWithUser();
    }
}
