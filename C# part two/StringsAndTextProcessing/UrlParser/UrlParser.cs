// Write a program that parses an URL address given in the format:
// and extracts from it the [protocol], [server] and [resource] elements. For example from 
// the URL http://www.devbg.org/forum/index.php the following information should be extracted:
// [protocol] = "http"
// [server] = "www.devbg.org"
// [resource] = "/forum/index.php"

using System;
using System.Text.RegularExpressions;

class UrlParser
{
    static void Main()
    {
        string input = "ftp://www.devbg.org/forum/index.php";
        Console.WriteLine("The easy way: ");
        GetURLEasy(input);
        Console.WriteLine("The regex way: ");
        GetURLRegEX(input);
    }

    static void GetURLEasy(string input)
    {
        Uri uri = new Uri(input);
        Console.WriteLine("This is the protocol: '{0}'\r\nThis is the server: '{1}'\r\nThis is the resource: '{2}'", uri.Scheme, uri.Host, uri.AbsolutePath);
    }

    static void GetURLRegEX(string input)
    {
        Match result = Regex.Match(input, @"(?<protocol>https?|ftp)://(?<server>[^/]+)/(?<resource>.*)", RegexOptions.IgnoreCase);
        Console.WriteLine("This is the protocol: '{0}'\r\nThis is the server: '{1}'\r\nThis is the resource: '{2}'", result.Groups["protocol"].Value,
            result.Groups["server"].Value, result.Groups["resource"].Value);

        // Here's the explination of the following regex: (?<protocol>https?|ftp)://(?<server>[^/]+)/(?<resource>.*)
        // Match the regular expression below and capture its match into backreference with name “protocol” «(?<protocol>https?|ftp)»
        //    Match either the regular expression below (attempting the next alternative only if this one fails) «https?»
        //       Match the characters “http” literally «http»
        //       Match the character “s” literally «s?»
        //          Between zero and one times, as many times as possible, giving back as needed (greedy) «?»
        //    Or match regular expression number 2 below (the entire group fails if this one fails to match) «ftp»
        //       Match the characters “ftp” literally «ftp»
        // Match the characters “://” literally «://»
        // Match the regular expression below and capture its match into backreference with name “server” «(?<server>[^/]+)»
        //    Match any character that is NOT a “/” «[^/]+»
        //       Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
        // Match the character “/” literally «/»
        // Match the regular expression below and capture its match into backreference with name “resource” «(?<resource>.*)»
        //    Match any single character that is not a line break character «.*»
        //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
    }
}