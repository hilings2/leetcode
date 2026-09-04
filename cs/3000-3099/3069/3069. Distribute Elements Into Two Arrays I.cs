using System.Diagnostics;

public class Solution {
    public int[] ResultArray(int[] nums) {
        List<int> arr1 = [nums[0]];
        List<int> arr2 = [nums[1]];
        for (int i = 2; i < nums.Length; i++) {
            if (arr1.Last() > arr2.Last()) {
                arr1.Add(nums[i]);
            } else {
                arr2.Add(nums[i]);
            }
        }
        return arr1.Concat(arr2).ToArray();
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [2, 1, 3];
        Debug.Assert(sol.ResultArray(nums).SequenceEqual([2, 3, 1]));

        nums = [5, 4, 3, 8];
        Debug.Assert(sol.ResultArray(nums).SequenceEqual([5, 3, 4, 8]));

        Console.WriteLine("passed");
    }
}
