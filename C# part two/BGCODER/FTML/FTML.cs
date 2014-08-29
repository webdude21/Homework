namespace FTML
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class FTML
    {
        private const string Expression = "(?<tag><[^</]*>)(?<text>[^<]*)</[^<]*>";

        private static string input;

        private static void Main()
        {
            input = GetInput();
            RemoveTags();
            Console.WriteLine(input);
        }

        private static void RemoveTags()
        {
            while (Regex.IsMatch(input, Expression, RegexOptions.CultureInvariant))
            {
                var match = Regex.Match(input, Expression, RegexOptions.CultureInvariant);
                var currentTag = match.Groups["tag"].Value.ToLower();
                currentTag = currentTag.Substring(1, currentTag.Length - 2);
                var currentText = match.Groups["text"].Value;
                input = input.Replace(match.ToString(), ReplacmentText(currentTag, currentText));
            }
        }

        private static string ReplacmentText(string tag, string text)
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

        private static string ReverseString(string str)
        {
            if (str.Contains(Environment.NewLine))
            {
                var output = new StringBuilder();
                var substrings = str.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (var i = substrings.Length - 1; i >= 0; i--)
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

        private static string ReverseOneLineString(string str)
        {
            var output = new StringBuilder();
            for (var i = str.Length - 1; i >= 0; i--)
            {
                output.Append(str[i]);
            }

            return output.ToString();
        }

        private static string ToggleLetters(string input)
        {
            var output = new StringBuilder();

            foreach (var letter in input)
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

        private static string GetInput()
        {
            var input = new StringBuilder();
            var lines = int.Parse(Console.ReadLine());
            for (var i = 0; i < lines; i++)
            {
                input.AppendLine(Console.ReadLine());
            }

            return input.ToString();
        }
    }
}