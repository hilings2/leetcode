using System.Diagnostics;

public class Solution
{
    private HashSet<int>[] graph = []; // adjacency list
    private int[] countNodes = []; // count of nodes in subtree rooted at node
    private int[] result = []; // sum of distances in subtree rooted at node

    public int[] SumOfDistancesInTree(int n, int[][] edges)
    {
        graph = new HashSet<int>[n];
        for (int i = 0; i < n; i++) {
            graph[i] = new HashSet<int>();
        }
        foreach (int[] edge in edges) {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }
        countNodes = new int[n];
        result = new int[n];

        // calculate countNodes and result for the root node (0)
        dfs(0, -1);
        // result[0] now contains the sum of distances from node 0 to all other nodes
        dfs2(0, -1);

        return result;
    }

    private void dfs(int root, int parent)
    {
        countNodes[root] = 1;
        foreach (int neighbor in graph[root])
        {
            if (neighbor == parent)
            {
                continue;
            }
            dfs(neighbor, root);
            countNodes[root] += countNodes[neighbor];
            // each node in subtree add 1 to the distance from root
            result[root] += result[neighbor] + countNodes[neighbor];
        }
    }

    private void dfs2(int root, int parent)
    {
        foreach (int neighbor in graph[root])
        {
            if (neighbor == parent)
            {
                continue;
            }
            // each node in subtree "neighbor" is 1 closer to root
            // and each node not in subtree is 1 farther from root
            result[neighbor] = result[root] - countNodes[neighbor] + (countNodes.Length - countNodes[neighbor]);
            dfs2(neighbor, root);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();
        
        int n;
        int[][] edges;
        int[] actual;
        int[] expected;

        n = 6;
        edges = [
            [0, 1],
            [0, 2],
            [2, 3],
            [2, 4],
            [2, 5]
        ];
        actual = sol.SumOfDistancesInTree(n, edges);
        expected = [8, 12, 6, 10, 10, 10];
        Debug.Assert(actual.SequenceEqual(expected));

        n = 1;
        edges = [];
        actual = sol.SumOfDistancesInTree(n, edges);
        expected = [0];
        Debug.Assert(actual.SequenceEqual(expected));

        n = 2;
        edges = [[1, 0]];
        actual = sol.SumOfDistancesInTree(n, edges);
        expected = [1, 1];
        Debug.Assert(actual.SequenceEqual(expected));

        n = 4;
        edges = [
            [2, 0],
            [3, 1],
            [2, 1]
        ];
        actual = sol.SumOfDistancesInTree(n, edges);
        expected = [6, 4, 4, 6];
        Debug.Assert(actual.SequenceEqual(expected));

        n = 6;
        edges = [
            [5,2],
            [5,3],
            [4,1],
            [3,0],
            [1,5]
        ];
        actual = sol.SumOfDistancesInTree(n, edges);
        expected = [13, 9, 11, 9, 13, 7];
        Debug.Assert(actual.SequenceEqual(expected));
    }
}