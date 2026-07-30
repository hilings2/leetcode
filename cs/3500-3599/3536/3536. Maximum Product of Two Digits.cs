using System.Diagnostics;

public class Solution {
    public int MaxProduct(int n) {
        int max1 = 0, max2 = 0;
        for (; n > 0; n /= 10) {
            int digit = n % 10;
            if (digit > max1) {
                max2 = max1;
                max1 = digit;
            } else if (digit > max2) {
                max2 = digit;
            }
        }
        return max1 * max2;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 31;
        Debug.Assert(sol.MaxProduct(n) == 3);

        n = 22;
        Debug.Assert(sol.MaxProduct(n) == 4);

        n = 124;
        Debug.Assert(sol.MaxProduct(n) == 8);

        Console.WriteLine("passed");
    }
}
