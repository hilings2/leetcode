using System.Diagnostics;

public class Solution {
    public string LexPalindromicPermutation(string s, string target) {
        int n = s.Length;
        int[] count = new int[26];
        foreach (char c in s) {
            count[c - 'a']++;
        }

        int oddCount = 0;
        char midChar = '\0';
        for (int i = 0; i < 26; i++) {
            if (count[i] % 2 == 1) {
                oddCount++;
                midChar = (char)(i + 'a');
            }
        }
        if (oddCount != n % 2) {
            return "";
        }

        int halfLength = n / 2;
        int[] halfCount = new int[26];
        for (int i = 0; i < 26; i++) {
            halfCount[i] = count[i] / 2;
        }

        char[] half = new char[halfLength];
        int matched = 0;
        for (; matched < halfLength; matched++) { // match the prefix of target
            int letter = target[matched] - 'a';
            if (halfCount[letter] == 0) {
                break;
            }
            half[matched] = target[matched];
            halfCount[letter]--;
        }

        // matched the whole half, need to check if the palindrome is greater than target
        if (matched == halfLength) {
            string candidate = BuildPalindrome(half, midChar, n);
            if (string.CompareOrdinal(candidate, target) > 0) {
                return candidate;
            }
            matched--; // backtrack one position to find a greater letter
            if (matched < 0) { // n == 1, no possible greater palindrome
                return "";
            }
            halfCount[target[matched] - 'a']++;
        }

        // find the next greater letter for the matched position
        int greater = -1;
        while (matched >= 0) {
            for (int letter = target[matched] - 'a' + 1; letter < 26; letter++) {
                if (halfCount[letter] > 0) {
                    greater = letter;
                    break;
                }
            }
            if (greater != -1) { // found a greater letter
                break;
            }
            if (matched == 0) { // cannot find a greater letter for the first position
                return "";
            }
            matched--;
            halfCount[target[matched] - 'a']++;
        }

        // fill up the half
        half[matched++] = (char)(greater + 'a');
        halfCount[greater]--;
        for (int letter = 0; letter < 26; letter++) {
            while (halfCount[letter] > 0) {
                half[matched++] = (char)(letter + 'a');
                halfCount[letter]--;
            }
        }

        return BuildPalindrome(half, midChar, n);
    }

    private static string BuildPalindrome(char[] half, char midChar, int length) {
        char[] result = new char[length];
        for (int i = 0; i < half.Length; i++) {
            result[i] = half[i];
            result[length - 1 - i] = half[i];
        }
        if (length % 2 == 1) {
            result[half.Length] = midChar;
        }
        return new string(result);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "baba";
        string target = "abba";
        Debug.Assert(sol.LexPalindromicPermutation(s, target) == "baab");

        s = "baba";
        target = "bbaa";
        Debug.Assert(sol.LexPalindromicPermutation(s, target) == "");

        s = "abc";
        target = "abb";
        Debug.Assert(sol.LexPalindromicPermutation(s, target) == "");

        s = "aac";
        target = "abb";
        Debug.Assert(sol.LexPalindromicPermutation(s, target) == "aca");

        Console.WriteLine("passed");
    }
}