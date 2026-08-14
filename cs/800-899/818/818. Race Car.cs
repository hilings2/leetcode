using System.Diagnostics;

public class Solution {
    private readonly Dictionary<int, int> memo = [];
    // posByN[n] = 2^n - 1, the position after n consecutive A commands
    // target is limited to 10000, so n is limited to 14
    private readonly int[] posByN = [ 0, 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383];

    public int Racecar(int target) {
        if (memo.TryGetValue(target, out int value)) {
            return value;
        }
        int n = 0;
        while (posByN[n] < target) n++;
        if (posByN[n] == target) {
            memo[target] = n;
            return n;
        }
        int result = n + 1 + Racecar(posByN[n] - target);   // overshoot and reverse
        for (int m = 0; m < n - 1; m++) {   // A for n-1 times, R, A for m times, R, then go to target
            result = Math.Min(result, n - 1 + 1 + m + 1 + Racecar(target - (posByN[n - 1] - posByN[m])));
        }
        memo[target] = result;
        return result;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int target = 3;
        Debug.Assert(sol.Racecar(target) == 2);

        target = 6;
        Debug.Assert(sol.Racecar(target) == 5);

        Console.WriteLine("passed");
    }
}
