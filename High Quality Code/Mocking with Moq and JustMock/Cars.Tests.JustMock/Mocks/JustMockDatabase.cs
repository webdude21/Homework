namespace Cars.Tests.JustMock.Mocks
{
    using System.Linq;

    using Cars.Contracts;
    using Cars.Models;

    public class JustMockDatabase : DatabaseMock, IDatabase
    {
        protected override void ArrangeCarsRepositoryMock()
        {

        }
    }
}
