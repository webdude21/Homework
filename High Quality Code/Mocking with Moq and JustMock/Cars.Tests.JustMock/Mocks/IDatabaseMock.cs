namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;

    public interface IDatabaseMock
    {
        IDatabase Data { get; }
    }
}