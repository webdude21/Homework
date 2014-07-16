namespace GenericRangeException
{
    using System;

    internal class InvalidRangeException<T> : Exception
    {
        public InvalidRangeException(T start, T end, Exception innerException = null)
            : base("Out of range!", innerException)
        {
            this.Start = start;
            this.End = end;
        }

        public T Start { get; protected set; }

        public T End { get; protected set; }
    }
}