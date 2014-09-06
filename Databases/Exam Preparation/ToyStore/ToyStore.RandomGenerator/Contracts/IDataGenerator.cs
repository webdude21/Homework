namespace RandomDataGenerator.Contracts
{
    using System.Collections.Generic;

    public interface IDataGenerator<T>
    {
        HashSet<T> Generate();
    }
}