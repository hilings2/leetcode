using System.Diagnostics;

public class Solution {
    private const int MOD = 1000000007;
    private int n;
    private long[] sum = [];
    private long[] lazy = [];

    private void Add(int node, int lo, int hi, int ql, int qr, long v) {
        if (qr < lo || hi < ql) return;
        if (ql <= lo && hi <= qr) {
            sum[node] += (hi - lo + 1) * v;
            lazy[node] += v;
            return;
        }
        int mid = (lo + hi) / 2;
        Push(node, lo, hi);
        Add(2 * node, lo, mid, ql, qr, v);
        Add(2 * node + 1, mid + 1, hi, ql, qr, v);
        sum[node] = sum[2 * node] + sum[2 * node + 1];
    }

    private long Query(int node, int lo, int hi, int ql, int qr) {
        if (qr < lo || hi < ql) return 0;
        if (ql <= lo && hi <= qr) return sum[node];
        int mid = (lo + hi) / 2;
        Push(node, lo, hi);
        return Query(2 * node, lo, mid, ql, qr) + Query(2 * node + 1, mid + 1, hi, ql, qr);
    }

    private void RangeAdd(int i, int j, int v) {
        Add(1, 0, n - 1, i, j, v);
    }

    private long RangeSum(int i, int j) {
        return Query(1, 0, n - 1, i, j);
    }

    private void Push(int node, int lo, int hi) {
        if (lazy[node] == 0) return;
        int mid = (lo + hi) / 2;
        sum[2 * node] += lazy[node] * (mid - lo + 1);
        lazy[2 * node] += lazy[node];
        sum[2 * node + 1] += lazy[node] * (hi - mid);
        lazy[2 * node + 1] += lazy[node];
        lazy[node] = 0;
    }

    public int SumCounts(int[] nums) {
        n = nums.Length;
        sum = new long[4 * n];
        lazy = new long[4 * n];

        Dictionary<int, int> last = []; // last occurrence of each number
        long squares = 0;
        long result = 0;
        for (int r = 0; r < n; r++) { // right end
            int p = last.TryGetValue(nums[r], out int value) ? value : -1;
            squares = (squares + 2 * RangeSum(p + 1, r) + (r - p)) % MOD;
            RangeAdd(p + 1, r, 1);
            result = (result + squares) % MOD;

            last[nums[r]] = r;
        }
        return (int)result;
    }
    
    public int SumCounts0(int[] nums) {
        long result = 0;
        for (int i = 0; i < nums.Length; i++) {
            HashSet<int> distinct = [];
            for (int j = i; j < nums.Length; j++) {
                distinct.Add(nums[j]);
                result = (result + (long)distinct.Count * distinct.Count) % MOD;
            }
        }
        return (int)result;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 1];
        Debug.Assert(sol.SumCounts(nums) == 15);

        nums = [2, 2];
        Debug.Assert(sol.SumCounts(nums) == 3);

        Console.WriteLine("passed");
    }
}
