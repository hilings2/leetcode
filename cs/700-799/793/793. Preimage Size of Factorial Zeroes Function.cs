using System.Diagnostics;

public class Solution {
    public int PreimageSizeFZF(int k) {
        long x = 4 * (long)k / 5 * 5;
        while (TrailingZeroes(x) < k) {
            x += 5;
        }
        if (TrailingZeroes(x) == k) {
            return 5;
        }        
        return 0;
    }

    private int TrailingZeroes(long n) {
        int count = 0;
        while (n > 0) {
            n /= 5;
            count += (int)n;
        }
        return count;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int k = 0;
        Debug.Assert(sol.PreimageSizeFZF(k) == 5);

        k = 5;
        Debug.Assert(sol.PreimageSizeFZF(k) == 0);

        k = 3;
        Debug.Assert(sol.PreimageSizeFZF(k) == 5);

        k = 1000000000;
        Debug.Assert(sol.PreimageSizeFZF(k) == 5);

        Console.WriteLine("passed");
    }
}
