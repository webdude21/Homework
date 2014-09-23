namespace Application.Data.Contracts
{
    using Application.Models;

    public interface IAlertData
    {
        IRepository<Alert> Alerts { get; }

        void SaveChanges();
    }
}