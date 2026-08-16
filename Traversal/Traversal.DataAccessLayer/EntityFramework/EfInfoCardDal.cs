using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.DataAccessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;
using Traversal.DataAccessLayer.Repository;
using Traversal.EntityLayer.Entities;

namespace Traversal.DataAccessLayer.EntityFramework
{
    public class EfInfoCardDal : GenericRepository<InfoCard>, IInfoCardDal
    {
        public EfInfoCardDal(TraversalContext traversalContext) : base(traversalContext)
        {
        }
    }
}
