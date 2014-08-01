namespace PhonebookConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    internal class RepositoryPhonebook : IPhonebookRepository
    {
        private readonly IDictionary<string, PhoneContact> entriesByName = new Dictionary<string, PhoneContact>();

        private readonly MultiDictionary<string, PhoneContact> entriesByPhone = new MultiDictionary<string, PhoneContact>(false);

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

        public PhoneContact[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.entriesByName.Count)
            {
                Console.WriteLine("Invalid start index or count.");
                return null;
            }

            var list = new PhoneContact[num];

            for (var i = first; i <= first + num - 1; i++)
            {
                var entry = this.sortedEntries[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}