using System;

namespace Calculate
{

    class PerformOperation
    {

        public int Add(params int[] a)
        {
            if (a.Length == 0) return 0;
            int total = 0;
            foreach (int tota in a)
            {
                total += tota;
            }
            return total;
        }
        public int Subtract(params int[] a)
        {
            int total = 0;
            foreach (int tota in a)
            {
                total -= tota;
            }
            return total;
        }
        public int Multiply(params int[] a)
        {
            if (a.Length == 0) return 0;
            int total = 0;
            for (int i = 0; i < a.Length; i++)
            {
                total *= a[i];
            }
            return total;
        }
        public int Divide(params int[] a)
        {
            if (a.Length == 0) return 0;
            int total = 0;
            foreach (int tot in a)
            {
                total /= tot;
            }
            return total;

        }
    }
}
