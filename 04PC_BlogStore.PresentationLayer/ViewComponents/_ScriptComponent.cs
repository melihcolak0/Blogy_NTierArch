using Microsoft.AspNetCore.Mvc;

namespace _04PC_BlogStore.PresentationLayer.ViewComponents
{
    public class _ScriptComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
