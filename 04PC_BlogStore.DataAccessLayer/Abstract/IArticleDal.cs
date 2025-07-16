using _04PC_BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        public List<Article> GetListWithCategories();

        public AppUser GetAppUserByArticle(int id);

        public List<Article> GetLast3Articles();

        public List<Article> GetArticlesByAppUser(string appUserId);

        public Article GetArticleWithCategory(int id);

        public List<Article> GetArticlesByCategory(int id);

        public Article GetBySlug(string slug);

        public int GetArticleCountByAppUser(string id);

        public int GetTotalArticleCount();

        public List<Article> GetLast5Articles();
    }
}
