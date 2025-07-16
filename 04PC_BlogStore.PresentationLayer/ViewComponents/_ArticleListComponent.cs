using _04PC_BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents
{
    public class _ArticleListComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleListComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetListWithCategories();
            return View(values);
        }
    }
}
