using _04PC_BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents
{
    public class _AuthorsComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AuthorsComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
    }
}
