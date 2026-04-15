using System.Diagnostics;

public class Solution
{
    public int ProjectionArea(int[][] grid)
    {
        int n = grid.Length;
        int xy = 0, xz = 0, yz = 0;
        for (int i = 0; i < n; i++)
        {
            int maxZperX = 0, maxZperY = 0;
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] > 0)
                {
                    xy++;
                }
                maxZperX = Math.Max(maxZperX, grid[i][j]);  // max z for each x
                maxZperY = Math.Max(maxZperY, grid[j][i]);  // max z for each y
            }
            xz += maxZperX;
            yz += maxZperY;
        }
        return xy + xz + yz;
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
            [3, 4]
        ];
        Debug.Assert(sol.ProjectionArea(grid) == 17);

        grid = [[2]];
        Debug.Assert(sol.ProjectionArea(grid) == 5);

        grid =
        [
            [1, 0],
            [0, 2]
        ];
        Debug.Assert(sol.ProjectionArea(grid) == 8);
    }
}
