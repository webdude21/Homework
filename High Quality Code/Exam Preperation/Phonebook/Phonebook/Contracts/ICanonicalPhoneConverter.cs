namespace Phonebook.Contracts
{
    public interface ICanonicalPhoneConverter
    {
        string ConvertToCanonical(string phoneNumber);
    }
}