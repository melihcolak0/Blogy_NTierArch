using _04PC_BlogStore.BusinessLayer.Abstract;
using _04PC_BlogStore.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents.ArticleDetail
{
    public class _ArticleDetailMainCoverImageComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleDetailMainCoverImageComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var article = _articleService.TGetById(id);

            var user = _articleService.TGetAppUserByArticle(id);

            var dto = new ArticleDetailMainCoverImageViewModel
            {
                Title = article.Title,
                ImageUrl = article.ImageUrl,
                CreatedDate = article.CreatedDate,
                AuthorName = user.Name,
                AuthorSurname = user.Surname,
                AuthorImageUrl = user.ImageUrl
            };

            return View(dto);
        }
    }
}
