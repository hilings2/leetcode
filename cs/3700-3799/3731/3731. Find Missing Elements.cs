using System.Diagnostics;

public class Solution {
    public IList<int> FindMissingElements(int[] nums) {
        int[] exists = new int[101];
        int max = int.MinValue, min = int.MaxValue;
        foreach (int num in nums) {
            exists[num] = 1;
            (min, max) = (Math.Min(min, num), Math.Max(max, num));
        }
        List<int> missing = [];
        for (int i = min; i <= max; i++) {
            if (exists[i] == 0) {
                missing.Add(i);
            }
        }
        return missing;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 4, 2, 5];
        Debug.Assert(sol.FindMissingElements(nums).SequenceEqual([3]));

        nums = [7, 8, 6, 9];
        Debug.Assert(sol.FindMissingElements(nums).SequenceEqual([]));

        nums = [5, 1];
        Debug.Assert(sol.FindMissingElements(nums).SequenceEqual([2, 3, 4]));

        Console.WriteLine("passed");
    }
}