using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Entities;

namespace Traversal.DataAccessLayer.Abstract
{
    public interface IFavoriteDal:IGenericDal<Favorite>
    {
        public List<Favorite> GetFavoriteListByUser(string appUserId);
        bool AnyFavorite(Expression<Func<Favorite, bool>> filter);
        int FavoritePlaces(string appUserId);   
    }
}
