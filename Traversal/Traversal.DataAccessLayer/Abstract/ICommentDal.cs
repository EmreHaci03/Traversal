using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Entities;

namespace Traversal.DataAccessLayer.Abstract
{
    public interface ICommentDal:IGenericDal<Comment>
    {
        public List<Comment> CommentListWihDestination();
        int GetCommentCount(int destinationId);
        int CommentCountDestinationUser(string userId);
        public List<Comment> CommentListWithDestinationUser(string userId);
    }
}
