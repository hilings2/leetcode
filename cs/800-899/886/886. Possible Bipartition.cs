using System.Diagnostics;

public class Solution
{
    public bool PossibleBipartition(int n, int[][] dislikes)
    {
        HashSet<int>[] bipartitions = [new HashSet<int>(), new HashSet<int>()];
        Dictionary<int, List<int>> dislikesPerPerspon = new();
        foreach (int[] dislike in dislikes)
        {
            if (!dislikesPerPerspon.ContainsKey(dislike[0]))
            {
                dislikesPerPerspon.Add(dislike[0], new List<int>());
            }
            dislikesPerPerspon[dislike[0]].Add(dislike[1]);
            if (!dislikesPerPerspon.ContainsKey(dislike[1]))
            {
                dislikesPerPerspon.Add(dislike[1], new List<int>());
            }
            dislikesPerPerspon[dislike[1]].Add(dislike[0]);
        }

        foreach (KeyValuePair<int, List<int>> kvp in dislikesPerPerspon)
        {
            int person = kvp.Key;
            Console.WriteLine($"person: {person}");
            if (bipartitions[0].Contains(person) || bipartitions[1].Contains(person))
            {
                Console.WriteLine("\talready checked");
                continue;
            }

            int partition = 0;
            bipartitions[partition].Add(person);
            Console.WriteLine($"\tadding {person} to partition {partition}");
            Queue<int> queue = new(kvp.Value);
            Console.WriteLine($"\tadding [{string.Join(" ", kvp.Value)}] to queue");

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)  // these people to be added to the other partition
                {
                    int dislike = queue.Dequeue();
                    Console.WriteLine($"checking {dislike}");
                    if (bipartitions[partition].Contains(dislike))  // already disliked by someone in the other partition
                    {
                        Console.WriteLine($"\talready disliked by someone in the other partition");
                        return false;
                    }
                    if (bipartitions[1 - partition].Contains(dislike))  // already in the other partition
                    {
                        Console.WriteLine($"\talready in the other partition");
                        continue;
                    }
                    bipartitions[1 - partition].Add(dislike);
                    Console.WriteLine($"\tadding {dislike} to partition {1 - partition}");
                    foreach (int nextDislike in dislikesPerPerspon[dislike])
                    {
                        if (bipartitions[0].Contains(nextDislike) || bipartitions[1].Contains(nextDislike))
                        {
                            continue;
                        }
                        queue.Enqueue(nextDislike);
                        Console.WriteLine($"\tadding [{nextDislike}] to queue, to be added to partition {partition}");
                    }
                }
                partition = 1 - partition;
            }
        }
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();
        int n = 4;
        int[][] dislikes =
        [
            [1, 2],
            [1, 3],
            [2, 4]
        ];
        Debug.Assert(sol.PossibleBipartition(n, dislikes) == true);

        n = 3;
        dislikes =
        [
            [1, 2],
            [1, 3],
            [2, 3]
        ];
        Debug.Assert(sol.PossibleBipartition(n, dislikes) == false);

        n = 5;
        dislikes =
        [
            [1, 2],
            [2, 3],
            [3, 4],
            [4, 5],
            [5, 1]
        ];
        Debug.Assert(sol.PossibleBipartition(n, dislikes) == false);
    }
}
