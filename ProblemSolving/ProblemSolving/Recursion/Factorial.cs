namespace ProblemSolving.Recursion
{
    /// <summary>
    /// What is recursion?
    /// It is a technique where a function or method calls itself.
    /// 
    /// Key points:
    /// - We need a base scenario (to prevent inifinite calls)
    /// - We need to keep the process small
    /// - We need to divide the problem
    /// 
    /// When ot use it?
    /// - It helps us to divide a problem
    /// - It helps to iterate over trees or graphs
    /// 
    /// </summary>
    public static class Factorial
    {
        public static int SolveFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("input should not be a negative number.");
            }

            if (n == 1 || n == 0)
            {
                return 1;
            }

            return n * SolveFactorial(n - 1);
        }
    }
}
