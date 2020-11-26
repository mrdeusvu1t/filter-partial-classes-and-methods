using System;
using System.Collections.Generic;

namespace FilterByDigit
{
    /// <summary>
    /// Class that contains filter operations of arrays.
    /// </summary>
    public static partial class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that satisfy some predicate.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>New array of elements that satisfy some predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int[] FilterByPredicate(this int[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("array is empty");
            }

            var digit = Digit;

            int[] array = new int[source.Length];
            var j = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if ((source[i] == int.MinValue || source[i] == int.MaxValue) && digit == 0)
                {
                    continue;
                }

                if (source[i] == int.MinValue && digit != 5)
                {
                    array[j] = source[i];
                    j++;
                    continue;
                }

                var temp = Math.Abs(source[i]);
                do
                {
                    if (temp % 10 == digit)
                    {
                        array[j] = source[i];
                        j++;
                        break;
                    }

                    temp /= 10;
                }
                while (temp != 0);
            }

            return array[0..j];
        }

        /// <summary>
        /// Forms a collection of integers that match some predicate.
        /// </summary>
        /// <remarks>The predicate logic is implemented in another part of the partial class.</remarks>
        /// <param name="collection">A collection that is formed based on a predicate match.</param>
        /// <param name="item">An element that, if it contains the digit, is added to the collection.</param>
        static partial void AddAccordingToPredicate(ICollection<int> collection, int item);
    }
}
