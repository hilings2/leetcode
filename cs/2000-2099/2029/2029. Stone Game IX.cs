using System.Diagnostics;

public class Solution {
    public bool StoneGameIX(int[] stones) {
        int[] counts = new int[3];
        foreach (int stone in stones) {
            counts[stone % 3]++;
        }
        // An even number of remainder-0 stones preserves turn order.
        if (counts[0] % 2 == 0) {
            return counts[1] > 0 && counts[2] > 0;
        }
        // An odd number flips turn order, requiring three excess nonzero stones.
        return Math.Abs(counts[1] - counts[2]) > 2;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] stones = [2, 1];
        Debug.Assert(sol.StoneGameIX(stones) == true);

        stones = [2];
        Debug.Assert(sol.StoneGameIX(stones) == false);

        stones = [5, 1, 2, 4, 3];
        Debug.Assert(sol.StoneGameIX(stones) == false);

        Console.WriteLine("passed");
    }
}