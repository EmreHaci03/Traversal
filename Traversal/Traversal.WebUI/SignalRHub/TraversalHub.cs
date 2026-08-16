using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Traversal.DataAccessLayer.Concrete;

namespace Traversal.WebUI.SignalRHub
{
    public class TraversalHub:Hub
    {
        private readonly TraversalContext traversalContext;
        public TraversalHub(TraversalContext traversalContext)
        {
            this.traversalContext = traversalContext;
        }

        public async Task SendStatistic()
        {
            var destinationCount = traversalContext.Destinations.Count();
            var totalreservationCount = traversalContext.Reservations.Count();
            var approvedreservationCount = traversalContext.Reservations.Where(x => x.Status == "Onaylandı").Count();
            var holdReservationCount = traversalContext.Reservations.Where(x => x.Status == "Beklemede").Count();
            var cancelledReservationCount = traversalContext.Reservations.Where(x => x.Status == "İptal").Count();
            var userCount = traversalContext.Users.Count();
            var testimonialCount = traversalContext.Testimonials.Count();
            var favoriteCount = traversalContext.Favorites.Count();
            var commentCount = traversalContext.Comments.Count();
            await Clients.All.SendAsync("ReceiveStatistic", new
            {
                destinationCount,
                totalreservationCount,
                approvedreservationCount,
                holdReservationCount,
                cancelledReservationCount,
                userCount,
                testimonialCount,
                favoriteCount,
                commentCount
            });

        }
    }
}
