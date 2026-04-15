using System.Diagnostics;

public class Solution
{
    public int MinSwap(int[] nums1, int[] nums2)
    {
        int swap = 1, notSwap = 0, min = Math.Min(swap, notSwap);
        for (int i = 1; i < nums1.Length; i++)
        {
            if (nums1[i] <= nums1[i - 1] || nums2[i] <= nums2[i - 1]) // must swap
            {   // opposite of the previous swap
                int tmp = swap;
                swap = notSwap + 1;
                notSwap = tmp;
            }
            else if (nums1[i] <= nums2[i - 1] || nums2[i] <= nums1[i - 1]) // must not swap
            {   // same as the previous swap
                swap = swap + 1;
            }
            else // OK to swap or not swap
            {
                swap = min + 1;
                notSwap = min;
            }
            min = Math.Min(swap, notSwap);
        }
        return min;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] nums1 = [1, 3, 5, 4];
        int[] nums2 = [1, 2, 3, 7];
        Debug.Assert(sol.MinSwap(nums1, nums2) == 1);

        nums1 = [0, 3, 5, 8, 9];
        nums2 = [2, 1, 4, 6, 9];
        Debug.Assert(sol.MinSwap(nums1, nums2) == 1);

        nums1 = [4, 2, 3];
        nums2 = [1, 5, 6];
        Debug.Assert(sol.MinSwap(nums1, nums2) == 1);

        nums1 = [4, 2, 3, 7, 8, 6];
        nums2 = [1, 5, 6, 4, 5, 9];
        Debug.Assert(sol.MinSwap(nums1, nums2) == 3);

        nums1 = [0, 4, 4, 5, 9];
        nums2 = [0, 1, 6, 8, 10];
        Debug.Assert(sol.MinSwap(nums1, nums2) == 1);

        nums1 = [0, 7, 8, 10, 10, 11, 12, 13, 19, 18];
        nums2 = [4, 4, 5, 7, 11, 14, 15, 16, 17, 20];
        Debug.Assert(sol.MinSwap(nums1, nums2) == 4);
    }
}
