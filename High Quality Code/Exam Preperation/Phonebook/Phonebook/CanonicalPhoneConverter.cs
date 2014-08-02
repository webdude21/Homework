namespace Phonebook
{
    using System.Linq;
    using System.Text;

    public class CanonicalPhoneConverter : ICanonicalPhoneConverter
    {
        private readonly string countryCode = "+359";

        public CanonicalPhoneConverter(string countryCode)
        {
            this.countryCode = countryCode;
        }

        public CanonicalPhoneConverter()
        {
            
        }

        public string ConvertToCanonical(string number)
        {
            var canonicalNumberBuilder = new StringBuilder();

            canonicalNumberBuilder.Clear();
            foreach (var ch in number.Where(ch => char.IsDigit(ch) || (ch == '+')))
            {
                canonicalNumberBuilder.Append(ch);
            }

            if (canonicalNumberBuilder.Length >= 2 && canonicalNumberBuilder[0] == '0'
                && canonicalNumberBuilder[1] == '0')
            {
                canonicalNumberBuilder.Remove(0, 1);
                canonicalNumberBuilder[0] = '+';
            }

            while (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] == '0')
            {
                canonicalNumberBuilder.Remove(0, 1);
            }

            if (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] != '+')
            {
                canonicalNumberBuilder.Insert(0, this.countryCode);
            }

            canonicalNumberBuilder.Clear();
            foreach (var ch in number.Where(ch => char.IsDigit(ch) || (ch == '+')))
            {
                canonicalNumberBuilder.Append(ch);
            }

            if (canonicalNumberBuilder.Length >= 2 && canonicalNumberBuilder[0] == '0'
                && canonicalNumberBuilder[1] == '0')
            {
                canonicalNumberBuilder.Remove(0, 1);
                canonicalNumberBuilder[0] = '+';
            }

            while (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] == '0')
            {
                canonicalNumberBuilder.Remove(0, 1);
            }

            if (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] != '+')
            {
                canonicalNumberBuilder.Insert(0, this.countryCode);
            }

            canonicalNumberBuilder.Clear();
            foreach (var ch in number.Where(ch => char.IsDigit(ch) || (ch == '+')))
            {
                canonicalNumberBuilder.Append(ch);
            }

            if (canonicalNumberBuilder.Length >= 2 && canonicalNumberBuilder[0] == '0'
                && canonicalNumberBuilder[1] == '0')
            {
                canonicalNumberBuilder.Remove(0, 1);
                canonicalNumberBuilder[0] = '+';
            }

            while (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] == '0')
            {
                canonicalNumberBuilder.Remove(0, 1);
            }

            if (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] != '+')
            {
                canonicalNumberBuilder.Insert(0, this.countryCode);
            }

            return canonicalNumberBuilder.ToString();
        }
    }
}