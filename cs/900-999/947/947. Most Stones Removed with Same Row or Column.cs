using System.Diagnostics;

public class Solution {
    public int RemoveStones(int[][] stones) {
        Dictionary<int, List<int>> rows = [], cols = [];    // stones in the same row/col
        foreach (int[] stone in stones)
        {
            (int r, int c) = (stone[0], stone[1]);
            if (!rows.ContainsKey(r)) rows[r] = [];
            if (!cols.ContainsKey(c)) cols[c] = [];
            rows[r].Add(c);
            cols[c].Add(r);    
        }
        HashSet<(int, int)> visited = [];
        int count = 0;  // how many connected components
        foreach (int[] stone in stones)
        {
            (int r, int c) = (stone[0], stone[1]);
            if (visited.Contains((r, c))) continue;
            count++;
            Queue<(int, int)> q = new([(r, c)]);
            while (q.Count > 0)
            {
                (int rr, int cc) = q.Dequeue();
                foreach (int ccc in rows[rr])
                {
                    if (visited.Contains((rr, ccc))) continue;
                    visited.Add((rr, ccc));
                    q.Enqueue((rr, ccc));
                }
                foreach (int rrr in cols[cc])
                {
                    if (visited.Contains((rrr, cc))) continue;
                    visited.Add((rrr, cc));
                    q.Enqueue((rrr, cc));
                }
            }
        }
        return stones.Length - count;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[][] stones = [[0, 0], [0, 1], [1, 0], [1, 2], [2, 1], [2, 2]];
        Debug.Assert(sol.RemoveStones(stones) == 5);

        stones = [[0, 0], [0, 2], [1, 1], [2, 0], [2, 2]];
        Debug.Assert(sol.RemoveStones(stones) == 3);

        stones = [[0, 0]];
        Debug.Assert(sol.RemoveStones(stones) == 0);

        Console.WriteLine("passed");
    }
}
