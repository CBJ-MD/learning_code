using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Debug.Assert(false, "what the hell!");
        }

        public int MajorityElement(int[] nums)
        {
            int[] left = nums.Take((nums.Length+1)/2).ToArray();
            int[] right = nums.TakeLast((nums.Length-1)/2).ToArray();
            int majLeft = MajorityElement(left) ;
            int majRight =  MajorityElement(right);
            if(majLeft == majRight)
            {
                return majLeft;
            }
            return left.Count(element => element == majLeft) > right.Count(element => element == majRight)? majLeft:majRight;
        }
    }
}
