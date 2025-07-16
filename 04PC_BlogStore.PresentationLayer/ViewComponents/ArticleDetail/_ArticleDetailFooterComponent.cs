using _04PC_BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents.ArticleDetail
{
    public class _ArticleDetailFooterComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleDetailFooterComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetLast3Articles();
            return View(values);
        }
    }
}
