// Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

using System;
using System.Collections.Generic;
using System.Reflection;

public static class IEnumerableExtension
{
    // I've applied many constraints on the methods so they cannot be used with an inappropriate types
    public static T Sum<T>(this IEnumerable<T> IE) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
    {
        T sum = default(T);
        foreach (T member in IE)
        {
            sum = sum + (dynamic)member;
        }
        return sum;
    }

    public static T Product<T>(this IEnumerable<T> IE) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
    {
        T product = default(T) + (dynamic)1;
        foreach (T member in IE)
        {
            product = product * (dynamic)member;
        }
        return product;
    }

    public static T Min<T>(this IEnumerable<T> IE) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
    {
        // I've used reflection to read the "MaxValue" field of the the unknown type <T> which is passed to the method
        // than I use it as starting point of finding the minimum value

        FieldInfo field = typeof(T).GetField("MaxValue", BindingFlags.Public | BindingFlags.Static);
        T min = (T)field.GetValue(null);
        foreach (T member in IE)
        {
            if (min.CompareTo(member) > 0)
            {
                min = member;
            }
        }
        return min;
    }

    public static T Max<T>(this IEnumerable<T> IE) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
    {
        // I've used reflection to read the "MinValue" field of the the unknown type <T> which is passed to the method
        // than I use it as starting point of finding the maximum value

        FieldInfo getMinValue = typeof(T).GetField("MinValue", BindingFlags.Public | BindingFlags.Static);
        T max = (T)getMinValue.GetValue(null);
        foreach (T member in IE)
        {
            if (max.CompareTo(member) < 0)
            {
                max = member;
            }
        }
        return max;
    }

    public static T Average<T>(this IEnumerable<T> IE) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
    {
        T sum = default(T);
        uint count = 0;
        foreach (T member in IE)
        {
            sum = sum + (dynamic)member;
            count++;
        }
        return (dynamic)sum / count;
    }
}
