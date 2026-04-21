using System.Diagnostics;

public class Solution {
    public int[] SortArray(int[] nums) {
        MergeSort(nums, 0, nums.Length-1);
        return nums;
    }

    private static void MergeSort(int[] nums, int left, int right)
    {
        if (left >= right) return;
        int mid = left + (right - left) / 2;
        MergeSort(nums, left, mid); // [left, mid] is sorted
        MergeSort(nums, mid+1, right); // [mid+1, right] is sorted
        Merge(nums, left, mid, right); // merge in place
    }

    private static void Merge(int[] nums, int left, int mid, int right)
    {
        int[] sorted = new int[right+1-left];
        for (int i = left, j = mid+1, k = 0; i <= mid || j <= right; k++)
        {
            if (i <= mid && j <= right)
            {
                sorted[k] = nums[i] <= nums[j] ? nums[i++] : nums[j++];
            }
            else if (i <= mid)
            {
                sorted[k] = nums[i++];
            }
            else
            {
                sorted[k] = nums[j++];
            }
        }
        for (int k = 0; k < sorted.Length; k++)
        {
            nums[left+k] = sorted[k];
        }
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [5, 2, 3, 1];
        Debug.Assert(sol.SortArray(nums).SequenceEqual([1, 2, 3, 5]));

        nums = [5, 1, 1, 2, 0, 0];
        Debug.Assert(sol.SortArray(nums).SequenceEqual([0, 0, 1, 1, 2, 5]));

        Console.WriteLine("passed");
    }
}
