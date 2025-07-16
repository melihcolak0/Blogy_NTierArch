using _04PC_BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents
{
    public class _CategoriesArticlesComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _CategoriesArticlesComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var values = _articleService.TGetArticlesByCategory(id);
            return View(values);
        }
    }
}
