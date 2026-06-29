using System.Diagnostics;

public class Solution {
    public int LargestAltitude(int[] gain) {
        int alt = 0, res = 0;
        foreach (int g in gain)
        {
            alt += g;
            res = Math.Max(res, alt);
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] gain = [-5, 1, 5, 0, -7];
        Debug.Assert(sol.LargestAltitude(gain) == 1);

        gain = [-4, -3, -2, -1, 4, 3, 2];
        Debug.Assert(sol.LargestAltitude(gain) == 0);

        Console.WriteLine("passed");
    }
}
