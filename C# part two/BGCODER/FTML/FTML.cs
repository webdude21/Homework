using System;
using System.Text;
using System.Text.RegularExpressions;

class FTML
{
    private const string Expression = "(?<tag><[^</]*>)(?<text>[^<]*)</[^<]*>";
    static string input;
    static void Main()
    {
        input = GetInput();
        RemoveTags();
        Console.WriteLine(input);
    }

    static void RemoveTags()
    {
        while(Regex.IsMatch(input, Expression, RegexOptions.CultureInvariant))
        {
                Match match = Regex.Match(input, Expression, RegexOptions.CultureInvariant);
                string currentTag = match.Groups["tag"].Value.ToLower();
                currentTag = currentTag.Substring(1, currentTag.Length - 2);
                string currentText = match.Groups["text"].Value;
                input = input.Replace(match.ToString(), ReplacmentText(currentTag, currentText));
        }
    }

    static string ReplacmentText(string tag, string text)
    {
        switch (tag)
        {
            case "upper":
                return text.ToUpper();
            case "lower":
                return text.ToLower();
            case "toggle":
                return ToggleLetters(text);
            case "rev":
                return ReverseString(text);
            case "del":
                return null;
            default:
                return text;
        }
    }
    static string ReverseString(string str)
    {
        if (str.Contains(Environment.NewLine))
        {
            StringBuilder output = new StringBuilder();
            string[] substrings = str.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = substrings.Length - 1; i >= 0; i--)
            {
                output.Append(ReverseOneLineString(substrings[i]));
                if (i > 0)
                {
                    output.Append(Environment.NewLine);
                }
            }

            return output.ToString();
        }
        return ReverseOneLineString(str);
    }

    static string ReverseOneLineString(string str)
    {
        var output = new StringBuilder();
        for (int i = str.Length - 1; i >= 0; i--)
        {
            output.Append(str[i]);
        }

        return output.ToString();
    }
    static string ToggleLetters(string input)
    {
        var output = new StringBuilder();

        foreach (char letter in input)
        {
            if (char.IsLower(letter))
            {
                output.Append(char.ToUpper(letter));
            }
            else if (char.IsUpper(letter))
            {
                output.Append(char.ToLower(letter));
            }
            else
            {
                output.Append(letter);
            }
        }
        return output.ToString();
    }

    static string GetInput()
    {
        var input = new StringBuilder();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            input.AppendLine(Console.ReadLine());
        }
        return input.ToString();
    }
}