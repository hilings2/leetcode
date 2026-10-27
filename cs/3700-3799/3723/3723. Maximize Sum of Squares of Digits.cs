using System.Diagnostics;
using System.Text;

public class Solution {
    public string MaxSumOfSquares(int num, int sum) {
        if (sum > 9 * num || (sum == 0 && num > 1)) return "";
        StringBuilder sb = new(num);
        for (int i = 0; i < num; i++) {
            int digit = Math.Min(9, sum);
            sb.Append((char)(digit + '0'));
            sum -= digit;
        }
        return sb.ToString();
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int num = 2;
        int sum = 3;
        Debug.Assert(sol.MaxSumOfSquares(num, sum) == "30");

        num = 2;
        sum = 17;
        Debug.Assert(sol.MaxSumOfSquares(num, sum) == "98");

        num = 1;
        sum = 10;
        Debug.Assert(sol.MaxSumOfSquares(num, sum) == "");

        Console.WriteLine("passed");
    }
}
