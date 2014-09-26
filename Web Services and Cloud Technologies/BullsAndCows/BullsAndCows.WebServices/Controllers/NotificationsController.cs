namespace BullsAndCows.WebServices.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;

    using BullsAndCows.Data.Contracts;
    using BullsAndCows.Models;
    using BullsAndCows.WebServices.DataModels;

    using Microsoft.AspNet.Identity;

    using WebGrease.Css.Extensions;

    public class NotificationsController : BaseController
    {
        private const int PageSize = 10;

        public NotificationsController(IBullsAndCowsData bullsAndCowsData)
            : base(bullsAndCowsData)
        {
        }

        public NotificationsController()
        {
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(0);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult All(int page)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.BullsAndCowsData.Users.All().First(u => u.Id == userId);

            var result =
                this.BullsAndCowsData.Notifications.All()
                    .Where(n => n.User.Id == userId)
                    .OrderByDescending(n => n.DateCreated)
                    .Skip(page * PageSize)
                    .Take(PageSize);

            var resultToReturn = this.Json(result.Select(NotificationModel.FromNotification).ToList());

            result.ForEach(n => n.State = NotificationState.Read);
            this.BullsAndCowsData.SaveChanges();

            return resultToReturn;
        }

        [Authorize]
        [HttpGet]
        [Route("api/Notifications/Next")]
        public IHttpActionResult Next()
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.BullsAndCowsData.Users.All().First(u => u.Id == userId);

            var notifications =
                this.BullsAndCowsData.Notifications.All().Where(n => n.User.Id == user.Id && n.State == NotificationState.Unread).OrderBy(n => n.DateCreated);

            var notificationToReturn = notifications.Select(NotificationModel.FromNotification).FirstOrDefault();

            if (notificationToReturn == null)
            {
                return this.StatusCode(HttpStatusCode.NotModified);
            }

            var resultAsJson = this.Json(notificationToReturn);

            notifications.First().State = NotificationState.Read;
            this.BullsAndCowsData.SaveChanges();

            return resultAsJson;
        }
    }
}