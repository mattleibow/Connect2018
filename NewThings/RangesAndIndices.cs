using System;

namespace NewThings
{
    public class RangesAndIndices
    {
        private static readonly int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public int SelectFromStart(int index)
        {
            Index fromStart = index;

            return numbers[index];
        }

        public int SelectFromEnd(int index)
        {
            Index fromEnd = ^index;

            return numbers[fromEnd];
        }

        public int[] SelectRange(int start, int end)
        {
            Range range = start..end;

            return numbers[start..end];
        }
    }
}
