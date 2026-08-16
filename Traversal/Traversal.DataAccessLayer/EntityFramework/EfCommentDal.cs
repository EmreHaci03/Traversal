using Microsoft.EntityFrameworkCore;
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
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly TraversalContext _traversalContext;
        public EfCommentDal(TraversalContext traversalContext) : base(traversalContext)
        {
            this._traversalContext = traversalContext;
        }

        public int CommentCountDestinationUser(string userId)
        {
            return _traversalContext.Comments.Count(x=>x.AppUserId== userId);   
        }

        public List<Comment> CommentListWihDestination()
        {
            return _traversalContext.Comments.Include(x => x.Destination).ToList();
        }

        public List<Comment> CommentListWithDestinationUser(string userId)
        {
            return _traversalContext.Comments.Include(x => x.Destination).Include(x => x.AppUser).Where(x=>x.AppUserId==userId).ToList();
        }

        public int GetCommentCount(int destinationId)
        {
            return _traversalContext.Comments.Where(x => x.DestinationId == destinationId).Count();
        }
    }
}
