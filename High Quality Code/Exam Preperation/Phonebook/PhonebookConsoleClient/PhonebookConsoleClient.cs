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
                var data = Console.ReadLine();
                if (data == "End" || data == null)
                {
                    // Error reading from console 
                    break;
                }

                var i = data.IndexOf('(');
                if (i == -1)
                {
                    Console.WriteLine("error!");
                    Environment.Exit(0);
                }

                var k = data.Substring(0, i);
                if (!data.EndsWith(")"))
                {
                    Main();
                }

                var s = data.Substring(i + 1, data.Length - i - 2);
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
                    str1[i] = ConvertCommand(str1[i]);
                }

                var flag = Phonebook.AddPhone(str0, str1);

                if (flag)
                {
                    Print("Phone entry created.");
                }
                else
                {
                    Print("Phone entry merged");
                }
            }
            else if (cmd == "Cmd2")
            {
                // second command
                Print(string.Empty + Phonebook.ChangePhone(ConvertCommand(strings[0]), ConvertCommand(strings[1])) + " numbers changed");
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
                catch (FormatException)
                {
                    Print("Invalid range");
                }
            }
        }

        private static string ConvertCommand(string num)
        {
            var sb = new StringBuilder();
            for (var i = 0; i <= Input.Length; i++)
            {
                sb.Clear();
                foreach (var ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        sb.Append(ch);
                    }
                }

                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                {
                    sb.Remove(0, 1);
                    sb[0] = '+';
                }

                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, BulgarianCountryCode);
                }

                sb.Clear();
                foreach (var ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        sb.Append(ch);
                    }
                }

                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                {
                    sb.Remove(0, 1);
                    sb[0] = '+';
                }

                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, BulgarianCountryCode);
                }

                sb.Clear();
                foreach (var ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        sb.Append(ch);
                    }
                }

                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                {
                    sb.Remove(0, 1);
                    sb[0] = '+';
                }

                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, BulgarianCountryCode);
                }
            }

            return sb.ToString();
        }

        private static void Print(string text)
        {
            Input.AppendLine(text);
        }
    }
}