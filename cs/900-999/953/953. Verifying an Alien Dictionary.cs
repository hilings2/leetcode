using System.Diagnostics;

public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        int[] orderMap = new int[26];
        for (int i = 0; i < order.Length; i++) {
            orderMap[order[i] - 'a'] = i;
        }
        string[] words2 = new string[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            char[] chars = words[i].ToCharArray();
            for (int j = 0; j < chars.Length; j++)
            {
                chars[j] = (char)(orderMap[chars[j] - 'a'] + 'a');
            }
            words2[i] = new string(chars);
        }
        for (int i = 1; i < words2.Length; i++)
        {
            if (string.Compare(words2[i - 1], words2[i]) > 0) {
                return false;
            }
        }
        return true;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] words = ["hello", "leetcode"];
        string order = "hlabcdefgijkmnopqrstuvwxyz";
        Debug.Assert(sol.IsAlienSorted(words, order) == true);

        words = ["word", "world", "row"];
        order = "worldabcefghijkmnpqstuvxyz";
        Debug.Assert(sol.IsAlienSorted(words, order) == false);

        words = ["apple", "app"];
        order = "abcdefghijklmnopqrstuvwxyz";
        Debug.Assert(sol.IsAlienSorted(words, order) == false);

        Console.WriteLine("passed");
    }
}
