namespace Phonebook.Strategies
{
    using System.Linq;
    using System.Text;

    using Phonebook.Contracts;

    public class CanonicalPhoneConverter : ICanonicalPhoneConverter
    {
        private readonly string countryCode;

        public CanonicalPhoneConverter(string countryCode = "+359")
        {
            this.countryCode = countryCode;
        }

        public string ConvertToCanonical(string number)
        {
            var canonicalNumber = new StringBuilder();

            foreach (var ch in number.Where(ch => char.IsDigit(ch) || (ch == '+')))
            {
                canonicalNumber.Append(ch);
            }

            if (canonicalNumber.Length >= 2 && canonicalNumber[0] == '0' && canonicalNumber[1] == '0')
            {
                canonicalNumber.Remove(0, 1);
                canonicalNumber[0] = '+';
            }

            while (canonicalNumber.Length > 0 && canonicalNumber[0] == '0')
            {
                canonicalNumber.Remove(0, 1);
            }

            if (canonicalNumber.Length > 0 && canonicalNumber[0] != '+')
            {
                canonicalNumber.Insert(0, this.countryCode);
            }

            return canonicalNumber.ToString();
        }
    }
}