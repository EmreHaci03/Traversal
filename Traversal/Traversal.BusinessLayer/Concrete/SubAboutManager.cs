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
    public class SubAboutManager : ISubAboutService
    {
        private readonly ISubAboutDal subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            this.subAboutDal = subAboutDal;
        }

        public void TDelete(SubAbout entity)
        {
            subAboutDal.Delete(entity);
        }

        public List<SubAbout> TGetAll()
        {
            return subAboutDal.GetAll();
        }

        public SubAbout TGetById(int id)
        {
            return subAboutDal.GetById(id);
        }

        public List<SubAbout> TGetListByFilter(Expression<Func<SubAbout, bool>> filter)
        {
            return subAboutDal.GetListByFilter(filter);
        }

        public void TInsert(SubAbout entity)
        {
            subAboutDal.Insert(entity);
        }

        public void TUpdate(SubAbout entity)
        {
            subAboutDal.Update(entity);
        }
    }
}
