using System.Diagnostics;

public class Solution {
    public int MinAreaRect(int[][] points) {
        HashSet<(int, int)> set = [];
        foreach (int[]p in points)
        {
            set.Add((p[0], p[1]));
        }
        int res = 0;
        for (int i = 0; i < points.Length-1; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                if (points[i][0] == points[j][0] || points[i][1] == points[j][1]) continue;
                if (!set.Contains((points[i][0], points[j][1])) || !set.Contains((points[j][0], points[i][1]))) continue;
                int s = Math.Abs(points[i][0] - points[j][0]) * Math.Abs(points[i][1] - points[j][1]);
                res = res == 0 ? s : Math.Min(res, s);
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[][] points = [[1, 1], [1, 3], [3, 1], [3, 3], [2, 2]];
        Debug.Assert(sol.MinAreaRect(points) == 4);

        points = [[1, 1], [1, 3], [3, 1], [3, 3], [4, 1], [4, 3]];
        Debug.Assert(sol.MinAreaRect(points) == 2);

        Console.WriteLine("passed");
    }
}
