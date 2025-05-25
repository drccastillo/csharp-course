using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Recursion
{
    public static class ArrayMethods
    {
        public static int Sum(int[] numbers, int index = 0)
        {
            if (index == numbers.Length)
            {
                return 0;
            }

            return numbers[index] + Sum(numbers, index + 1);
        }
    }
}
