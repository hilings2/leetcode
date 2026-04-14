using System.Diagnostics;

public class Solution
{
    public bool HasGroupsSizeX(int[] deck)
    {
        Dictionary<int, int> count = [];
        foreach (int card in deck)
        {
            count[card] = count.GetValueOrDefault(card) + 1;
        }

        int g = count.Values.First();
        foreach (int c in count.Values.Skip(1))
        {
            g = Gcd(g, c);
        }
        return g >= 2;
    }

    public bool HasGroupsSizeX2(int[] deck)
    {
        return deck.GroupBy(x => x).Select(g => g.Count()).Aggregate(Gcd) >= 2;
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }
        return a;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] deck = [1, 2, 3, 4, 4, 3, 2, 1];
        Debug.Assert(sol.HasGroupsSizeX(deck) == true);
        Debug.Assert(sol.HasGroupsSizeX2(deck) == true);

        deck = [1, 1, 1, 2, 2, 2, 3, 3];
        Debug.Assert(sol.HasGroupsSizeX(deck) == false);
        Debug.Assert(sol.HasGroupsSizeX2(deck) == false);
    }
}