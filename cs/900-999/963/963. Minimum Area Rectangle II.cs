using System.Diagnostics;

public class Solution {
    public double MinAreaFreeRect(int[][] points) {
        // Group point pairs (potential diagonals) by shared midpoint and equal length.
        Dictionary<(int, int, long), List<((int, int), (int, int))>> map = [];
        double minArea = double.MaxValue;
        for (int i = 0; i < points.Length; i++) {
            for (int j = i + 1; j < points.Length; j++) {
                (int x1, int y1) = (points[i][0], points[i][1]);
                (int x2, int y2) = (points[j][0], points[j][1]);
                (int midX, int midY) = (x1 + x2, y1 + y2);   // doubled midpoint (kept integer)
                long ddx = x1 - x2, ddy = y1 - y2;
                long diag = ddx * ddx + ddy * ddy;           // squared diagonal length (long avoids overflow)
                if (!map.ContainsKey((midX, midY, diag)))
                {
                    map[(midX, midY, diag)] = [];
                }  
                // Any stored pair with the same key is the other diagonal -> forms a rectangle.
                foreach (((int x3, int y3), (int x4, int y4)) in map[(midX, midY, diag)]) {
                    long dx1 = x1 - x3, dy1 = y1 - y3;
                    long dx2 = x1 - x4, dy2 = y1 - y4;
                    // Two adjacent sides from p1 to the other diagonal's endpoints.
                    double area = Math.Sqrt(dx1 * dx1 + dy1 * dy1) * Math.Sqrt(dx2 * dx2 + dy2 * dy2);
                    minArea = Math.Min(minArea, area);
                }
                map[(midX, midY, diag)].Add(((x1, y1), (x2, y2)));                
            }
        }
        return minArea == double.MaxValue ? 0 : minArea; // no rectangle found -> 0
    }
}

class Program {
    const double Epsilon = 1e-5;

    static void Main(string[] args) {
        Solution sol = new();

        int[][] points = [[1, 2], [2, 1], [1, 0], [0, 1]];
        Debug.Assert(Math.Abs(sol.MinAreaFreeRect(points) - 2.00000) < Epsilon);

        points = [[0, 1], [2, 1], [1, 1], [1, 0], [2, 0]];
        Debug.Assert(Math.Abs(sol.MinAreaFreeRect(points) - 1.00000) < Epsilon);

        points = [[0, 3], [1, 2], [3, 1], [1, 3], [2, 1]];
        Debug.Assert(Math.Abs(sol.MinAreaFreeRect(points) - 0) < Epsilon);

        Console.WriteLine("passed");
    }
}
