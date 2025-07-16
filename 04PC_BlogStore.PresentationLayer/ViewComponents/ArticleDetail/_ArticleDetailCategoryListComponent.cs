using _04PC_BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents.ArticleDetail
{
    public class _ArticleDetailCategoryListComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _ArticleDetailCategoryListComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetCategoryWithArticleCount();
            return View(values);
        }
    }
}
