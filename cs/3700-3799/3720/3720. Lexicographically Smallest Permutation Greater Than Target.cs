using System.Diagnostics;

public class Solution {
    public string LexGreaterPermutation(string s, string target) {
        int[] count = new int[26];
        foreach (char c in s) { // count letters in s
            count[c - 'a']++;
        }

        char[] result = new char[s.Length];
        int matched = 0;
        for (; matched < target.Length && count[target[matched] - 'a'] > 0; matched++) { // match as many letters as possible
            result[matched] = target[matched];
            count[target[matched] - 'a']--;
        }

        int greater = -1;
        if (matched < target.Length) { // find next greater letter with most prefix matched
            for (int letter = target[matched] - 'a' + 1; letter < 26; letter++) {
                if (count[letter] > 0 ) {
                    greater = letter;
                    break;
                }
            }
        }
        
        while (greater == -1 && matched > 0) { // backtrack prefix to find next greater letter
            matched--;
            int restored = target[matched] - 'a';
            count[restored]++;
            for (int letter = restored + 1; letter < 26; letter++) {
                if (count[letter] > 0) {
                    greater = letter;
                    break;
                }
            }
        }

        if (greater != -1) { // build result
            result[matched++] = (char)('a' + greater);
            count[greater]--;
            for (int letter = 0; letter < 26; letter++) {
                for (; count[letter] > 0; matched++) {
                    result[matched] = (char)('a' + letter);
                    count[letter]--;
                }
            }
            return new string(result);
        }
        return "";
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "abc";
        string target = "bba";
        Debug.Assert(sol.LexGreaterPermutation(s, target) == "bca");

        s = "leet";
        target = "code";
        Debug.Assert(sol.LexGreaterPermutation(s, target) == "eelt");

        s = "baba";
        target = "bbaa";
        Debug.Assert(sol.LexGreaterPermutation(s, target) == "");

        s = "abc";
        target = "bca";
        Debug.Assert(sol.LexGreaterPermutation(s, target) == "cab");

        Console.WriteLine("passed");
    }
}