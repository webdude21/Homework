namespace Phonebook.Contracts
{
    public interface ICommandFactory
    {
        IPhonebookCommand GetAddPhoneCommand();

        IPhonebookCommand GetChangePhoneCommand();

        IPhonebookCommand GetListPhonesCommand();
    }
}