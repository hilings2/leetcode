using System.Diagnostics;

public class Solution {
    public long CountCommas(long n) {
        long sum = 0;
        for (long threshold = 1000; threshold <= n; threshold *= 1000) {
            sum += n - threshold + 1;
        }
        return sum;
    }

    public long CountCommas0(long n) {
        long sum = 0;
        for (int comma = 0; comma <= 5; comma++) {
            long lower = (long)Math.Pow(1000, comma) - 1;
            long upper = Math.Min(n, (long)Math.Pow(1000, comma + 1) - 1);
            sum += comma * (upper - lower);
            if (upper == n) break;
        }
        return sum;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        long n = 1002;
        Debug.Assert(sol.CountCommas(n) == 3);

        n = 998;
        Debug.Assert(sol.CountCommas(n) == 0);

        Console.WriteLine("passed");
    }
}