namespace ArmyOfCreatures.Extended
{
    using System;

    internal static class Validator
    {
        internal static void CheckForNull(object someObject, string name)
        {
            if (someObject == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}