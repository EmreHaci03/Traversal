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
    public class FeatureGridManager:IFeatureGridService
    {
        private readonly IFeatureGridDal featureGridDal;

        public FeatureGridManager(IFeatureGridDal featureGridDal)
        {
            this.featureGridDal = featureGridDal;
        }

        public void TDelete(FeatureGrid entity)
        {
            featureGridDal.Delete(entity);
        }

        public List<FeatureGrid> TGetAll()
        {
            return featureGridDal.GetAll();
        }

        public FeatureGrid TGetById(int id)
        {
            return featureGridDal.GetById(id);
        }

        public List<FeatureGrid> TGetListByFilter(Expression<Func<FeatureGrid, bool>> filter)
        {
            return featureGridDal.GetListByFilter(filter);
        }

        public void TInsert(FeatureGrid entity)
        {
            featureGridDal.Insert(entity);
        }

        public void TUpdate(FeatureGrid entity)
        {
            featureGridDal.Update(entity);
        }
    }
}
