using System.Diagnostics;

public class Solution {
    public int[] ArrayRankTransform(int[] arr) {
        int[] sorted = (int[])arr.Clone();
        Array.Sort(sorted);
        Dictionary<int, int> rank = [];
        int r = 1;
        foreach (int num in sorted) {
            if (!rank.ContainsKey(num)) {
                rank[num] = r++;
            }
        }
        int[] result = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++) {
            result[i] = rank[arr[i]];
        }
        return result;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] arr = [40, 10, 20, 30];
        Debug.Assert(sol.ArrayRankTransform(arr).SequenceEqual([4, 1, 2, 3]));

        arr = [100, 100, 100];
        Debug.Assert(sol.ArrayRankTransform(arr).SequenceEqual([1, 1, 1]));

        arr = [37, 12, 28, 9, 100, 56, 80, 5, 12];
        Debug.Assert(sol.ArrayRankTransform(arr).SequenceEqual([5, 3, 4, 2, 8, 6, 7, 1, 3]));

        Console.WriteLine("passed");
    }
}
