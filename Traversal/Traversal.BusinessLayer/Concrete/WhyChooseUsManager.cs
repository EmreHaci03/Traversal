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
    public class WhyChooseUsManager:IWhyChooseUsService
    {
        private readonly IWhyChooseUsDal whyChooseUsDal;

        public WhyChooseUsManager(IWhyChooseUsDal whyChooseUsDal)
        {
            this.whyChooseUsDal = whyChooseUsDal;
        }

        public void TDelete(WhyChooseUs entity)
        {
            whyChooseUsDal.Delete(entity);
        }

        public List<WhyChooseUs> TGetAll()
        {
            return whyChooseUsDal.GetAll();
        }

        public WhyChooseUs TGetById(int id)
        {
            return whyChooseUsDal.GetById(id);
        }

        public List<WhyChooseUs> TGetListByFilter(Expression<Func<WhyChooseUs, bool>> filter)
        {
            return whyChooseUsDal.GetListByFilter(filter);
        }

        public void TInsert(WhyChooseUs entity)
        {
            whyChooseUsDal.Insert(entity);
        }

        public void TUpdate(WhyChooseUs entity)
        {
            whyChooseUsDal.Update(entity);
        }
    }
}
