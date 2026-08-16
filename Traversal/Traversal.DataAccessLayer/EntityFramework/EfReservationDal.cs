using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traversal.DataAccessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;
using Traversal.DataAccessLayer.Repository;
using Traversal.EntityLayer.Entities;

namespace Traversal.DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        private readonly TraversalContext _traversalContext;
        public EfReservationDal(TraversalContext traversalContext) : base(traversalContext)
        {
            this._traversalContext=traversalContext;
        }

        public int ActiveReservationCount(string userId)
        {
            return _traversalContext.Reservations.Count(x => x.AppUserId == userId && x.Status == "Onaylandı");
        }

        public List<Reservation> GetListByFilterWithDestination(Expression<Func<Reservation, bool>> filter)
        {
            return _traversalContext.Reservations.Include(x => x.Destination).Where(filter).ToList();
        }

        public int ReservationByUser(string userId)
        {
            return _traversalContext.Reservations.Count(x => x.AppUserId == userId);
        }

        public List<Reservation> ReservationListWithUser()
        {
            return _traversalContext.Reservations.Include(x => x.AppUser).Include(x=>x.Destination).ToList();
        }
    }
}
