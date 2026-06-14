using System.Diagnostics;

public class Solution {
    public int[] DeckRevealedIncreasing(int[] deck) {
        Array.Sort(deck);
        LinkedList<int> q = new();
        q.AddFirst(deck.Last());
        for (int i = deck.Length - 2; i >= 0; i--) {
            q.AddFirst(q.Last.Value);
            q.RemoveLast();
            q.AddFirst(deck[i]);
        }
        return q.ToArray();
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] deck = [17, 13, 11, 2, 3, 5, 7];
        Debug.Assert(sol.DeckRevealedIncreasing(deck).SequenceEqual([2, 13, 3, 11, 5, 17, 7]));

        deck = [1, 1000];
        Debug.Assert(sol.DeckRevealedIncreasing(deck).SequenceEqual([1, 1000]));

        Console.WriteLine("passed");
    }
}
