using System;
using System.IO;
using System.Text;

class CSharpCleanCode
{
    static StringBuilder output = new StringBuilder();
    static bool inString = false;
    static bool inMultiLineComment = false;
    static bool escaping = false;
    static bool escapeAll = false;
    static void Main()
    {
        int inputLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < inputLines; i++)
        {
            ManageLine(Console.ReadLine());
        }
        Console.WriteLine(output);
    }

    static void ManageLine(string line)
    {
        bool onlyWhiteSpace = true;
        escaping = false;
        int whiteSpace = 0;

        if (!escapeAll)
        {
            inString = false;
        }

        for (int ch = 0; ch < line.Length; ch++)
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
                else if (ch + 1 < line.Length && line[ch + 1] == '*')
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

    static void CleanWhiteSpace(bool onlyWhiteSpace, int whiteSpace)
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

    static void CheckForEscaping(string line, int ch)
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

    static void CheckForString(string line, int ch)
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