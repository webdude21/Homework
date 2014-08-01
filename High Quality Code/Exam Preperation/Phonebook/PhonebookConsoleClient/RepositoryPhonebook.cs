namespace PhonebookConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    internal class RepositoryPhonebook : IPhonebookRepository
    {
        private Dictionary<string, PhoneContact> dict = new Dictionary<string, PhoneContact>();

        private MultiDictionary<string, PhoneContact> multidict = new MultiDictionary<string, PhoneContact>(false);

        private OrderedSet<PhoneContact> sorted = new OrderedSet<PhoneContact>();

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            var name2 = name.ToLowerInvariant();
            PhoneContact entry;
            var flag = !this.dict.TryGetValue(name2, out entry);
            if (flag)
            {
                entry = new PhoneContact();
                entry.Name = name;
                entry.PhoneEntries = new SortedSet<string>();
                this.dict.Add(name2, entry);

                this.sorted.Add(entry);
            }

            foreach (var num in nums)
            {
                this.multidict.Add(num, entry);
            }

            entry.PhoneEntries.UnionWith(nums);
            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.PhoneEntries.Remove(oldent);
                this.multidict.Remove(oldent, entry);

                entry.PhoneEntries.Add(newent);
                this.multidict.Add(newent, entry);
            }

            return found.Count;
        }

        public PhoneContact[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dict.Count)
            {
                Console.WriteLine("Invalid start index or count.");
                return null;
            }

            var list = new PhoneContact[num];

            for (var i = first; i <= first + num - 1; i++)
            {
                var entry = this.sorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}