using System.Diagnostics;

public class Solution {
    public int[] MaximumWeight(IList<IList<int>> intervals) {
        int n = intervals.Count;
        (int l, int r, int w, int index)[] sorted = new (int l, int r, int w, int index)[n]; // record original index
        for (int i = 0; i < n; i++) {
            sorted[i] = (intervals[i][0], intervals[i][1], intervals[i][2], i);
        }
        Array.Sort(sorted, (a, b) => a.r.CompareTo(b.r)); // sort by ends

        int[] compatibleCount = new int[n];
        for (int current = 0; current < n; current++) {
            int low = 0, high = current;
            while (low < high) { // binary search for last interval that ends before the current one starts
                int mid = low + (high - low) / 2;
                if (sorted[mid].r < sorted[current].l) {
                    low = mid + 1;
                } else {
                    high = mid;
                }
            }
            compatibleCount[current] = low; // number of intervals compatible with the current one
        }

        // dp[count, limit] score with first 'count' intervals and at most 'limit' intervals
        (long score, int[] indices)[,] dp = new (long score, int[] indices)[n+1, 5];
        for (int count = 0; count <= n; count++) {
            dp[count, 0] = (0, []);
        }
        for (int limit = 1; limit <= 4; limit++) {
            dp[0, limit] = (0, []);
        }

        for (int count = 1; count <= n; count++) {
            int prefix = compatibleCount[count - 1];
            for (int limit = 1; limit <= 4; limit++) {
                (long skipScore, int[] skipIndices) = dp[count - 1, limit];
                (long takeScore, int[] takeIndices) = dp[prefix, limit - 1];

                takeScore += sorted[count - 1].w;
                takeIndices = [.. takeIndices, sorted[count - 1].index];
                Array.Sort(takeIndices);

                dp[count, limit] = (skipScore, skipIndices);
                if (takeScore > skipScore || (takeScore == skipScore && IsLexSmaller(takeIndices, skipIndices))) {
                    dp[count, limit] = (takeScore, takeIndices);
                }
            }
        }
        return dp[n, 4].indices;
    }

    private static bool IsLexSmaller(int[] a, int[] b) {
        int len = Math.Min(a.Length, b.Length);
        for (int index = 0; index < len; index++) {
            if (a[index] != b[index]) {
                return a[index] < b[index];
            }
        }
        return a.Length < b.Length;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        IList<IList<int>> intervals = [[1, 3, 2], [4, 5, 2], [1, 5, 5], [6, 9, 3], [6, 7, 1], [8, 9, 1]];
        Debug.Assert(sol.MaximumWeight(intervals).SequenceEqual([2, 3]));

        intervals = [[5, 8, 1], [6, 7, 7], [4, 7, 3], [9, 10, 6], [7, 8, 2], [11, 14, 3], [3, 5, 5]];
        Debug.Assert(sol.MaximumWeight(intervals).SequenceEqual([1, 3, 5, 6]));

        Console.WriteLine("passed");
    }
}