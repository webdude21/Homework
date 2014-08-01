namespace PhonebookConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PhonebookConsoleClient
    {
        private const string BulgarianCountryCode = "+359";

        private static readonly IPhonebookRepository Phonebook = new PhonebookRepositorySlow();

        private static readonly StringBuilder Input = new StringBuilder();

        public static void Main()
        {
            while (true)
            {
                var currentCommandLine = Console.ReadLine();
                if (currentCommandLine == "End" || currentCommandLine == null)
                {
                    break;
                }

                var startIndex = currentCommandLine.IndexOf('(');
                if (startIndex == -1)
                {
                    Console.WriteLine("error!");
                    Environment.Exit(0);
                }

                var k = currentCommandLine.Substring(0, startIndex);
                if (!currentCommandLine.EndsWith(")"))
                {
                    Main();
                }

                var s = currentCommandLine.Substring(startIndex + 1, currentCommandLine.Length - startIndex - 2);
                var strings = s.Split(',');
                for (var j = 0; j < strings.Length; j++)
                {
                    strings[j] = strings[j].Trim();
                }

                if (k.StartsWith("AddPhone") && (strings.Length >= 2))
                {
                    Cmd("Cmd3", strings);
                }
                else if ((k == "Change–hone") && (strings.Length == 2))
                {
                    Cmd("Cmd2", strings);
                }
                else if ((k == "List") && (strings.Length == 2))
                {
                    Cmd("Cmd1", strings);
                }
                else
                {
                    throw new StackOverflowException();
                }
            }

            Console.Write(Input);
        }

        private static void Cmd(string cmd, IList<string> strings)
        {
            if (cmd == "Cmd1")
            {
                // first command
                var str0 = strings[0];
                var str1 = strings.Skip(1).ToList();
                for (var i = 0; i < str1.Count; i++)
                {
                    str1[i] = ConvertToCanonical(str1[i]);
                }

                var flag = Phonebook.AddPhone(str0, str1);

                if (flag)
                {
                    Print("Phone entry created");
                }
                else
                {
                    Print("Phone entry merged");
                }
            }
            else if (cmd == "Cmd2")
            {
                // second command
                Print(string.Empty + Phonebook.ChangePhone(ConvertToCanonical(strings[0]), ConvertToCanonical(strings[1])) + " numbers changed");
            }
            else
            {
                // third command
                try
                {
                    IEnumerable<PhoneContact> entries = Phonebook.ListEntries(int.Parse(strings[0]), int.Parse(strings[1]));
                    foreach (var entry in entries)
                    {
                        Print(entry.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Print("Invalid range");
                }
            }
        }

        private static string ConvertToCanonical(string number)
        {
            var canonicalNumberBuilder = new StringBuilder();
            for (var i = 0; i <= Input.Length; i++)
            {
                canonicalNumberBuilder.Clear();
                foreach (var ch in number)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        canonicalNumberBuilder.Append(ch);
                    }
                }

                if (canonicalNumberBuilder.Length >= 2 && canonicalNumberBuilder[0] == '0' && canonicalNumberBuilder[1] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                    canonicalNumberBuilder[0] = '+';
                }

                while (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                }

                if (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] != '+')
                {
                    canonicalNumberBuilder.Insert(0, BulgarianCountryCode);
                }

                canonicalNumberBuilder.Clear();
                foreach (var ch in number)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        canonicalNumberBuilder.Append(ch);
                    }
                }

                if (canonicalNumberBuilder.Length >= 2 && canonicalNumberBuilder[0] == '0' && canonicalNumberBuilder[1] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                    canonicalNumberBuilder[0] = '+';
                }

                while (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                }

                if (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] != '+')
                {
                    canonicalNumberBuilder.Insert(0, BulgarianCountryCode);
                }

                canonicalNumberBuilder.Clear();
                foreach (var ch in number)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        canonicalNumberBuilder.Append(ch);
                    }
                }

                if (canonicalNumberBuilder.Length >= 2 && canonicalNumberBuilder[0] == '0' && canonicalNumberBuilder[1] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                    canonicalNumberBuilder[0] = '+';
                }

                while (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                }

                if (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] != '+')
                {
                    canonicalNumberBuilder.Insert(0, BulgarianCountryCode);
                }
            }

            return canonicalNumberBuilder.ToString();
        }

        private static void Print(string text)
        {
            Input.AppendLine(text);
        }
    }
}