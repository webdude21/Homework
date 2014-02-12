//  Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds
//  a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

using System;
namespace Attributes
{
    [AttributeVersion("3.8")]
    class Attributes
    {
        static void Main(string[] args)
        {
            object[] versionAttributes = typeof(Attributes).GetCustomAttributes(typeof(AttributeVersion), false);

            Console.WriteLine("Current version: {0}", versionAttributes[0]);
        }
    }
}
