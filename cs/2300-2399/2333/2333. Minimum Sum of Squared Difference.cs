using System.Diagnostics;

public class Solution {
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2) {
        int n = nums1.Length;
        int[] diff = new int[n];
        for (int i = 0; i < n; i++) {
            diff[i] = Math.Abs(nums1[i] - nums2[i]);
        }
        Array.Sort(diff); // absolute differences in ascending order
        long operations = (long)k1 + k2; // total operations available
        for (int i = n - 1; i >= 0; i--) {
            long count = n - i;
            long nextLevel = i > 0 ? diff[i - 1] : 0;
            long cost = (diff[i] - nextLevel) * count; // neighbor diffs at same level cost 0
            if (operations >= cost) {
                operations -= cost;
                continue;
            }
            long wholeDrop = operations / count;
            long remainder = operations % count;
            long level = diff[i] - wholeDrop;

            long res = 0;
            for (int j = 0; j < i; j++) {
                res += (long)diff[j] * diff[j]; // those not reduced
            }
            res += (count - remainder) * level * level; // those reduced by wholeDrop
            res += remainder * (level - 1) * (level - 1); // those reduced by wholeDrop + 1
            return res;
        }
        return 0;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums1 = [1, 2, 3, 4];
        int[] nums2 = [2, 10, 20, 19];
        int k1 = 0;
        int k2 = 0;
        Debug.Assert(sol.MinSumSquareDiff(nums1, nums2, k1, k2) == 579);

        nums1 = [1, 4, 10, 12];
        nums2 = [5, 8, 6, 9];
        k1 = 1;
        k2 = 1;
        Debug.Assert(sol.MinSumSquareDiff(nums1, nums2, k1, k2) == 43);

        Console.WriteLine("passed");
    }
}
