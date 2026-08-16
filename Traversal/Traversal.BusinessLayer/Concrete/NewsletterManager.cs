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
    public class NewsletterManager:INewsletterService
    {
        private readonly INewsletterDal newsletterDal;

        public NewsletterManager(INewsletterDal newsletterDal)
        {
            this.newsletterDal = newsletterDal;
        }

        public void TDelete(Newsletter entity)
        {
            newsletterDal.Delete(entity);
        }

        public List<Newsletter> TGetAll()
        {
            return newsletterDal.GetAll();
        }

        public Newsletter TGetById(int id)
        {
            return newsletterDal.GetById(id);
        }

        public List<Newsletter> TGetListByFilter(Expression<Func<Newsletter, bool>> filter)
        {
            return newsletterDal.GetListByFilter(filter);
        }

        public void TInsert(Newsletter entity)
        {
            newsletterDal.Insert(entity);
        }

        public void TUpdate(Newsletter entity)
        {
            newsletterDal.Update(entity);
        }
    }
}
