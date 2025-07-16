using _04PC_BlogStore.BusinessLayer.Abstract;
using _04PC_BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {       
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public DefaultController(ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authors()
        {
            return View();
        }

        public IActionResult ArticlesByAuthor(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            ViewBag.authorName = user?.Name;
            ViewBag.authorSurname = user?.Surname;
            ViewBag.authorImage = user?.ImageUrl;
            ViewBag.id = id;
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult ArticlesByCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            ViewBag.categoryName = category.CategoryName;
            ViewBag.categoryImage = category.CategoryImageUrl;
            ViewBag.id = id;
            return View();
        }
    }
}
