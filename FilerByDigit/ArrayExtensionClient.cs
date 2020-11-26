using System;
using System.Collections.Generic;

namespace FilterByDigit
{
    public static partial class ArrayExtension
    {
        private static int digit;

        public static int Digit
        {
            get => digit;
            set
            { 
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                digit = value;
            }
        }

        static partial void AddAccordingToPredicate(ICollection<int> collection, int item)
        {
            Digit = item;
        }
    }
}
