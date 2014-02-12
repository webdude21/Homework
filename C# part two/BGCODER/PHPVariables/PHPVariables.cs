using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class PHPVariables
{
    static void Main()
    {
        string currentLine = null;
        List<string> variables = new List<string>();
        StringBuilder input = new StringBuilder();

        while (currentLine != "?>")
        {
            currentLine = Console.ReadLine().Trim();
            input.Append("\r\n");
            input.Append(currentLine);
        }

        string vars = @"(?<!\\\$)(?<=\$)\w+|(?<=\\\\\$)(?<=\$)\w+";
        string comments = @"(?<![""']+)/\*[^\*/]+\*/|(?<![""']+)//.*|#.*";

        string output = Regex.Replace(input.ToString(), comments, "", RegexOptions.IgnoreCase);
        MatchCollection matches = Regex.Matches(output, vars, RegexOptions.IgnorePatternWhitespace);
        foreach (Match match in matches)
        {
            if (!variables.Contains(match.ToString()))
            {
                variables.Add(match.ToString());
            }
        }
        Console.WriteLine(variables.Count);
        foreach (string var in variables)
        {
            Console.WriteLine(var);
        }
    }
}