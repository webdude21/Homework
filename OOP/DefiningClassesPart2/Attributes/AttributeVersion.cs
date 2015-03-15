//  Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds
//  a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Enum)]
    internal class AttributeVersion : Attribute
    {
        public AttributeVersion(string version)
        {
            this.Version = version;
        }

        public string Version { get; private set; }

        public override string ToString()
        {
            return this.Version;
        }
    }
}