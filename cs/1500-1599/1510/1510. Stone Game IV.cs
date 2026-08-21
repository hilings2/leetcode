using System.Diagnostics;

public class Solution {
    public bool WinnerSquareGame(int n) {
        bool[] memo = new bool[n + 1];
        for (int i = 1; i <= n; i++ ) {
            for (int j = 1; j * j <= i; j++) {
                if (!memo[i - j * j]) {
                    memo[i] = true;
                    break;
                }
            }
        }
        return memo[n];        
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 1;
        Debug.Assert(sol.WinnerSquareGame(n) == true);

        n = 2;
        Debug.Assert(sol.WinnerSquareGame(n) == false);

        n = 4;
        Debug.Assert(sol.WinnerSquareGame(n) == true);

        Console.WriteLine("passed");
    }
}
