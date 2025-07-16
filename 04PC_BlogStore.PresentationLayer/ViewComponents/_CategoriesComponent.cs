using _04PC_BlogStore.BusinessLayer.Abstract;
using _04PC_BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents
{
    public class _CategoriesComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoriesComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }
    }
}
