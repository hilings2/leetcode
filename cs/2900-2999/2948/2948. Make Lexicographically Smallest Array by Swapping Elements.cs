using System.Diagnostics;

public class Solution {
    public int[] LexicographicallySmallestArray(int[] nums, int limit) {
        List<(int value, int index)> pairs = [];
        for (int i = 0; i < nums.Length; i++) {
            pairs.Add((nums[i], i));
        }
        pairs.Sort((a, b) => a.value.CompareTo(b.value));

        // adjacent integers within limit are connected groups, and can swap freely
        List<(int start, int end)> ranges = [];
        int start = 0, end = 0;
        for (int i = 1; i < pairs.Count; i++) {
            if (pairs[i].value - pairs[i - 1].value > limit) {
                ranges.Add((start, end));
                start = i;
            }
            end = i;
        }
        ranges.Add((start, end));

        // foreach range, redistribute the values to the original indices in sorted order
        foreach ((int start, int end) range in ranges) {
            List<int> indices = [];
            for (int i = range.start; i <= range.end; i++) {
                indices.Add(pairs[i].index);
            }
            indices.Sort();
            for (int i = 0; i < indices.Count; i++) {
                nums[indices[i]] = pairs[range.start + i].value;
            }
        }
        return nums;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 5, 3, 9, 8];
        int limit = 2;
        Debug.Assert(sol.LexicographicallySmallestArray(nums, limit).SequenceEqual([1, 3, 5, 8, 9]));

        nums = [1, 7, 6, 18, 2, 1];
        limit = 3;
        Debug.Assert(sol.LexicographicallySmallestArray(nums, limit).SequenceEqual([1, 6, 7, 18, 1, 2]));

        nums = [1, 7, 28, 19, 10];
        limit = 3;
        Debug.Assert(sol.LexicographicallySmallestArray(nums, limit).SequenceEqual([1, 7, 28, 19, 10]));

        Console.WriteLine("passed");
    }
}
