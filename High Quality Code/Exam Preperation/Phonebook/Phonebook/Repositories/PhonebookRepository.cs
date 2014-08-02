namespace Phonebook.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Contracts;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly List<PhoneContact> phonebookEntries = new List<PhoneContact>();

        public bool AddPhone(string contactName, IEnumerable<string> phoneNumbers)
        {
            var phoneEntriesForThisContactName = this.GetAllPhoneEntriesByContactName(contactName);
            var phoneContactEntry = phoneEntriesForThisContactName.FirstOrDefault();
            var isNewEntry = phoneContactEntry == null;

            if (isNewEntry)
            {
                phoneContactEntry = new PhoneContact(contactName);
                this.phonebookEntries.Add(phoneContactEntry);
            }

            AddPhoneNumbersToPhoneContact(phoneNumbers, phoneContactEntry);

            return isNewEntry;
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var phoneEntriesWithOldNumber = this.RetrievePhoneEntriesWith(oldNumber);

            var entries = phoneEntriesWithOldNumber as IList<PhoneContact> ?? phoneEntriesWithOldNumber.ToList();
            foreach (var entry in entries)
            {
                entry.PhoneEntries.Remove(oldNumber);
                entry.PhoneEntries.Add(newNumber);
            }

            return entries.Count();
        }

        public IEnumerable<PhoneContact> ListEntries(int startingNumber, int phoneNumbersCount)
        {
            var isOutsideTheValidRange = startingNumber < 0
                                         || startingNumber + phoneNumbersCount > this.phonebookEntries.Count;

            if (isOutsideTheValidRange)
            {
                throw new ArgumentOutOfRangeException("startingNumber", "Invalid start index or count.");
            }

            this.phonebookEntries.Sort();

            return this.phonebookEntries.GetRange(startingNumber, phoneNumbersCount);
        }

        private static void AddPhoneNumbersToPhoneContact(IEnumerable<string> phoneNumbers, PhoneContact phoneContact)
        {
            foreach (var phoneNumber in phoneNumbers)
            {
                phoneContact.PhoneEntries.Add(phoneNumber);
            }
        }

        private IEnumerable<PhoneContact> RetrievePhoneEntriesWith(string oldNumber)
        {
            return from entry in this.phonebookEntries where entry.PhoneEntries.Contains(oldNumber) select entry;
        }

        private IEnumerable<PhoneContact> GetAllPhoneEntriesByContactName(string contactName)
        {
            return from phoneEntries in this.phonebookEntries
                   where string.Equals(phoneEntries.Name, contactName, StringComparison.InvariantCultureIgnoreCase)
                   select phoneEntries;
        }
    }
}