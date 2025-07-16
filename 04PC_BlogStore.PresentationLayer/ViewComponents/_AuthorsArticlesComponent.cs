using _04PC_BlogStore.BusinessLayer.Abstract;
using _04PC_BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents
{
    public class _AuthorsArticlesComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _AuthorsArticlesComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke(string id)
        {
            var values = _articleService.TGetArticlesByAppUser(id);
            return View(values);
        }
    }
}
