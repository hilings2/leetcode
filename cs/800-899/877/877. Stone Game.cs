using System.Diagnostics;

public class Solution
{
    private int[,] memo;

    public bool StoneGame(int[] piles)
    {
        int n = piles.Length;
        memo = new int[n, n];   // mem for calculated results
        return dp(piles, 0, n - 1) > 0;
    }

    private int dp(int[] piles, int i, int j)   // score difference
    {
        if (i >= j)
        {
            return 0;
        }
        if (memo[i, j] != 0)
        {
            return memo[i, j];
        }
        memo[i, j] = Math.Max(
            Math.Abs(piles[i] - piles[j]) + dp(piles, i + 1, j - 1),
            Math.Max(
                piles[i] - piles[i+1] + dp(piles, i + 2, j),
                piles[j] - piles[j-1] + dp(piles, i, j - 2)
            )
        );
        return memo[i, j];
    }

    public bool StoneGame2(int[] piles)
    {
        return true;    // Alice always wins
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] piles = [5, 3, 4, 5];
        Debug.Assert(sol.StoneGame(piles) == true);
        Debug.Assert(sol.StoneGame2(piles) == true);

        piles = [3, 7, 2, 3];
        Debug.Assert(sol.StoneGame(piles) == true);
        Debug.Assert(sol.StoneGame2(piles) == true);
    }
}
