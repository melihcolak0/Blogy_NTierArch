using _04PC_BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents.ArticleDetail
{
    public class _ArticleDetailArticleCategoryComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleDetailArticleCategoryComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _articleService.TGetArticleWithCategory(id);
            return View(values);
        }
    }
}
