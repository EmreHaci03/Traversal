using Microsoft.AspNetCore.Mvc;

namespace Traversal.WebUI.ViewComponents.UILayout
{
    public class LayoutHeaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
