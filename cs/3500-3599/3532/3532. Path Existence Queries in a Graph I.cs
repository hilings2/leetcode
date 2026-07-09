using System.Diagnostics;

public class Solution {
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        int[] nodeToGroupIds = new int[n];
        for (int i = 1; i < n; i++)
        {
            nodeToGroupIds[i] = nodeToGroupIds[i - 1] + (nums[i] - nums[i - 1] > maxDiff ? 1 : 0);
        }
        bool[] res = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int u = queries[i][0], v = queries[i][1];
            res[i] = nodeToGroupIds[u] == nodeToGroupIds[v];
        }
        return res;
    }

    public bool[] PathExistenceQueries0(int n, int[] nums, int maxDiff, int[][] queries) {
        Dictionary<int, List<int>> graph = [];  // adjacency list representation of the graph
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (Math.Abs(nums[i] - nums[j]) > maxDiff)  continue;
                graph.TryAdd(i, []);
                graph[i].Add(j);
                graph.TryAdd(j, []);
                graph[j].Add(i);
            }
        }

        // BFS to find connected components
        int[] nodeToGroupIds = new int[n];
        int groupId = 0;
        for (int i = 0; i < n; i++)
        {
            if (nodeToGroupIds[i] != 0) continue;
            groupId++;
            Queue<int> queue = new([i]);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                nodeToGroupIds[node] = groupId;
                if (!graph.ContainsKey(node))    continue;
                foreach (int neighbor in graph[node])
                {
                    if (nodeToGroupIds[neighbor] != 0)  continue;
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Answer the queries
        bool[] res = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int u = queries[i][0], v = queries[i][1];
            res[i] = nodeToGroupIds[u] == nodeToGroupIds[v];
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 3];
        int[][] queries = [[0, 0], [0, 1]];
        Debug.Assert(sol.PathExistenceQueries(2, nums, 1, queries).SequenceEqual([true, false]));

        nums = [2, 5, 6, 8];
        queries = [[0, 1], [0, 2], [1, 3], [2, 3]];
        Debug.Assert(sol.PathExistenceQueries(4, nums, 2, queries).SequenceEqual([false, false, true, true]));

        Console.WriteLine("passed");
    }
}
