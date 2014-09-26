namespace BullsAndCows.WebServices.DataModels
{
    using System;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class NotificationModel
    {
        public static Expression<Func<Notification, NotificationModel>> FromNotification
        {
            get
            {
                return x => new NotificationModel
                        {
                            Id = x.Id,
                            Message = x.Message,
                            DateCreated = x.DateCreated,
                            Type = x.Type.ToString(),
                            State = x.State.ToString(),
                            GameId = x.GameId
                        };
            }
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public int GameId { get; set; }
    }
}