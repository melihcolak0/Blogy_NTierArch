using _04PC_BlogStore.BusinessLayer.Abstract;
using _04PC_BlogStore.DataAccessLayer.Abstract;
using _04PC_BlogStore.EntityLayer.Entities;
using _04PC_BlogStore.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Logging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04PC_BlogStore.PresentationLayer.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;

        public AuthorController(IArticleService articleService, ICategoryService categoryService, UserManager<AppUser> userManager, ICommentService commentService, IAppUserService appUserService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
            _commentService = commentService;
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new AuthorEditViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl,
                Description = user.Description
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetProfile(AuthorEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();

            if (model.Password == model.ConfirmPassword)
            {                
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Description = model.Description;
                user.ImageUrl = model.ImageUrl;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("MyArticleList", "Author");
                }
            }

            return View();            
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            List<SelectListItem> values = (from x in _categoryService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);

            article.AppUserId = userProfile.Id;
            article.CreatedDate = DateTime.Now;
            article.Slug = GenerateSlug(article.Title);

            _articleService.TInsert(article);
            return RedirectToAction("Index", "Default");
        }

        public async Task<IActionResult> MyArticleList()
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = _articleService.TGetArticlesByAppUser(userProfile.Id);
            return View(values);
        }

        public static string GenerateSlug(string title)
        {
            string str = title.ToLowerInvariant()
                              .Replace("ı", "i")
                              .Replace("ö", "o")
                              .Replace("ü", "u")
                              .Replace("ş", "s")
                              .Replace("ç", "c")
                              .Replace("ğ", "g");
            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // özel karakterleri kaldır
            str = Regex.Replace(str, @"\s+", " ").Trim(); // fazla boşlukları tek boşluk yap
            str = str.Substring(0, str.Length <= 100 ? str.Length : 100).Trim();
            str = Regex.Replace(str, @"\s", "-"); // boşlukları tire yap
            return str;
        }

        public async Task<IActionResult> MyCommentsList() // Makalelerime Gelen Yorumlar
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = _commentService.TGetCommentsByAppUser(user.Id);
            return View(values);
        }

        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new DashboardInformationsViewModel
            {
                myTotalArticlesCount = _articleService.TGetArticleCountByAppUser(user.Id),
                myTotalCommentsCount = _commentService.TGetCommentCountByAppUser(user.Id),
                totalMemberCount = _appUserService.TGetAppUserCount(),
                totalArticleCount = _articleService.TGetTotalArticleCount(),
                Last5Articles = _articleService.TGetLast5Articles(),
                Last5Comments = _commentService.TGetLast5Comment()
            };

            return View(model);
        }
    }
}
