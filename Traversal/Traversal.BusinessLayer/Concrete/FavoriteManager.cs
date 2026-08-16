using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Traversal.BusinessLayer.Abstract;
using Traversal.DataAccessLayer.Abstract;
using Traversal.EntityLayer.Entities;

namespace Traversal.BusinessLayer.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        private readonly IFavoriteDal favoriteDal;

        public FavoriteManager(IFavoriteDal favoriteDal)
        {
            this.favoriteDal = favoriteDal;
        }

        public bool TAnyFavorite(Expression<Func<Favorite, bool>> filter)
        {
            return favoriteDal.AnyFavorite(filter);
        }

        public void TDelete(Favorite entity)
        {
            favoriteDal.Delete(entity);
        }

        public int TFavoritePlaces(string appUserId)
        {
            return favoriteDal.FavoritePlaces(appUserId);
        }

        public List<Favorite> TGetAll()
        {
            return favoriteDal.GetAll();
        }

        public Favorite TGetById(int id)
        {
            return favoriteDal.GetById(id);
        }

        public List<Favorite> TGetFavoriteListByUser(string appUserId)
        {
            return favoriteDal.GetFavoriteListByUser(appUserId);
        }

        public List<Favorite> TGetListByFilter(Expression<Func<Favorite, bool>> filter)
        {
            return favoriteDal.GetListByFilter(filter);
        }

        public void TInsert(Favorite entity)
        {
            favoriteDal.Insert(entity);
        }

        public void TUpdate(Favorite entity)
        {
            favoriteDal.Update(entity);
        }
    }
}