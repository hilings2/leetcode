using System.Diagnostics;

public class Solution {
    public int[] PrisonAfterNDays(int[] cells, int n) {
        int len = cells.Length;
        Dictionary<string, int> seen = [];
        for (int i = 0; i < n; i++) {
            int[] newCells = new int[len];
            for (int j = 1; j < len - 1; j++) {
                newCells[j] = cells[j - 1] == cells[j + 1] ? 1 : 0;
            }
            cells = newCells;
            string key = string.Join("", newCells);
            if (!seen.ContainsKey(key))
            {
                seen[key] = i;
            }
            else
            {
                int period = i - seen[key];
                i += period * ((n - 1 - i) / period);
            }
        }
        return cells;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] cells = [0, 1, 0, 1, 1, 0, 0, 1];
        Debug.Assert(sol.PrisonAfterNDays(cells, 7).SequenceEqual([0, 0, 1, 1, 0, 0, 0, 0]));

        cells = [1, 0, 0, 1, 0, 0, 1, 0];
        Debug.Assert(sol.PrisonAfterNDays(cells, 1000000000).SequenceEqual([0, 0, 1, 1, 1, 1, 1, 0]));

        cells = [1,1,0,1,1,0,0,1];
        Debug.Assert(sol.PrisonAfterNDays(cells, 300663720).SequenceEqual([0,0,1,0,0,1,1,0]));

        Console.WriteLine("passed");
    }
}
