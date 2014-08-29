namespace CSharpCleanCode
{
    using System;
    using System.Text;

    internal class CSharpCleanCode
    {
        private static StringBuilder output = new StringBuilder();

        private static bool inString;

        private static bool inMultiLineComment;

        private static bool escaping;

        private static bool escapeAll;

        private static void Main()
        {
            var inputLines = int.Parse(Console.ReadLine());
            for (var i = 0; i < inputLines; i++)
            {
                ManageLine(Console.ReadLine());
            }

            Console.WriteLine(output);
        }

        private static void ManageLine(string line)
        {
            var onlyWhiteSpace = true;
            escaping = false;
            var whiteSpace = 0;

            if (!escapeAll)
            {
                inString = false;
            }

            for (var ch = 0; ch < line.Length; ch++)
            {
                CheckForString(line, ch);
                CheckForEscaping(line, ch);
                if (line[ch] == '@' && line[ch + 1] == '"')
                {
                    escapeAll = true;
                }

                if (!inString && line[ch] == '/')
                {
                    if (ch + 1 < line.Length && line[ch + 1] == '/' && !inMultiLineComment)
                    {
                        CleanWhiteSpace(onlyWhiteSpace, whiteSpace);
                        return;
                    }

                    if (ch + 1 < line.Length && line[ch + 1] == '*')
                    {
                        inMultiLineComment = true;
                        ch++;
                    }
                }

                if (!inMultiLineComment)
                {
                    if (line[ch] != ' ' && line[ch] != '\t' || inString)
                    {
                        onlyWhiteSpace = false;
                    }
                    else if (!inString)
                    {
                        whiteSpace++;
                    }

                    output.Append(line[ch]);
                }

                if (!inString && inMultiLineComment && line[ch] == '*')
                {
                    if (ch + 1 < line.Length && line[ch + 1] == '/')
                    {
                        inMultiLineComment = false;
                        ch++;
                    }
                }
            }

            CleanWhiteSpace(onlyWhiteSpace, whiteSpace);
        }

        private static void CleanWhiteSpace(bool onlyWhiteSpace, int whiteSpace)
        {
            if (onlyWhiteSpace)
            {
                output.Remove(output.Length - whiteSpace, whiteSpace);
            }

            if (!onlyWhiteSpace && !inMultiLineComment)
            {
                output.AppendLine();
            }
        }

        private static void CheckForEscaping(string line, int ch)
        {
            if (!escapeAll && line[ch] == '\\' && inString)
            {
                escaping = true;
            }
            else
            {
                escaping = false;
            }
        }

        private static void CheckForString(string line, int ch)
        {
            if (line[ch] == '"' && !inString && !inMultiLineComment)
            {
                inString = true;
            }
            else if (line[ch] == '"' && inString && !escaping)
            {
                inString = false;
                escapeAll = false;
            }
        }
    }
}