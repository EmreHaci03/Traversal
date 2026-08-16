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
    public class DestinationManager:IDestinationService
    {
        private readonly IDestinationDal destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            this.destinationDal = destinationDal;
        }

        public List<Destination> TActiveRoutes()
        {
            return destinationDal.ActiveRoutes();
        }

        public void TDelete(Destination entity)
        {
            destinationDal.Delete(entity);
        }

        public List<Destination> TGetAll()
        {
            return destinationDal.GetAll();
        }

        public Destination TGetById(int id)
        {
            return destinationDal.GetById(id);
        }

        public List<Destination> TGetListByFilter(Expression<Func<Destination, bool>> filter)
        {
            return destinationDal.GetListByFilter(filter);
        }

        public void TInsert(Destination entity)
        {
            destinationDal.Insert(entity);
        }

        public void TUpdate(Destination entity)
        {
            destinationDal.Update(entity);
        }
    }
}
