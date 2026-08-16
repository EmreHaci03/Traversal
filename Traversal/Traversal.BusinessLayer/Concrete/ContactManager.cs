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
    public class ContactManager:IContactService
    {
        private readonly IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public void TDelete(Contact entity)
        {
            contactDal.Delete(entity);
        }

        public List<Contact> TGetAll()
        {
            return contactDal.GetAll();
        }

        public Contact TGetById(int id)
        {
            return contactDal.GetById(id);
        }

        public List<Contact> TGetListByFilter(Expression<Func<Contact, bool>> filter)
        {
            return contactDal.GetListByFilter(filter);
        }

        public void TInsert(Contact entity)
        {
            contactDal.Insert(entity);
        }

        public void TUpdate(Contact entity)
        {
             contactDal.Update(entity);
        }
    }
}
