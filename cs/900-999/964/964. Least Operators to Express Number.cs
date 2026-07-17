using System.Diagnostics;

public class Solution {
    public int LeastOpsExpressTarget(int x, int target) {
        if (x > target)
        {
            int res1 = target * 2 - 1; // x/x + x/x + ... + x/x, add 1s from 0
            int res2 = (x - target) * 2; // x - x/x - x/x - ... - x/x, subtract extra 1s from x
            return Math.Min(res1, res2);
        }
        if (x == target) return 0;

        // x < target
        int res = 0;
        long sum = x;
        while (sum < target)
        {
            sum *= x;
            res++;
        }
        if (sum == target) return res;

        int res3 = int.MaxValue;
        // Only subtract down from the higher power when the gap is smaller than target,
        // i.e. target is in the upper half (sum/2, sum]. If (sum - target >= target),
        // the gap we'd express is >= target while the build-up remainder (target - sum/x)
        // is < target; since cost is non-decreasing in the value expressed, res4 is always
        // at least as good. Skipping res3 here both avoids that dominated branch and
        // prevents infinite recursion (e.g. f(5,10) -> f(5,15) -> f(5,10) -> ...).
        if (sum - target < target)
        {
            res3 = res + 1 + LeastOpsExpressTarget(x, (int)(sum - target));    // subtract from the next higher power of x
        }
        int res4 = res - 1 + LeastOpsExpressTarget(x, target - (int)(sum / x)) + 1; // proceed to the next lower power of x, then add to the target
        return Math.Min(res3, res4);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int x = 3, target = 19;
        Debug.Assert(sol.LeastOpsExpressTarget(x, target) == 5);

        x = 5; target = 501;
        Debug.Assert(sol.LeastOpsExpressTarget(x, target) == 8);

        x = 100; target = 100000000;
        Debug.Assert(sol.LeastOpsExpressTarget(x, target) == 3);

        Console.WriteLine("passed");
    }
}
