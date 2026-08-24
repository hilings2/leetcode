using System.Diagnostics;

public class Solution {
    private const int MOD = 1000000007;
    public int RectangleArea(int[][] rectangles) {
        SortedSet<int> xCoordsSet = [];
        foreach (int[] rect in rectangles) {
            xCoordsSet.UnionWith([rect[0], rect[2]]);
        }
        List<int> uniqueXCoords = [.. xCoordsSet];
        long res = 0;
        for (int i = 0; i < uniqueXCoords.Count - 1; i++) { // foreach vertical strip
            int left = uniqueXCoords[i], right = uniqueXCoords[i + 1];
            long width = right - left;
            List<int[]> yIntervals = [];
            foreach (int[] rect in rectangles) {
                if (rect[0] <= left && rect[2] >= right) {
                    yIntervals.Add([rect[1], rect[3]]);
                }
            }
            if (yIntervals.Count == 0) {
                continue;
            }
            yIntervals.Sort((a, b) => a[0].CompareTo(b[0]));
            long totalHeight = 0;
            int start = yIntervals[0][0], end = yIntervals[0][1];
            for (int j = 1; j < yIntervals.Count; j++) {
                int nextStart = yIntervals[j][0], nextEnd = yIntervals[j][1];
                if (nextStart > end) {
                    totalHeight += end - start;
                    start = nextStart;
                    end = nextEnd;
                } else {
                    end = Math.Max(end, nextEnd);
                }
            }
            totalHeight += end - start;
            long area = width * totalHeight;
            res = (res + area) % MOD;
        }
        return (int)res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[][] rectangles = [[0, 0, 2, 2], [1, 0, 2, 3], [1, 0, 3, 1]];
        Debug.Assert(sol.RectangleArea(rectangles) == 6);

        rectangles = [[0, 0, 1000000000, 1000000000]];
        Debug.Assert(sol.RectangleArea(rectangles) == 49);

        Console.WriteLine("passed");
    }
}