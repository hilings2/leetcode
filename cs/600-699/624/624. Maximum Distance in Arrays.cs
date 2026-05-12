using System.Diagnostics;

public class Solution {
    public int MaxDistance(IList<IList<int>> arrays) {
        (int min, int max) = (arrays[0][0], arrays[0][^1]);
        int res = 0;
        for (int i = 1; i < arrays.Count; i++)
        {
            res = Math.Max(res, Math.Max(arrays[i][^1] - min, max - arrays[i][0]));
            (min, max) = (Math.Min(min, arrays[i][0]), Math.Max(max, arrays[i][^1]));
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        IList<IList<int>> arrays = [[1, 2, 3], [4, 5], [1, 2, 3]];
        Debug.Assert(sol.MaxDistance(arrays) == 4);

        arrays = [[1], [1]];
        Debug.Assert(sol.MaxDistance(arrays) == 0);

        Console.WriteLine("passed");
    }
}
