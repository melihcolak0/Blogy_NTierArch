using _04PC_BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents.ArticleDetail
{
    public class _ArticleDetailAboutAuthorComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleDetailAboutAuthorComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var value = _articleService.TGetAppUserByArticle(id);
            return View(value);
        }
    }
}
