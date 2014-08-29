namespace CSharpBrackets
{
    using System;
    using System.IO;
    using System.Text;

    internal class CSharpBrackets
    {
        private static string indent;

        private static int indentCount;

        private static void Main()
        {
            if (File.Exists(@"..\..\input.txt"))
            {
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
            }

            // not working
            var linesOfInput = int.Parse(Console.ReadLine()); // N
            indent = Console.ReadLine(); // S
            ReadInput(linesOfInput);
        }

        private static void ReadInput(int linesOfInput)
        {
            var sb = new StringBuilder();
            for (var currLine = 0; currLine < linesOfInput; currLine++)
            {
                sb.Append(GenIndent());
                var trimmedLine = TrimLine(Console.ReadLine());

                foreach (var ch in trimmedLine)
                {
                    if (ch == '{')
                    {
                        sb.Append(GenIndent());
                        indentCount++;
                        sb.Append(ch);
                    }
                    else if (ch == '}')
                    {
                        indentCount--;
                        sb.Append(ch);
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }

        private static string GenIndent()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < indentCount; i++)
            {
                sb.Append(indent);
            }

            return sb.ToString();
        }

        private static string TrimLine(string line)
        {
            var sb = new StringBuilder();
            var whiteSpace = false;
            var comment = false;
            for (var ch = 0; ch < line.Length - 1; ch++)
            {
                if (line[ch] == '"')
                {
                    comment = !comment;
                }

                if ((line[ch] == ' ' && line[ch + 1] == ' ') && !comment)
                {
                    whiteSpace = true;
                }
                else
                {
                    whiteSpace = false;
                }

                if (!whiteSpace)
                {
                    sb.Append(line[ch]);
                }
            }

            if (line[line.Length - 1] != ' ')
            {
                sb.Append(line[line.Length - 1]);
            }

            return sb.ToString();
        }
    }
}