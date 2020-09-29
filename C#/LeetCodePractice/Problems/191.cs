using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice.Problems.Problem191
{
    public class Solution
    {
        public int HammingWeight(uint n)
        {
            return AjustedMethod(n);
        }

        private int AjustedMethod(uint n)
        {
            uint count = 0;
            for (; n > 0; n &= (n-1))
            {
                count++;
            }
            return (int)count;
        }

        private int DummyMethod(uint n)
        {
            uint count = 0;
            while (n != 0 )
            {
                count += n %2;
                n >>= 1;
            }
            return (int)count;
        }

        
    }
}
