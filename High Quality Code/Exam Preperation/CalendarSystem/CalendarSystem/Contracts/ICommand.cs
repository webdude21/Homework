namespace CalendarSystem.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Execute(IList<string> commandArguments);
    }
}