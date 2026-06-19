using System.Diagnostics;

public class Solution {
    public string MapWordWeights(string[] words, int[] weights) {
        string res = "";
        foreach (string word in words) {
            int sum = 0;
            foreach (char c in word) {
                sum += weights[c - 'a'];
            }
            res += (char)('a' + (25 - sum % 26));
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] words = ["abcd", "def", "xyz"];
        int[] weights = [5, 3, 12, 14, 1, 2, 3, 2, 10, 6, 6, 9, 7, 8, 7, 10, 8, 9, 6, 9, 9, 8, 3, 7, 7, 2];
        Debug.Assert(sol.WeightedString(words, weights) == "rij");

        words = ["a", "b", "c"];
        weights = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1];
        Debug.Assert(sol.WeightedString(words, weights) == "yyy");

        words = ["abcd"];
        weights = [7, 5, 3, 4, 3, 5, 4, 9, 4, 2, 2, 7, 10, 2, 5, 10, 6, 1, 2, 2, 4, 1, 3, 4, 4, 5];
        Debug.Assert(sol.WeightedString(words, weights) == "g");

        Console.WriteLine("passed");
    }
}
