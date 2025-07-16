using _04PC_BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        public List<Article> TGetListWithCategories();

        public AppUser TGetAppUserByArticle(int id);

        public List<Article> TGetLast3Articles();

        public List<Article> TGetArticlesByAppUser(string appUserId);

        public Article TGetArticleWithCategory(int id);

        public List<Article> TGetArticlesByCategory(int id);

        public Article TGetBySlug(string slug);

        public int TGetArticleCountByAppUser(string id);

        public int TGetTotalArticleCount();

        public List<Article> TGetLast5Articles();
    }
}
