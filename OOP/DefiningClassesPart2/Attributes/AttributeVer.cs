//  Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds
//  a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

using System;

[AttributeUsage(
    AttributeTargets.Struct |
    AttributeTargets.Class |
    AttributeTargets.Interface |
    AttributeTargets.Method |
    AttributeTargets.Enum
)]
class AttributeVersion : System.Attribute
{
    public string Version { get; private set; }

    public override string ToString()
    {
        return this.Version;
    }

    public AttributeVersion(string version)
    {
        this.Version = version;
    }
}