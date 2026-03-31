using System.Diagnostics;

public class Solution {
    int[] _dp = new int[31];
    public Solution()
    {
        _dp[0] = 0;
        _dp[1] = 1;
        for (int i = 2; i < _dp.Length; i++)
        {
            _dp[i] = _dp[i-1] + _dp[i-2];
        }
    }
    public int Fib(int n) {
        return _dp[n];
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("LeetCode 509. Fibonacci Number, C# ...");

        Solution sol = new();
        
        int n = 2;
        Debug.Assert(sol.Fib(n) == 1, $"n = {n}, expect = 1, Actual: {sol.Fib(n)}");
        n = 3;
        Debug.Assert(sol.Fib(n) == 2, $"n = {n}, expect = 2, Actual: {sol.Fib(n)}");
        n = 4;
        Debug.Assert(sol.Fib(n) == 3, $"n = {n}, expect = 3, Actual: {sol.Fib(n)}");
    }
}