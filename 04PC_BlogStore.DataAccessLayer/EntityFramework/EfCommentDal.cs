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
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly BlogContext _context;

        public EfCommentDal(BlogContext context) : base(context)
        {
            _context = context;
        }

        public int GetCommentCountByAppUser(string id)
        {
            return _context.Comments.Count(x => x.Article.AppUserId == id);
        }

        public List<Comment> GetCommentsByAppUser(string id)
        {
            return _context.Comments
                .Include(x => x.Article)
                .Include(x => x.AppUser)
                .Where(x => x.Article.AppUserId == id)
                .OrderByDescending(x => x.CommentDate)
                .ToList();
        }

        public List<Comment> GetCommentsByArticle(int id)
        {
            var values = _context.Comments.Include(x => x.AppUser)
                .Include(y => y.Article)
                .Where(z => z.ArticleId == id && z.IsValid)
                .OrderByDescending(a => a.CommentDate)
                .ToList();
            return values;
        }

        public List<Comment> GetLast5Comment()
        {
            return _context.Comments.Include(x => x.AppUser).Include(y => y.Article).OrderByDescending(x => x.CommentDate).Take(5).ToList();
        }
    }
}
