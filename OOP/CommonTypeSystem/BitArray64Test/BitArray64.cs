﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;

namespace BitArray64Test
{
    class BitArray64 : IEnumerable<int>
    {

        private const int length = 64;

        public bool UseBigEndian { get; set; }
        public ulong Number { get; set; }

        public BitArray64(ulong number = 0, bool useBigEndian = false)
        {
            this.Number = number;
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
                    yield return ((int)(this.Number >> index) & 1);
                }
            }
            else
            {
                for (int index = length - 1; index >= 0; index--)
                {
                    yield return ((int)(this.Number >> index) & 1);
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
            if (this.Number == otherNumber.Number)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return 1245 ^ this.Number.GetHashCode();
        }

        public static BitArray64 operator -(BitArray64 bitArr1, BitArray64 bitArr2)
        {
            checked
            {
                return new BitArray64(bitArr1.Number - bitArr2.Number);
            }
        }

        public static BitArray64 operator +(BitArray64 bitArr1, BitArray64 bitArr2)
        {
            checked
            {
                return new BitArray64(bitArr1.Number + bitArr2.Number);
            }
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
                        return ((int)(this.Number >> (length - index - 1)) & 1);

                    }
                    else
                    {
                        return ((int)(this.Number >> index) & 1);
                    }

                }
            }
        }
    }
}
