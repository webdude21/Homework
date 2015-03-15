// Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

namespace ExtendIEnumerable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class EnumerableExtension
    {
        // I've applied many constraints on the methods so they cannot be used with an inappropriate types
        public static T Sum<T>(this IEnumerable<T> ie) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
        {
            var sum = default(T);
            return ie.Aggregate(sum, (current, member) => current + (dynamic)member);
        }

        public static T Product<T>(this IEnumerable<T> ie) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
        {
            T product = default(T) + (dynamic)1;
            return ie.Aggregate(product, (current, member) => current * (dynamic)member);
        }

        public static T Min<T>(this IEnumerable<T> ie) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
        {
            // I've used reflection to read the "MaxValue" field of the the unknown type <T> which is passed to the method
            // than I use it as starting point of finding the minimum value

            var field = typeof(T).GetField("MaxValue", BindingFlags.Public | BindingFlags.Static);
            var min = (T)field.GetValue(null);
            foreach (var member in ie.Where(member => min.CompareTo(member) > 0))
            {
                min = member;
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> ie) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
        {
            // I've used reflection to read the "MinValue" field of the the unknown type <T> which is passed to the method
            // than I use it as starting point of finding the maximum value

            var getMinValue = typeof(T).GetField("MinValue", BindingFlags.Public | BindingFlags.Static);
            var max = (T)getMinValue.GetValue(null);
            foreach (var member in ie.Where(member => max.CompareTo(member) < 0))
            {
                max = member;
            }
            return max;
        }

        public static T Average<T>(this IEnumerable<T> ie) where T : struct, IComparable<T>, IEquatable<T>, IConvertible
        {
            var sum = default(T);
            uint count = 0;
            foreach (var member in ie)
            {
                sum = sum + (dynamic)member;
                count++;
            }
            return (dynamic)sum / count;
        }
    }
}