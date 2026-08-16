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
    public class FeatureMainManager:IFeatureMainService
    {
        private readonly IFeatureMainDal featureMainDal;

        public FeatureMainManager(IFeatureMainDal featureMainDal)
        {
            this.featureMainDal = featureMainDal;
        }

        public void TDelete(FeatureMain entity)
        {
            featureMainDal.Delete(entity);
        }

        public List<FeatureMain> TGetAll()
        {
            return featureMainDal.GetAll();
        }

        public FeatureMain TGetById(int id)
        {
            return featureMainDal.GetById(id);
        }

        public List<FeatureMain> TGetListByFilter(Expression<Func<FeatureMain, bool>> filter)
        {
            return featureMainDal.GetListByFilter(filter);
        }

        public void TInsert(FeatureMain entity)
        {
            featureMainDal.Insert(entity);
        }

        public void TUpdate(FeatureMain entity)
        {
            featureMainDal.Update(entity);
        }
    }
}
