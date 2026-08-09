using System.Diagnostics;

public class Solution {
    public string StoneGameIII(int[] stoneValue) {
        int n = stoneValue.Length;
        int[] dp = new int[n + 1];
        for (int i = n - 1; i >= 0; i--) {
            dp[i] = int.MinValue;
            for (int j = i, take = 0; j <= i + 2 && j < n; j++) {
                take += stoneValue[j];
                dp[i] = Math.Max(dp[i], take - dp[j + 1]);
            }
        }
        if (dp[0] > 0) return "Alice";
        if (dp[0] < 0) return "Bob";
        return "Tie";
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] stoneValue = [1, 2, 3, 7];
        Debug.Assert(sol.StoneGameIII(stoneValue) == "Bob");

        stoneValue = [1, 2, 3, -9];
        Debug.Assert(sol.StoneGameIII(stoneValue) == "Alice");

        stoneValue = [1, 2, 3, 6];
        Debug.Assert(sol.StoneGameIII(stoneValue) == "Tie");

        Console.WriteLine("passed");
    }
}
