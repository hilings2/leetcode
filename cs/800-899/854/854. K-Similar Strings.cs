using System.Diagnostics;

public class Solution {
    public int KSimilarity(string s1, string s2) {
        Dictionary<string, int> memo = [];
        return Search(s1, s2, memo);
    }

    private static int FirstMismatch(string s1, string s2) {
        for (int i = 0; i < s1.Length; i++) {
            if (s1[i] != s2[i]) {
                return i;
            }
        }
        return -1;
    }

    private static int Search(string s1, string s2, Dictionary<string, int> memo) {
        if (memo.TryGetValue(s1, out int cached)) {
            return cached;
        }
        int i = FirstMismatch(s1, s2);
        if (i == -1) {
            return 0;
        }
        int res = int.MaxValue;
        for (int j = i + 1; j < s1.Length; j++) {
            if (s1[j] == s2[i] && s1[j] != s2[j]) {
                char[] s1Chars = s1.ToCharArray();
                (s1Chars[i], s1Chars[j]) = (s1Chars[j], s1Chars[i]);
                res = Math.Min(res, 1 + Search(new string(s1Chars), s2, memo));
                if (s1[i] == s2[j]) {
                    break;
                }
            }
        }
        memo[s1] = res;
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s1 = "ab";
        string s2 = "ba";
        Debug.Assert(sol.KSimilarity(s1, s2) == 1);

        s1 = "abc";
        s2 = "bca";
        Debug.Assert(sol.KSimilarity(s1, s2) == 2);

        Console.WriteLine("passed");
    }
}