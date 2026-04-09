using System.Diagnostics;
using System.Drawing;

public class Solution
{
    private static readonly List<(int dx, int dy)> directions = new() { (-1, 0), (1, 0), (0, -1), (0, 1)};

    public int LargestIsland(int[][] grid)
    {
        int n = grid.Length;
        // ((i,j) => island index, 0 for unvisited, >0 for island index)
        int[,] coordToIslandIndex = new int[n, n];
        // island index => island area, island index starts from 1
        List<int> islandAreas = new List<int>{-1};

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 0 || coordToIslandIndex[i, j] > 0)
                {
                    continue;
                }
                traverseIsland(grid, coordToIslandIndex, islandAreas, (i, j));
            }
        }
        int maxArea = connectedIslandArea(grid, coordToIslandIndex, islandAreas);
        return maxArea == 0 ? n * n : maxArea;
    }

    private void traverseIsland(int[][] grid, int[,] coordToIslandIndex, List<int> islandAreas, (int i, int j) start)
    {
        int n = grid.Length;
        int area = 0;
        int islandIndex = islandAreas.Count;
        Queue<(int i, int j)> q = new();
        q.Enqueue(start);
        while (q.Count > 0)
        {
            (int i, int j) = q.Dequeue();
            if (coordToIslandIndex[i, j] > 0)
            {
                continue;
            }
            coordToIslandIndex[i, j] = islandIndex;
            area++;

            foreach ((int dx, int dy) in directions)
            {
                int ii = i + dx, jj = j + dy;
                if (ii >= 0 && ii < n && jj >= 0 && jj < n && grid[ii][jj] == 1 && coordToIslandIndex[ii, jj] == 0)
                {
                    q.Enqueue((ii, jj));
                }
            }
        }
        islandAreas.Add(area);
    }

    private int connectedIslandArea(int[][] grid, int[,] coordToIslandIndex, List<int> islandAreas)
    {
        int n = grid.Length;
        int maxArea = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    continue;
                }
                // traverse 0 to find and connect neighbor islands
                HashSet<int> neighborIslands = new();
                foreach ((int dx, int dy) in directions)
                {
                    int ii = i + dx, jj = j + dy;
                    if (ii >= 0 && ii < n && jj >= 0 && jj < n && grid[ii][jj] == 1)
                    {
                        neighborIslands.Add(coordToIslandIndex[ii, jj]);
                    }
                }
                int area = 1;
                foreach (int islandIndex in neighborIslands)
                {
                    area += islandAreas[islandIndex];
                }
                maxArea = Math.Max(maxArea, area);
                // Console.WriteLine($"change [{i},{j}] to 1 can connect islands {string.Join(",", neighborIslands)} with total area {area}");
            }
        }
        return maxArea;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();
        int[][] grid = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
        // Debug.Assert(sol.LargestIsland(grid) == 3);

        grid = new int[][] { new int[] { 1, 1 }, new int[] { 1, 0 } };
        // Debug.Assert(sol.LargestIsland(grid) == 4);

        grid = new int[][] { new int[] { 1, 1 }, new int[] { 1, 1 } };
        // Debug.Assert(sol.LargestIsland(grid) == 4);

        grid = new int[][] { new int[] { 1, 0, 0, 1, 1 }, new int[] { 1, 0, 0, 1, 0 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 0, 1 }, new int[] { 0, 0, 0, 1, 0 } };
        Debug.Assert(sol.LargestIsland(grid) == 16);
    }
}