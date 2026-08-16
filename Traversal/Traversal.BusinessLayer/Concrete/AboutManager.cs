using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.ValidationRules.AboutValidators;
using Traversal.DataAccessLayer.Abstract;
using Traversal.EntityLayer.Entities;

namespace Traversal.BusinessLayer.Concrete
{
    public class AboutManager:IAboutService
    {
        private readonly IAboutDal aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal = aboutDal;
        }

        public void TDelete(About entity)
        {
            aboutDal.Delete(entity);
        }

        public List<About> TGetAll()
        {
            return aboutDal.GetAll();
        }

        public About TGetById(int id)
        {
            return aboutDal.GetById(id);
        }

        public List<About> TGetListByFilter(Expression<Func<About, bool>> filter)
        {
            return aboutDal.GetListByFilter(filter);    
        }

        public void TInsert(About entity)
        {
            aboutDal.Insert(entity);
        }

        public void TUpdate(About entity)
        {
            aboutDal.Update(entity);
        }
    }
}
