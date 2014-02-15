using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BitArray64Test
{
    class BitArray64 : IEnumerable<int>
    {

        private const int length = 64;

        public bool UseBigEndian { get; set; }
        public ulong DecimalNumber { get; set; }

        public BitArray64(ulong decimalNumber = 0, bool useBigEndian = false)
        {
            this.DecimalNumber = decimalNumber;
            this.UseBigEndian = useBigEndian;
        }

        public int Length
        {
            get { return length; }
        }

        public IEnumerator<int> GetEnumerator()
        {
            if (UseBigEndian)
            {
                for (int index = 0; index < length; index++)
                {
                    yield return ((int)(this.DecimalNumber >> index) & 1);
                }
            }
            else
            {
                for (int index = length - 1; index >= 0; index--)
                {
                    yield return ((int)(this.DecimalNumber >> index) & 1);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (var bit in this)
            {
                output.Append(bit);
            }
            return output.ToString();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }
        public override bool Equals(object obj)
        {
            BitArray64 otherNumber = obj as BitArray64;
            if (this.DecimalNumber == otherNumber.DecimalNumber)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return 1245 ^ this.DecimalNumber.GetHashCode();
        }

        public static BitArray64 operator -(BitArray64 bitArr1, BitArray64 bitArr2)
        {
            return new BitArray64(bitArr1.DecimalNumber - bitArr2.DecimalNumber);
        }

        public static BitArray64 operator +(BitArray64 bitArr1, BitArray64 bitArr2)
        {
            return new BitArray64(bitArr1.DecimalNumber + bitArr2.DecimalNumber);
        }

        public int this[int index]
        {
            get
            {
                if (index >= length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    if (UseBigEndian)
                    {
                        index = length - index - 1;
                    }
                    return ((int)(this.DecimalNumber >> index) & 1);
                }
            }
            set
            {
                if (index >= length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                else if (value != 0 && value != 1)
                {
                    throw new ArgumentOutOfRangeException("The number should be either 1 or 0");
                }

                if (UseBigEndian)
                {
                    index = length - index - 1;
                }

                if (value == 1)
                {
                    this.DecimalNumber = this.DecimalNumber | ((ulong)1 << index);
                }
                else if (value == 0)
                {
                    this.DecimalNumber = this.DecimalNumber & (~((ulong)1 << index));
                }
            }
        }
    }
}
