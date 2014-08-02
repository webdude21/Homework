namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly IDictionary<string, PhoneContact> entriesByName = new Dictionary<string, PhoneContact>();

        private readonly MultiDictionary<string, PhoneContact> entriesByPhone =
            new MultiDictionary<string, PhoneContact>(false);

        private readonly OrderedSet<PhoneContact> sortedEntries = new OrderedSet<PhoneContact>();

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            var name2 = name.ToLowerInvariant();
            PhoneContact entry;
            var flag = !this.entriesByName.TryGetValue(name2, out entry);
            if (flag)
            {
                entry = new PhoneContact(name);
                this.entriesByName.Add(name2, entry);
                this.sortedEntries.Add(entry);
            }

            foreach (var num in phoneNumbers)
            {
                this.entriesByPhone.Add(num, entry);
            }

            entry.PhoneEntries.UnionWith(phoneNumbers);
            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.entriesByPhone[oldent].ToList();
            foreach (var entry in found)
            {
                entry.PhoneEntries.Remove(oldent);
                this.entriesByPhone.Remove(oldent, entry);

                entry.PhoneEntries.Add(newent);
                this.entriesByPhone.Add(newent, entry);
            }

            return found.Count;
        }

        public IEnumerable<PhoneContact> ListEntries(int startingNumber, int phoneNumbersCount)
        {
            if (startingNumber < 0 || startingNumber + phoneNumbersCount > this.entriesByName.Count)
            {
                throw new ArgumentException("Invalid start index or count.");
            }

            return this.sortedEntries.ToList().GetRange(startingNumber, phoneNumbersCount);
        }
    }
}