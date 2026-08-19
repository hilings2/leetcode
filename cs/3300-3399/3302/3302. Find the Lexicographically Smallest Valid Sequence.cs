using System.Diagnostics;

public class Solution {
    public int[] ValidSequence(string word1, string word2) {
        int n1 = word1.Length, n2 = word2.Length;
        int[] suffixMatch = new int[n1 + 1];
        for (int i = n1 - 1, j = n2 - 1; i >= 0; i--) { // suffixMatch[i] = number of char in word2 that can be matched in word1[i..]
            suffixMatch[i] = suffixMatch[i + 1];
            if (j >= 0 && word1[i] == word2[j]) {
                suffixMatch[i]++;
                j--;
            }
        }
        List<int> result = [];
        bool mismatchUsed = false;
        for (int i = 0, j = 0; i < n1 && j < n2; i++) {
            if (n1 - i < n2 - j) break; // not enough char left in word1 to match word2
            if (word1[i] == word2[j]) {
                result.Add(i);
                j++;
            } else if (!mismatchUsed && suffixMatch[i + 1] >= n2 - 1 - j) { // mismatch can be used here
                result.Add(i);
                j++;
                mismatchUsed = true;
            }
        }
        return result.Count == n2 ? result.ToArray() : [];
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string word1 = "vbcca";
        string word2 = "abc";
        Debug.Assert(sol.ValidSequence(word1, word2).SequenceEqual([0, 1, 2]));

        word1 = "bacdc";
        word2 = "abc";
        Debug.Assert(sol.ValidSequence(word1, word2).SequenceEqual([1, 2, 4]));

        word1 = "aaaaaa";
        word2 = "aaabc";
        Debug.Assert(sol.ValidSequence(word1, word2).SequenceEqual([]));

        word1 = "abc";
        word2 = "ab";
        Debug.Assert(sol.ValidSequence(word1, word2).SequenceEqual([0, 1]));

        Console.WriteLine("passed");
    }
}