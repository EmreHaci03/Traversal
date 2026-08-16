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
    public class CommentManager:ICommentService
    {
        private readonly ICommentDal commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            this.commentDal = commentDal;
        }

        public int TCommentCountDestinationUser(string userId)
        {
            return commentDal.CommentCountDestinationUser(userId);  
        }

        public List<Comment> TCommentListWihDestination()
        {
            return commentDal.CommentListWihDestination();
        }

        public List<Comment> TCommentListWithDestinationUser( string AppUserId)
        {
            return commentDal.CommentListWithDestinationUser( AppUserId);
        }

        public void TDelete(Comment entity)
        {
            commentDal.Delete(entity);
        }

        public List<Comment> TGetAll()
        {
            return commentDal.GetAll();
        }

        public Comment TGetById(int id)
        {
            return commentDal.GetById(id);
        }

        public int TGetCommentCount(int destinationId)
        {
            return commentDal.GetCommentCount(destinationId);
        }

        public List<Comment> TGetListByDestinationId(int id)
        {
            return commentDal.GetListByFilter(x=>x.DestinationId==id);
        }

        public List<Comment> TGetListByFilter(Expression<Func<Comment, bool>> filter)
        {
            return commentDal.GetListByFilter(filter);
        }

        public void TInsert(Comment entity)
        {
            commentDal.Insert(entity);
        }

        public void TUpdate(Comment entity)
        {
            commentDal.Update(entity);
        }
    }
}
