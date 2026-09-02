using System.Diagnostics;

public class Solution {
    public int ShortestSubarray(int[] nums, int k) {
        long[] prefixSum = new long[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++) {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }
        int res = nums.Length + 1;
        LinkedList<int> deque = new();
        for (int i = 0; i < prefixSum.Length; i++) {
            while (deque.Count > 0 && prefixSum[i] - prefixSum[deque.First!.Value] >= k) {
                res = Math.Min(res, i - deque.First.Value);
                deque.RemoveFirst();
            }
            // such i is always better than the last in deque
            while (deque.Count > 0 && prefixSum[i] <= prefixSum[deque.Last!.Value]) {
                deque.RemoveLast();
            }
            deque.AddLast(i);
        }
        return res <= nums.Length ? res : -1;
    }

    public int ShortestSubarray0(int[] nums, int k) {
        long[] prefixSum = new long[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++) {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }
        int res = nums.Length + 1;
        for (int start = 0; start < nums.Length; start++) {
            for (int end = start + 1; end <= nums.Length; end++) {
                if (prefixSum[end] - prefixSum[start] >= k) {
                    res = Math.Min(res, end - start);
                    break;
                }
            }
        }
        return res <= nums.Length ? res : -1;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1];
        int k = 1;
        Debug.Assert(sol.ShortestSubarray(nums, k) == 1);

        nums = [1, 2];
        k = 4;
        Debug.Assert(sol.ShortestSubarray(nums, k) == -1);

        nums = [2, -1, 2];
        k = 3;
        Debug.Assert(sol.ShortestSubarray(nums, k) == 3);

        Console.WriteLine("passed");
    }
}