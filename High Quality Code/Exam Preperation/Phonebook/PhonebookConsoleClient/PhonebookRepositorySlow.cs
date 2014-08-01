namespace PhonebookConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PhonebookRepositorySlow : IPhonebookRepository
    {
        private readonly List<PhoneContact> phonebookEntries = new List<PhoneContact>();

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            var old = from e in this.phonebookEntries where e.Name.ToLowerInvariant() == name.ToLowerInvariant() select e;

            bool flag;
            if (old.Count() == 0)
            {
                var obj = new PhoneContact();
                obj.Name = name;
                obj.PhoneEntries = new SortedSet<string>();

                foreach (var num in nums)
                {
                    obj.PhoneEntries.Add(num);
                }

                this.phonebookEntries.Add(obj);

                flag = true;
            }
            else if (old.Count() == 1)
            {
                var obj2 = old.First();
                foreach (var num in nums)
                {
                    obj2.PhoneEntries.Add(num);
                }

                flag = false;
            }
            else
            {
                Console.WriteLine("Duplicated name in the phonebook found: " + name);
                return false;
            }

            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var list = from e in this.phonebookEntries where e.PhoneEntries.Contains(oldent) select e;

            var nums = 0;
            foreach (var entry in list)
            {
                entry.PhoneEntries.Remove(oldent);
                entry.PhoneEntries.Add(newent);
                nums++;
            }

            return nums;
        }

        public PhoneContact[] ListEntries(int start, int num)
        {
            if (start < 0 || start + num > this.phonebookEntries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.phonebookEntries.Sort();
            var ent = new PhoneContact[num];
            for (var i = start; i <= start + num - 1; i++)
            {
                var entry = this.phonebookEntries[i];
                ent[i - start] = entry;
            }

            return ent;
        }
    }
}