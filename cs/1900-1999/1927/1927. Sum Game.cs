using System.Diagnostics;

public class Solution {
    public bool SumGame(string num) {
        int leftSum = 0, rightSum = 0;
        int leftQ = 0, rightQ = 0;
        int n = num.Length;
        for (int i = 0; i < n; i++) {
            if (i < n / 2) {
                if (num[i] == '?') {
                    leftQ++;
                } else {
                    leftSum += num[i] - '0';
                }
            } else {
                if (num[i] == '?') {
                    rightQ++;
                } else {
                    rightSum += num[i] - '0';
                }
            }
        }
        return (leftQ + rightQ) % 2 == 1 // odd ? Alice wins
            || 9 * (leftQ - rightQ) != 2 * (rightSum - leftSum); // num of ? cannot balance the diff
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string num = "5023";
        Debug.Assert(sol.SumGame(num) == false);

        num = "25??";
        Debug.Assert(sol.SumGame(num) == true);

        num = "?3295???";
        Debug.Assert(sol.SumGame(num) == false);

        Console.WriteLine("passed");
    }
}