using System.Diagnostics;

public class Solution {
    public int CountCommas(int n) {
        return n >= 1000 ? n - 999 : 0;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 1002;
        Debug.Assert(sol.CountCommas(n) == 3);

        n = 998;
        Debug.Assert(sol.CountCommas(n) == 0);

        Console.WriteLine("passed");
    }
}