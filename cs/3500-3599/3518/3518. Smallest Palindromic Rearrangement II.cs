using System.Diagnostics;

public class Solution {
    public string SmallestPalindrome(string s, int k) {
        int n = s.Length, half = n / 2;
        int[] counts = new int[26];
        for (int i = 0; i < half; i++) {
            counts[s[i] - 'a']++;
        }
        char[] sortedHalf = new char[half]; // sorted version of s[0..half-1]
        for (int c = 0, i = 0; c < 26; c++) {
            for (int j = 0; j < counts[c]; j++) {
                sortedHalf[i++] = (char)(c + 'a');
            }
        }

        // k <= 1e6, so only a short suffix of the sorted half can change:
        // sortedHalf[0..start) is fixed, sortedHalf[start..half) gets rearranged.
        int[] suffix = new int[26]; // char counts for sortedHalf[start..half)
        int start = half;
        long perms = 1;
        while (start > 0 && perms < k) {
            start--;
            int c = sortedHalf[start] - 'a';
            suffix[c]++;
            perms = perms * (half - start) / suffix[c]; // dedup the new char sortedHalf[start]
        }
        if (perms < k) { // even all possible rearrangements of sortedHalf[0..half) are < k, so no answer
            return "";
        }

        char[] chars = new char[n]; // build the 0..half-1 part of the wanted palindrome
        for (int i = 0; i < start; i++) {
            chars[i] = sortedHalf[i];
        }
        for (int pos = start; pos < half; pos++) {
            for (int c = 0; c < 26; c++) {
                if (suffix[c] == 0) {
                    continue;
                }
                suffix[c]--; // assume putting char c at pos, then count how many permutations of the rest
                long permsRest = CountPerms(suffix, k);
                if (permsRest >= k) { // the wanted permutation is among those starting with char c at pos
                    chars[pos] = (char)(c + 'a'); // put char c at pos
                    break;
                }
                k -= (int)permsRest; // the wanted permutation is not among those starting with char c at pos, so skip them
                suffix[c]++; // revert assumption, try next char c
            }
        }
        if ((n & 1) == 1) {
            chars[half] = s[half];
        }
        for (int i = 0; i < half; i++) {
            chars[n - 1 - i] = chars[i];
        }
        return new string(chars);
    }

    // Distinct permutations of the multiset, capped at cap + 1 to avoid overflow.
    private static long CountPerms(int[] counts, long cap) {
        long perms = 1;
        int total = 0;
        for (int c = 0; c < 26; c++) {
            for (int i = 1; i <= counts[c]; i++) {
                total++;
                perms = perms * total / i; // dedup the i of the same char c
                if (perms > cap) {
                    return cap + 1; // the caller only cares whether the count reaches cap
                }
            }
        }
        return perms;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "abba";
        int k = 2;
        Debug.Assert(sol.SmallestPalindrome(s, k) == "baab");

        s = "aa";
        k = 2;
        Debug.Assert(sol.SmallestPalindrome(s, k) == "");

        s = "bacab";
        k = 1;
        Debug.Assert(sol.SmallestPalindrome(s, k) == "abcba");

        Console.WriteLine("passed");
    }
}
