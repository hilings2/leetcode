using System.Diagnostics;

public class Solution {
    public int ConsecutiveNumbersSum(int n) {
        int result = 0;
        for (int k = 1; k * (k + 1) / 2 <= n; k++) {
            if ((n - k * (k - 1) / 2) % k == 0) {
                result++;
            }
        }
        return result;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 5;
        Debug.Assert(sol.ConsecutiveNumbersSum(n) == 2);

        n = 9;
        Debug.Assert(sol.ConsecutiveNumbersSum(n) == 3);

        n = 15;
        Debug.Assert(sol.ConsecutiveNumbersSum(n) == 4);

        Console.WriteLine("passed");
    }
}
