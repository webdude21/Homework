namespace RandomDataGenerator.Contracts
{
    public interface IRandomDataGenerator
    {
        string GetStringExact(int length, string charsToUse);

        string GetStringExact(int length);

        string GetString(int min, int max);

        string GetString(int min, int max, string charsToUse);

        int GetInt(int min, int max);

        double GetDouble();

        bool GetChance(int percent);
    }
}