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
    public class TestimonialManager:ITestimonialService
    {
        private readonly ITestimonialDal testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            this.testimonialDal = testimonialDal;
        }

        public void TDelete(Testimonial entity)
        {
            testimonialDal.Delete(entity);
        }

        public List<Testimonial> TGetAll()
        {
            return testimonialDal.GetAll();
        }

        public Testimonial TGetById(int id)
        {
            return testimonialDal.GetById(id);
        }

        public List<Testimonial> TGetListByFilter(Expression<Func<Testimonial, bool>> filter)
        {
            return testimonialDal.GetListByFilter(filter);
        }

        public void TInsert(Testimonial entity)
        {
            testimonialDal.Insert(entity);
        }

        public void TUpdate(Testimonial entity)
        {
            testimonialDal.Update(entity);
        }
    }
}
