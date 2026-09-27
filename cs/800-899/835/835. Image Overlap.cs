using System.Diagnostics;

public class Solution {
    public int LargestOverlap(int[][] img1, int[][] img2) {
        int n = img1.Length, offset = n - 1;
        int best = 0;
        int[,] counts = new int[2 * n - 1, 2 * n - 1]; // range: [-(n-1), n-1], with offset: [0, 2n-2]
        for (int r1 = 0; r1 < n; r1++) {
            for (int c1 = 0; c1 < n; c1++) {
                for (int r2 = 0; r2 < n; r2++) {
                    for (int c2 = 0; c2 < n; c2++) {
                        if (img1[r1][c1] == 1 && img2[r2][c2] == 1) {
                            int overlap = ++counts[r2 - r1 + offset, c2 - c1 + offset]; // (r2-r1, c2-c1) is a translation vector
                            best = Math.Max(best, overlap);
                        }
                    }
                }
            }
        }
        return best;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[][] img1 = [[1, 1, 0], [0, 1, 0], [0, 1, 0]];
        int[][] img2 = [[0, 0, 0], [0, 1, 1], [0, 0, 1]];
        Debug.Assert(sol.LargestOverlap(img1, img2) == 3);

        img1 = [[1]];
        img2 = [[1]];
        Debug.Assert(sol.LargestOverlap(img1, img2) == 1);

        img1 = [[0]];
        img2 = [[0]];
        Debug.Assert(sol.LargestOverlap(img1, img2) == 0);

        Console.WriteLine("passed");
    }
}