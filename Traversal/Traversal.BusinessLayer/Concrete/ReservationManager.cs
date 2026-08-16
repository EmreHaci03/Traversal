using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traversal.BusinessLayer.Abstract;
using Traversal.DataAccessLayer.Abstract;
using Traversal.EntityLayer.Entities;

namespace Traversal.BusinessLayer.Concrete
{
    public class ReservationManager:IReservationService
    {
        private readonly IReservationDal reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            this.reservationDal = reservationDal;
        }

        public int TActiveReservationCount(string userId)
        {
            return reservationDal.ActiveReservationCount(userId);
        }

        public void TDelete(Reservation entity)
        {
            reservationDal.Delete(entity);
        }

        public List<Reservation> TGetAll()
        {
            return reservationDal.GetAll();
        }

        public Reservation TGetById(int id)
        {
            return reservationDal.GetById(id);
        }

        public List<Reservation> TGetListByFilter(Expression<Func<Reservation, bool>> filter)
        {
            return reservationDal.GetListByFilter(filter);
        }

        public List<Reservation> TGetListByFilterWithDestination(Expression<Func<Reservation, bool>> filter)
        {
            return reservationDal.GetListByFilterWithDestination(filter);
        }

        public void TInsert(Reservation entity)
        {
            reservationDal.Insert(entity);
        }

        public int TReservationByUser(string userId)
        {
            return reservationDal.ReservationByUser(userId);
        }

        public List<Reservation> TReservationListWithUser()
        {
            return reservationDal.ReservationListWithUser();
        }

        public void TUpdate(Reservation entity)
        {
            reservationDal.Update(entity);
        }
    }
}
