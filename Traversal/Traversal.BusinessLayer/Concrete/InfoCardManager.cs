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
    public class InfoCardManager:IInfoCardService
    {
        private readonly IInfoCardDal ınfoCardDal;

        public InfoCardManager(IInfoCardDal ınfoCardDal)
        {
            this.ınfoCardDal = ınfoCardDal;
        }

        public void TDelete(InfoCard entity)
        {
            ınfoCardDal.Delete(entity);
        }

        public List<InfoCard> TGetAll()
        {
            return ınfoCardDal.GetAll();
        }

        public InfoCard TGetById(int id)
        {
            return ınfoCardDal.GetById(id);
        }

        public List<InfoCard> TGetListByFilter(Expression<Func<InfoCard, bool>> filter)
        {
            return ınfoCardDal.GetListByFilter(filter);
        }

        public void TInsert(InfoCard entity)
        {
            ınfoCardDal.Insert(entity);
        }

        public void TUpdate(InfoCard entity)
        {
            ınfoCardDal.Update(entity);
        }
    }
}
