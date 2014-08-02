namespace Phonebook.Contracts
{
    public interface IOutputWritter
    {
        int Length { get; }

        void WriteOutput(string text);
    }
}