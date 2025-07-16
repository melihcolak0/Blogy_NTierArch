using _04PC_BlogStore.BusinessLayer.Abstract;
using _04PC_BlogStore.DataAccessLayer.Abstract;
using _04PC_BlogStore.DataAccessLayer.DTOs;
using _04PC_BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(int id)
        {
            _categoryDal.Delete(id);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<CategoryWithArticleCountDto> TGetCategoryWithArticleCount()
        {
            return _categoryDal.GetCategoryWithArticleCount();
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public void TInsert(Category entity)
        {
            if (entity.CategoryName != "" && entity.CategoryName.Length >= 3 && entity.CategoryName.Length <= 30)
            {
                _categoryDal.Insert(entity);
            }
            else
            {
                // hata mesajı
            }
        }

        public void TUpdate(Category entity)
        {
            if(entity.CategoryName != null)
            {
                _categoryDal.Update(entity);
            }
            else
            {
                // hata mesajı
            }
        }
    }
}
