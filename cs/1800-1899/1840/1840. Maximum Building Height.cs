using System.Diagnostics;

public class Solution {
    public int MaxBuilding(int n, int[][] restrictions) {
        List<int[]> list = [.. restrictions];
        list.Add([1, 0]);
        list.Add([n, n - 1]);
        list.Sort((a, b) => a[0] - b[0]);
        for (int i = 1; i < list.Count; i++)
        {
            list[i][1] = Math.Min(list[i][1], list[i-1][1] + list[i][0] - list[i-1][0]);
        }
        for (int i = list.Count - 2; i >= 0; i--)
        {
            list[i][1] = Math.Min(list[i][1], list[i+1][1] + list[i+1][0] - list[i][0]);
        }
        int res = 0;
        for (int i = 1; i < list.Count; i++)
        {
            int l = list[i-1][0], r = list[i][0];
            int h1 = list[i-1][1], h2 = list[i][1];
            int h = (h1 + h2 + r - l) / 2;
            res = Math.Max(res, h);
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 5;
        int[][] restrictions = [[2, 1], [4, 1]];
        Debug.Assert(sol.MaxBuilding(n, restrictions) == 2);

        n = 6;
        restrictions = [];
        Debug.Assert(sol.MaxBuilding(n, restrictions) == 5);

        n = 10;
        restrictions = [[5, 3], [2, 5], [7, 4], [10, 3]];
        Debug.Assert(sol.MaxBuilding(n, restrictions) == 5);

        Console.WriteLine("passed");
    }
}
