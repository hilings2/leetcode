using System.Diagnostics;

public class Master {
    private readonly string secret;
    private readonly HashSet<string> words;
    private readonly int allowedGuesses;
    private int guesses;

    public Master(string secret, string[] words, int allowedGuesses) {
        this.secret = secret;
        this.words = [.. words];
        this.allowedGuesses = allowedGuesses;
    }

    public bool Guessed { get; private set; }

    public int Guess(string word) {
        guesses++;
        if (!words.Contains(word)) {
            return -1;
        }
        int matches = 0;
        for (int i = 0; i < word.Length; i++) {
            if (word[i] == secret[i]) {
                matches++;
            }
        }
        if (matches == secret.Length && guesses <= allowedGuesses) {
            Guessed = true;
        }
        return matches;
    }
}

public class Solution {
    public void FindSecretWord(string[] words, Master master) {
        List<string> candidates = [.. words];
        while (candidates.Count > 0) {
            string guessWord = GetBestGuess(candidates);
            int matches = master.Guess(guessWord);
            if (matches == guessWord.Length) {
                return;
            }
            candidates = candidates.Where(word => CountMatches(word, guessWord) == matches).ToList();
        }
    }

    private static string GetBestGuess(List<string> candidates) {
        int minMaxBucketSize = int.MaxValue;
        string bestGuess = candidates[0];
        foreach (string guessWord in candidates) {
            int[] buckets = new int[7];
            foreach (string candidate in candidates) {
                int matches = CountMatches(candidate, guessWord);
                buckets[matches]++;
            }
            int maxBucketSize = buckets[..guessWord.Length].Max();
            if (maxBucketSize < minMaxBucketSize) {
                minMaxBucketSize = maxBucketSize;
                bestGuess = guessWord;
            }
        }
        return bestGuess;
    }

    private static int CountMatches(string word1, string word2) {
        int matches = 0;
        for (int i = 0; i < word1.Length; i++) {
            if (word1[i] == word2[i]) {
                matches++;
            }
        }
        return matches;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string secret = "acckzz";
        string[] words = ["acckzz", "ccbazz", "eiowzz", "abcczz"];
        int allowedGuesses = 10;
        Master master = new(secret, words, allowedGuesses);
        sol.FindSecretWord(words, master);
        Debug.Assert(master.Guessed);

        secret = "hamada";
        words = ["hamada", "khaled"];
        allowedGuesses = 10;
        master = new(secret, words, allowedGuesses);
        sol.FindSecretWord(words, master);
        Debug.Assert(master.Guessed);

        Console.WriteLine("passed");
    }
}