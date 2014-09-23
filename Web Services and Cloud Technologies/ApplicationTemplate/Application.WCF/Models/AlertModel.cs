namespace Application.WCF.Models
{
    using System;
    using System.Linq.Expressions;

    using Application.Models;

    public class AlertModel
    {
        public static Expression<Func<Alert, AlertModel>> FromModel
        {
            get
            {
                return x => new AlertModel { Id = x.Id, Content = x.Content, ExpirationDate = x.ExpirationDate };
            }
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}