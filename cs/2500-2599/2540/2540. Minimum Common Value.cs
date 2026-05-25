using System.Diagnostics;

public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        for (int i = 0, j = 0; i < nums1.Length && j < nums2.Length; )
        {
            if (nums1[i] == nums2[j])
            {
                return nums1[i];
            }
            if (nums1[i] < nums2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }
        return -1;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums1 = [1, 2, 3];
        int[] nums2 = [2, 4];
        Debug.Assert(sol.GetCommon(nums1, nums2) == 2);

        nums1 = [1, 2, 3, 6];
        nums2 = [2, 3, 4, 5];
        Debug.Assert(sol.GetCommon(nums1, nums2) == 2);

        Console.WriteLine("passed");
    }
}
