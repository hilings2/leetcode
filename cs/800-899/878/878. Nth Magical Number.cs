using System.Diagnostics;

public class Solution {
    public int NthMagicalNumber(int n, int a, int b) {
        long lcm = a * b / GCD(a, b);
        long l = 2, r = 2 * (long)1e14;
        while (l < r)
        {
            long m = l + (r-l)/2;
            if (m/a + m/b - m/lcm >= n) // how many magical numbers <= m
            {
                r = m;
            }
            else
            {
                l = m+1;
            }
        }
        return (int)(l % 1000000007);
    }

    private static int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        Debug.Assert(sol.NthMagicalNumber(1, 2, 3) == 2);

        Debug.Assert(sol.NthMagicalNumber(4, 2, 3) == 6);

        Console.WriteLine("passed");
    }
}
