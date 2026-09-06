using System.Diagnostics;

public class Solution {
    public bool CheckDivisibility(int n) {
        int sum = 0, product = 1;
        for (int copy = n; copy > 0; copy /= 10) {
            int digit = copy % 10;
            sum += digit;
            product *= digit;
        }
        return n % (sum + product) == 0;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 99;
        Debug.Assert(sol.CheckDivisibility(n) == true);

        n = 23;
        Debug.Assert(sol.CheckDivisibility(n) == false);

        Console.WriteLine("passed");
    }
}