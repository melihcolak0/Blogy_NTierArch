using _04PC_BlogStore.BusinessLayer.Abstract;
using _04PC_BlogStore.DataAccessLayer.Abstract;
using _04PC_BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public AppUser TGetAppUserByArticle(int id)
        {
            return _articleDal.GetAppUserByArticle(id);
        }

        public int TGetArticleCountByAppUser(string id)
        {
            return _articleDal.GetArticleCountByAppUser(id);
        }

        public List<Article> TGetArticlesByAppUser(string appUserId)
        {
            return _articleDal.GetArticlesByAppUser(appUserId);
        }

        public List<Article> TGetArticlesByCategory(int id)
        {
            return _articleDal.GetArticlesByCategory(id);
        }

        public Article TGetArticleWithCategory(int id)
        {
            return _articleDal.GetArticleWithCategory(id);
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public Article TGetBySlug(string slug)
        {
            return _articleDal.GetBySlug(slug);
        }

        public List<Article> TGetLast3Articles()
        {
            return _articleDal.GetLast3Articles();
        }

        public List<Article> TGetLast5Articles()
        {
            return _articleDal.GetLast5Articles();
        }

        public List<Article> TGetList()
        {
            return _articleDal.GetList();
        }

        public List<Article> TGetListWithCategories()
        {
            return _articleDal.GetListWithCategories();
        }

        public int TGetTotalArticleCount()
        {
            return _articleDal.GetTotalArticleCount();
        }

        public void TInsert(Article entity)
        {
            if (entity.Title.Length >= 10 && entity.Title.Length <= 100 && entity.Description != "" && entity.ImageUrl.Contains('a'))
            {
                _articleDal.Insert(entity);
            }
            else
            {
                //hata mesajı
            }
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }
    }
}
