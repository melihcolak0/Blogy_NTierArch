using _04PC_BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult ArticleDetail(string slug)
        {
            var article = _articleService.TGetBySlug(slug);

            ViewBag.ArticleId = article.ArticleId;

            return View();
        }
    }
}
