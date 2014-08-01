﻿namespace PhonebookConsoleClient
{
    using System.Collections.Generic;

    public interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        PhoneContact[] ListEntries(int startIndex, int count);
    }
}