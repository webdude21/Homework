namespace Application.WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Application.Data;
    using Application.Data.Contracts;
    using Application.WCF.Models;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alerts" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alerts.svc or Alerts.svc.cs at the Solution Explorer and start debugging.
    public class Alerts : IAlerts
    {
        private readonly IAlertData alertData;

        public Alerts(IAlertData alertData)
        {
            this.alertData = alertData;
        }

        public Alerts()
            : this(new AlertData())
        {
        }

        public IEnumerable<AlertModel> GetAlerts()
        {
            return this.alertData.Alerts.All().Where(x => x.ExpirationDate > DateTime.Now).Select(AlertModel.FromModel);
        }
    }
}