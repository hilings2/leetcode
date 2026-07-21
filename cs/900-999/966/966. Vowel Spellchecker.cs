using System.Diagnostics;

public class Solution {
    public string[] Spellchecker(string[] wordlist, string[] queries) {
        Dictionary<string, int> d1 = [], d2 = [], d3 = [];
        for (int i = 0; i < wordlist.Length; i++)
        {
            d1[wordlist[i]] = i;
            string lower = wordlist[i].ToLower();
            if (!d2.ContainsKey(lower)) d2[lower] = i;
            string vowel = Devowel(lower);
            if (!d3.ContainsKey(vowel)) d3[vowel] = i;
        }
        string[] res = new string[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            string lower = queries[i].ToLower();
            string vowel = Devowel(lower);
            if (d1.ContainsKey(queries[i]))
            {
                res[i] = wordlist[d1[queries[i]]];
            }
            else if (d2.ContainsKey(lower))
            {
                res[i] = wordlist[d2[lower]];
            }
            else if (d3.ContainsKey(vowel))
            {
                res[i] = wordlist[d3[vowel]];
            }
            else
            {
                res[i] = "";
            }
        }
        return res;
    }

    private static string Devowel(string s) {
        char[] c = s.ToCharArray();
        for (int i = 0; i < c.Length; i++)
        {
            if ("aeiou".Contains(c[i]))
                c[i] = '*';
        }
        return new string(c);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] wordlist = ["KiTe", "kite", "hare", "Hare"];
        string[] queries = ["kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto"];
        Debug.Assert(sol.Spellchecker(wordlist, queries).SequenceEqual(["kite", "KiTe", "KiTe", "Hare", "hare", "", "", "KiTe", "", "KiTe"]));

        wordlist = ["yellow"];
        queries = ["YellOw"];
        Debug.Assert(sol.Spellchecker(wordlist, queries).SequenceEqual(["yellow"]));

        Console.WriteLine("passed");
    }
}
