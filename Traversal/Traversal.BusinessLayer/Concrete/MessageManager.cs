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
    public class MessageManager:IMessageService
    {
        private readonly IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public void TDelete(Message entity)
        {
            messageDal.Delete(entity);
        }

        public List<Message> TGetAll()
        {
           return messageDal.GetAll();
        }

        public Message TGetById(int id)
        {
            return messageDal.GetById(id);
        }

        public List<Message> TGetListByFilter(Expression<Func<Message, bool>> filter)
        {
            return messageDal.GetListByFilter(filter);
        }

        public void TInsert(Message entity)
        {
            messageDal.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            messageDal.Update(entity);
        }
    }
}
