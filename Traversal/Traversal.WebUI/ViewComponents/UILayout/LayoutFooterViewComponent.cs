using Microsoft.AspNetCore.Mvc;

namespace Traversal.WebUI.ViewComponents.UILayout
{
    public class LayoutFooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
