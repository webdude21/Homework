namespace Phonebook.Contracts
{
    using System.Collections.Generic;

    using Phonebook;

    public interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        IEnumerable<PhoneContact> ListEntries(int startIndex, int count);
    }
}