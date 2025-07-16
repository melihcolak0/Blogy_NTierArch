using _04PC_BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents.ArticleDetail
{
    public class _ArticleDetailCommentListComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ArticleDetailCommentListComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetCommentsByArticle(id);
            return View(values);
        }
    }
}
