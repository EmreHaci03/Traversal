using Microsoft.AspNetCore.Mvc;
using Traversal.DataAccessLayer.Concrete;

namespace Traversal.WebUI.ViewComponents.Default
{
    public class StatsViewComponent:ViewComponent
    {
        private readonly TraversalContext traversalContext;

        public StatsViewComponent(TraversalContext traversalContext)
        {
            this.traversalContext = traversalContext;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.DestinationCount = traversalContext.Destinations.Count();
            ViewBag.GuideCount = traversalContext.Guides.Count();
            ViewBag.TestimonialCount = traversalContext.Testimonials.Count();
            return View();
        }
    }
}
