using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Entities;

namespace Traversal.BusinessLayer.Abstract
{
    public interface IFavoriteService:IGenericService<Favorite>
    {
        List<Favorite> TGetFavoriteListByUser(string appUserId);
        bool TAnyFavorite(Expression<Func<Favorite, bool>> filter);
        int TFavoritePlaces(string appUserId);

    }
}
