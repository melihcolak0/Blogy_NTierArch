using _04PC_BlogStore.DataAccessLayer.Abstract;
using _04PC_BlogStore.DataAccessLayer.Context;
using _04PC_BlogStore.DataAccessLayer.DTOs;
using _04PC_BlogStore.DataAccessLayer.Repositories;
using _04PC_BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly BlogContext _context;

        public EfCategoryDal(BlogContext context) : base(context)
        {
            _context = context;
        }        

        public List<CategoryWithArticleCountDto> GetCategoryWithArticleCount()
        {
            var result = _context.Categories.Select(c => new CategoryWithArticleCountDto
            {
                CategoryName = c.CategoryName,
                ArticleCount = _context.Articles.Count(x => x.CategoryId == c.CategoryId)
            }).ToList();

            return result;
        }
    }
}
