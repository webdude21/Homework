namespace CalendarSystem.Contracts
{
    using CalendarSystem.Commands;

    public interface ICommandParser
    {
        Command Parse(string arguments);
    }
}