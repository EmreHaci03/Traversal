using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traversal.DataAccessLayer.Concrete;
using Traversal.EntityLayer.Entities;

namespace Traversal.BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        List<Comment> TGetListByDestinationId(int id);
        int TGetCommentCount(int destinationId);
        int TCommentCountDestinationUser(string userId);
        List<Comment> TCommentListWihDestination();
        List<Comment> TCommentListWithDestinationUser( string AppUserId);

    }
}
