namespace PHPVariables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class PHPVariables
    {
        private static void Main()
        {
            string currentLine = null;
            var variables = new List<string>();
            var input = new StringBuilder();

            while (currentLine != "?>")
            {
                currentLine = Console.ReadLine();
                input.AppendLine(currentLine);
            }

            const string vars = @"(?<!\\\$)(?<=\$)\w+|(?<=\\\\\$)(?<=\$)\w+";
            const string comments = @"//.*|(?<![""']+)#.*|/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*/";
            var output = Regex.Replace(input.ToString(), comments, string.Empty, RegexOptions.IgnoreCase);
            var matches = Regex.Matches(output, vars, RegexOptions.IgnorePatternWhitespace);

            foreach (var match in matches.Cast<Match>().Where(match => !variables.Contains(match.ToString())))
            {
                variables.Add(match.ToString());
            }

            Console.WriteLine(variables.Count);
            foreach (var variable in variables)
            {
                Console.WriteLine(variable);
            }
        }
    }
}