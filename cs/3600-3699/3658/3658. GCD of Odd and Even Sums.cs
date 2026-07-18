using System.Diagnostics;

public class Solution {
    public int GcdOfOddEvenSums(int n) {
        int oddSum = 0, evenSum = 0;
        for (int i = 1; i <= n; i++) {
            evenSum += 2 * i;
            oddSum += 2 * i - 1;
        }
        return Gcd(oddSum, evenSum);
    }

    private static int Gcd(int a, int b) {
        if (b == 0) return a;
        return Gcd(b, a % b);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 4;
        Debug.Assert(sol.GcdOfOddEvenSums(n) == 4);

        n = 5;
        Debug.Assert(sol.GcdOfOddEvenSums(n) == 5);

        Console.WriteLine("passed");
    }
}
