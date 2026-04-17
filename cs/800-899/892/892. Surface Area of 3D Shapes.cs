using System.Diagnostics;

public class Solution
{
    public int SurfaceArea(int[][] grid)
    {
        int r = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 0)
                {
                    continue;
                }

                r += grid[i][j] * 6 - (grid[i][j] - 1) * 2;
                if (i - 1 >= 0)
                {
                    r -= Math.Min(grid[i][j], grid[i - 1][j]);
                }
                if (j - 1 >= 0)
                {
                    r -= Math.Min(grid[i][j], grid[i][j - 1]);
                }
                if (i + 1 < grid.Length)
                {
                    r -= Math.Min(grid[i][j], grid[i + 1][j]);
                }
                if (j + 1 < grid[i].Length)
                {
                    r -= Math.Min(grid[i][j], grid[i][j + 1]);
                }
            }
        }
        return r;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[][] grid =
        [
            [1, 2],
            [3, 4],
        ];
        Debug.Assert(sol.SurfaceArea(grid) == 34);

        grid =
        [
            [1, 1, 1],
            [1, 0, 1],
            [1, 1, 1],
        ];
        Debug.Assert(sol.SurfaceArea(grid) == 32);

        grid =
        [
            [2, 2, 2],
            [2, 1, 2],
            [2, 2, 2],
        ];
        Debug.Assert(sol.SurfaceArea(grid) == 46);
    }
}