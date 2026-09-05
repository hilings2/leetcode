using System.Diagnostics;

public class Solution {
    public long FindKthSmallest(int[] coins, int k) {
        long left = 1, right = (long)coins.Min() * k;
        while (left < right) {
            long mid = left + (right - left) / 2;
            if (Count(coins, mid) >= k) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return left;
    }
    
    private static long Count(int[] coins, long amount) {
        long count = 0;
        for (int mask = 1; mask < (1 << coins.Length); mask++) {
            long lcm = 1;
            int selectedCount = 0;
            for (int i = 0; i < coins.Length; i++) {
                if ((mask & (1 << i)) == 0) {
                    continue;
                }
                selectedCount++;
                long gcd = Gcd(lcm, coins[i]);
                long factor = coins[i] / gcd;
                if (lcm > amount / factor) {
                    lcm = amount + 1;
                    break;
                }
                lcm *= factor;
            }
            long multiples = amount / lcm;
            if (selectedCount % 2 == 1) {
                count += multiples;
            } else {
                count -= multiples;
            }
        }
        return count;
    }

    private static long Gcd(long a, long b) {
        while (b != 0) {
            long remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] coins = [3, 6, 9];
        int k = 3;
        Debug.Assert(sol.FindKthSmallest(coins, k) == 9);

        coins = [5, 2];
        k = 7;
        Debug.Assert(sol.FindKthSmallest(coins, k) == 12);

        Console.WriteLine("passed");
    }
}