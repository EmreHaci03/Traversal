using Microsoft.AspNetCore.Mvc;

namespace Traversal.WebUI.ViewComponents.UILayout
{
    public class LayoutHeadViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
