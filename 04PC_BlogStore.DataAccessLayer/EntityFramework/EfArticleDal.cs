using _04PC_BlogStore.DataAccessLayer.Abstract;
using _04PC_BlogStore.DataAccessLayer.Context;
using _04PC_BlogStore.DataAccessLayer.Repositories;
using _04PC_BlogStore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        private readonly BlogContext _context;

        public EfArticleDal(BlogContext context) : base(context)
        {
            _context = context;
        }

        public AppUser GetAppUserByArticle(int id)
        {
            return _context.Articles
                .Include(x => x.AppUser)
                .Where(x => x.ArticleId == id)
                .Select(x => x.AppUser)
                .FirstOrDefault();

            //var userId = _context.Articles
            //    .Where(x => x.ArticleId == id)
            //    .Select(x => x.AppUserId)
            //    .FirstOrDefault();

            //return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public List<Article> GetArticlesByAppUser(string appUserId)
        {
            return _context.Articles.Where(x => x.AppUserId == appUserId).Include(y => y.Category).ToList();
        }

        public List<Article> GetArticlesByCategory(int id)
        {
            return _context.Articles.Where(x => x.CategoryId == id).ToList();
        }

        public Article GetArticleWithCategory(int id)
        {
            return _context.Articles.Where(x => x.ArticleId == id).Include(y => y.Category).FirstOrDefault();
        }

        public List<Article> GetLast3Articles()
        {
            return _context.Articles.OrderByDescending(x => x.CreatedDate).Take(3).ToList();
        }

        public List<Article> GetListWithCategories()
        {
            return _context.Articles.Include(x => x.Category).ToList();
        }

        public Article GetBySlug(string slug)
        {
            return _context.Articles.Include(x => x.Category)
                            .Include(x => x.AppUser)
                            .FirstOrDefault(x => x.Slug == slug);
        }

        public int GetArticleCountByAppUser(string id)
        {
            return _context.Articles.Where(x => x.AppUserId == id).Count();
        }

        public int GetTotalArticleCount()
        {
            return _context.Articles.Count();
        }

        public List<Article> GetLast5Articles()
        {
            return _context.Articles.Include(x => x.Category).Include(y => y.AppUser).OrderByDescending(x => x.CreatedDate).Take(5).ToList();
        }
    }
}
