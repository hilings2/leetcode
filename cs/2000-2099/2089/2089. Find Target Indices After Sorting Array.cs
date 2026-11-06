using System.Diagnostics;

public class Solution {
    public IList<int> TargetIndices(int[] nums, int target) {
        int less = 0, equal = 0;
        foreach (int num in nums) {
            if (num < target) less++;
            else if (num == target) equal++;
        }
        List<int> result = new(equal);
        for (int i = less; i < less + equal; i++) {
            result.Add(i);
        }
        return result;
    }

    public IList<int> TargetIndices0(int[] nums, int target) {
        Array.Sort(nums);
        List<int> result = [];
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == target) result.Add(i);
        }
        return result;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 5, 2, 3];
        int target = 2;
        Debug.Assert(sol.TargetIndices(nums, target).SequenceEqual([1, 2]));

        nums = [1, 2, 5, 2, 3];
        target = 3;
        Debug.Assert(sol.TargetIndices(nums, target).SequenceEqual([3]));

        nums = [1, 2, 5, 2, 3];
        target = 5;
        Debug.Assert(sol.TargetIndices(nums, target).SequenceEqual([4]));

        Console.WriteLine("passed");
    }
}
