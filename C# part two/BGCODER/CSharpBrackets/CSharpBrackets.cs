using System;
using System.IO;
using System.Text;

class CSharpBrackets
{
    static string indent;
    static int indentCount;
    static void Main()
    {
        if (File.Exists(@"..\..\input.txt"))
        {
            Console.SetIn(new StreamReader(@"..\..\input.txt"));
        }
        // not working
        int linesOfInput = int.Parse(Console.ReadLine()); // N
        indent = Console.ReadLine(); // S
        ReadInput(linesOfInput);
    }

    static void ReadInput(int linesOfInput)
    {
        StringBuilder sb = new StringBuilder();
        for (int currLine = 0; currLine < linesOfInput; currLine++)
        {
            sb.Append(GenIndent());
            string trimmedLine = TrimLine(Console.ReadLine());

            foreach (char ch in trimmedLine)
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

    static String GenIndent()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < indentCount; i++)
        {
            sb.Append(indent);
        }
        return sb.ToString();
    }

    static string TrimLine(string line)
    {
        StringBuilder sb = new StringBuilder();
        bool whiteSpace = false;
        bool comment = false;
        for (int ch = 0; ch < line.Length - 1; ch++)
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
