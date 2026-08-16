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
    public class GuideManager:IGuideService
    {
        private readonly IGuideDal guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            this.guideDal = guideDal;
        }

        public void TDelete(Guide entity)
        {
            guideDal.Delete(entity);
        }

        public List<Guide> TGetAll()
        {
            return guideDal.GetAll();
        }

        public Guide TGetById(int id)
        {
            return guideDal.GetById(id);
        }

        public List<Guide> TGetListByFilter(Expression<Func<Guide, bool>> filter)
        {
            return guideDal.GetListByFilter(filter);
        }

        public void TInsert(Guide entity)
        {
            guideDal.Insert(entity);
        }

        public void TUpdate(Guide entity)
        {
            guideDal.Update(entity);
        }
    }
}
