using System.Diagnostics;

public class Solution {
    public int SmallestNumber(int n, int t) {
        for (int i = n; i <= n + 9; i++) {
            if (ProductOfDigits(i) % t == 0) {
                return i;
            }
        }
        return 0;
    }

    private static int ProductOfDigits(int n) {
        int product = 1;
        while (n > 0) {
            product *= n % 10;
            n /= 10;
        }
        return product;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 10;
        int t = 2;
        Debug.Assert(sol.SmallestNumber(n, t) == 10);

        n = 15;
        t = 3;
        Debug.Assert(sol.SmallestNumber(n, t) == 16);

        Console.WriteLine("passed");
    }
}