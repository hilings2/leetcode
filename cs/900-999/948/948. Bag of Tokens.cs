using System.Diagnostics;

public class Solution {
    public int BagOfTokensScore(int[] tokens, int power) {
        Array.Sort(tokens);
        int score = 0, maxScore = 0;
        for (int i = 0, j = tokens.Length - 1; i <= j; )
        {
            if (power >= tokens[i])
            {
                power -= tokens[i++];
                score++;
                maxScore = Math.Max(maxScore, score);
            }
            else if (score > 0)
            {
                power += tokens[j--];
                score--;
            }
            else
            {
                break;
            }
        }
        return maxScore;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] tokens = [100];
        Debug.Assert(sol.BagOfTokensScore(tokens, 50) == 0);

        tokens = [200, 100];
        Debug.Assert(sol.BagOfTokensScore(tokens, 150) == 1);

        tokens = [100, 200, 300, 400];
        Debug.Assert(sol.BagOfTokensScore(tokens, 200) == 2);

        Console.WriteLine("passed");
    }
}
