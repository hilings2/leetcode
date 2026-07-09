using System.Diagnostics;

public class Solution {
    public long SumAndMultiply(int n) {
        int sum = 0;
        long x = 0;
        long place = 1;
        while (n > 0) {
            int digit = n % 10;
            if (digit != 0) {
                sum += digit;
                x += digit * place;
                place *= 10;
            }
            n /= 10;
        }
        return x * sum;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 10203004;
        Debug.Assert(sol.SumAndMultiply(n) == 12340);

        n = 1000;
        Debug.Assert(sol.SumAndMultiply(n) == 1);

        n = 0;
        Debug.Assert(sol.SumAndMultiply(n) == 0);

        Console.WriteLine("passed");
    }
}
