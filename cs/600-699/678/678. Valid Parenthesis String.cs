using System.Diagnostics;

public class Solution {
    public bool CheckValidString(string s) {
        int low = 0, high = 0;
        foreach (char c in s) {
            if (c == '(') {
                low++;
                high++;
            } else if (c == ')') {
                if (low > 0) low--;
                high--;
                if (high < 0) return false;
            } else if (c == '*') {
                if (low > 0) low--;
                high++;
            }
        }
        return low == 0;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "()";
        Debug.Assert(sol.CheckValidString(s) == true);

        s = "(*)";
        Debug.Assert(sol.CheckValidString(s) == true);

        s = "(*))";
        Debug.Assert(sol.CheckValidString(s) == true);

        Console.WriteLine("passed");
    }
}
