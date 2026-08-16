using Traversal.DataAccessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;
using Traversal.DataAccessLayer.Repository;
using Traversal.EntityLayer.Entities;

namespace Traversal.DataAccessLayer.EntityFramework
{
    public class EfFeatureGridDal : GenericRepository<FeatureGrid>, IFeatureGridDal
    {
        public EfFeatureGridDal(TraversalContext traversalContext) : base(traversalContext)
        {
        }
    }
}
