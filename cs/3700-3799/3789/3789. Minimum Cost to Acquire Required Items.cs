using System.Diagnostics;

public class Solution {
    public long MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2) {
        int smaller = Math.Min(need1, need2);
        int larger = Math.Max(need1, need2);
        long individual = (long)need1 * cost1 + (long)need2 * cost2; // buy only individual items
        long mixed = (long)smaller * costBoth + (long)(need1 - smaller) * cost1 + (long)(need2 - smaller) * cost2; // buy shared items for the smaller need
        long shared = (long)larger * costBoth; // buy shared items for the larger need
        return Math.Min(individual, Math.Min(mixed, shared));
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int cost1 = 3;
        int cost2 = 2;
        int costBoth = 1;
        int need1 = 3;
        int need2 = 2;
        Debug.Assert(sol.MinimumCost(cost1, cost2, costBoth, need1, need2) == 3);

        cost1 = 5;
        cost2 = 4;
        costBoth = 15;
        need1 = 2;
        need2 = 3;
        Debug.Assert(sol.MinimumCost(cost1, cost2, costBoth, need1, need2) == 22);

        cost1 = 5;
        cost2 = 4;
        costBoth = 15;
        need1 = 0;
        need2 = 0;
        Debug.Assert(sol.MinimumCost(cost1, cost2, costBoth, need1, need2) == 0);

        Console.WriteLine("passed");
    }
}
