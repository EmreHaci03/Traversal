using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traversal.DataAccessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;
using Traversal.DataAccessLayer.Repository;
using Traversal.EntityLayer.Entities;

namespace Traversal.DataAccessLayer.EntityFramework
{
    public class EfFavoriteDal : GenericRepository<Favorite>, IFavoriteDal
    {
        private readonly TraversalContext _traversalContext;

        public EfFavoriteDal(TraversalContext traversalContext) : base(traversalContext)
        {
            this._traversalContext = traversalContext;
        }

        public List<Favorite> GetFavoriteListByUser(string appUserId)
        {
            return _traversalContext.Favorites.Include(x=>x.Destination).Where(x =>x.AppUserId == appUserId).ToList();
        }

        public bool AnyFavorite(Expression<Func<Favorite, bool>> filter)
        {
            return _traversalContext.Favorites.Any(filter);
        }

        public int FavoritePlaces(string appUserId)
        {
            return _traversalContext.Favorites.Count(x=>x.AppUserId==appUserId);
        }
    }
}
