using System.Diagnostics;

public class Solution {
    public int ScoreOfParentheses(string s) {
        int multiplier = 1;
        int score = 0;
        for (int i = 0; i < s.Length; i++) {
            multiplier = s[i] == '(' ? multiplier * 2 : multiplier / 2;
            if (s[i] == ')' && s[i - 1] == '(') {
                score += multiplier;
            }
        }
        return score;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "()";
        Debug.Assert(sol.ScoreOfParentheses(s) == 1);

        s = "(())";
        Debug.Assert(sol.ScoreOfParentheses(s) == 2);

        s = "()()";
        Debug.Assert(sol.ScoreOfParentheses(s) == 2);

        Console.WriteLine("passed");
    }
}
