using System.Diagnostics;

public class Solution
{
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        int[][] directions =
        [
            [0, 1],   // right
            [1, 0],   // down
            [0, -1],  // left
            [-1, 0]   // up
        ];
        int currentDirection = 0;
        int steps = 1;  // steps to walk in the current direction
        int moves = 0;  // moves walked in the current direction

        List<int[]> cells = new() { new int[] {rStart, cStart} };
        for (int i = rStart, j = cStart; cells.Count < rows * cols; )
        {
            int[] next = [i + directions[currentDirection][0], j + directions[currentDirection][1]];
            if (next[0] >= 0 && next[0] < rows && next[1] >= 0 && next[1] < cols)
            {
                cells.Add(next);
            }
            i = next[0];
            j = next[1];
            moves++;
            if (moves == steps)
            {
                moves = 0;
                currentDirection = (currentDirection + 1) % 4;
                if (currentDirection % 2 == 0)
                {
                    steps++;
                }
            }
        }
        return cells.ToArray();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int rows = 1, cols = 4, rStart = 0, cStart = 0;
        int[][] cells = sol.SpiralMatrixIII(rows, cols, rStart, cStart);
        int[][] expected = [[0,0],[0,1],[0,2],[0,3]];
        Debug.Assert(cells.Select(c => $"[{c[0]},{c[1]}]").SequenceEqual(expected.Select(e => $"[{e[0]},{e[1]}]")));

        rows = 5; cols = 6; rStart = 1; cStart = 4;
        cells = sol.SpiralMatrixIII(rows, cols, rStart, cStart);
        expected = [[1,4],[1,5],[2,5],[2,4],[2,3],[1,3],[0,3],[0,4],[0,5],[3,5],[3,4],[3,3],[3,2],[2,2],[1,2],[0,2],[4,5],[4,4],[4,3],[4,2],[4,1],[3,1],[2,1],[1,1],[0,1],[4,0],[3,0],[2,0],[1,0],[0,0]];
        Debug.Assert(cells.Select(c => $"[{c[0]},{c[1]}]").SequenceEqual(expected.Select(e => $"[{e[0]},{e[1]}]")));
    }
}
