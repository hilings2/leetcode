using System.Diagnostics;

public class Solution
{
    public int MinFallingPathSum(int[][] matrix)
    {
        int n = matrix.Length;
        int[] dp = new int[n];
        for (int i = 0; i < n; i++)
        {
            int[] newDp = new int[n];
            for (int j = 0; j < n; j++)
            {
                int left = j > 0 ? dp[j - 1] : int.MaxValue;
                int up = dp[j];
                int right = j + 1 < n ? dp[j + 1] : int.MaxValue;
                int[] candidates = [left, up, right];
                newDp[j] = matrix[i][j] + candidates.Min();
            }
            dp = newDp;
        }
        return dp.Min();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[][] matrix = [[2, 1, 3], [6, 5, 4], [7, 8, 9]];
        Debug.Assert(sol.MinFallingPathSum(matrix) == 13);

        matrix = [[-19, 57], [-40, -5]];
        Debug.Assert(sol.MinFallingPathSum(matrix) == -59);

        Console.WriteLine("passed");
    }
}
