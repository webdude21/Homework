using System.Text;

public static class StringBuilderExtension
{
    public static string SubString(this StringBuilder sb, int startindex)
    {
        return sb.ToString().Substring(startindex);
    }
    public static string SubString(this StringBuilder sb, int startindex, int lenght)
    {
        return sb.ToString().Substring(startindex, lenght);
    }
}