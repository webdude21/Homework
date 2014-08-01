namespace PhonebookConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhonebookRepositorySlow : IPhonebookRepository
    {
        private readonly List<PhoneContact> phonebookEntries = new List<PhoneContact>();

        public bool AddPhone(string contactName, IEnumerable<string> phoneNumbers)
        {
            var old = from e in this.phonebookEntries where string.Equals(e.Name, contactName, StringComparison.InvariantCultureIgnoreCase) select e;
            var record = old.FirstOrDefault();

            if (record == null)
            {
                var obj = new PhoneContact(contactName);

                foreach (var phoneNumber in phoneNumbers)
                {
                    obj.PhoneEntries.Add(phoneNumber);
                }

                this.phonebookEntries.Add(obj);
                return true;
            }

            foreach (var phoneNumber in phoneNumbers)
            {
                record.PhoneEntries.Add(phoneNumber);
            }

            return false;
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var phoneEntriesWithOldNumber = from entry in this.phonebookEntries where entry.PhoneEntries.Contains(oldNumber) select entry;

            var entries = phoneEntriesWithOldNumber as IList<PhoneContact> ?? phoneEntriesWithOldNumber.ToList();
            foreach (var entry in entries)
            {
                entry.PhoneEntries.Remove(oldNumber);
                entry.PhoneEntries.Add(newNumber);
            }

            return entries.Count();
        }

        public IEnumerable<PhoneContact> ListEntries(int startingNumber, int numbersCount)
        {
            if (startingNumber < 0 || startingNumber + numbersCount > this.phonebookEntries.Count)
            {
                throw new ArgumentOutOfRangeException("startingNumber", "Invalid start index or count.");
            }

            this.phonebookEntries.Sort();
  
            return this.phonebookEntries.GetRange(startingNumber, numbersCount);
        }
    }
}