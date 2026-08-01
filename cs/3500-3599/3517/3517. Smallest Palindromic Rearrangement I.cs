using System.Diagnostics;

public class Solution {
    public string SmallestPalindrome(string s) {
        int[] counts = new int[26];
        for (int i = 0; i < s.Length / 2; i++) {
            counts[s[i] - 'a']++;
        }
        char[] chars = s.ToCharArray();
        for (int c = 0, i = 0, j = s.Length - 1; c < 26; c++) {
            for (int k = 0; k < counts[c]; k++) {
                chars[i++] = (char)(c + 'a');
                chars[j--] = (char)(c + 'a');
            }            
        }
        return new string(chars);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "z";
        Debug.Assert(sol.SmallestPalindrome(s) == "z");

        s = "babab";
        Debug.Assert(sol.SmallestPalindrome(s) == "abbba");

        s = "daccad";
        Debug.Assert(sol.SmallestPalindrome(s) == "acddca");

        Console.WriteLine("passed");
    }
}
