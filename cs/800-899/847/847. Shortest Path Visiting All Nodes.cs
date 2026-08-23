using System.Diagnostics;

public class Solution {
    public int ShortestPathLength(int[][] graph) {
        Queue<(int node, int mask)> queue = new(); // (node, visited nodes mask)
        HashSet<(int node, int mask)> visited = [];
        for (int i = 0; i < graph.Length; i++) {
            int mask = 1 << i;  // track visited nodes using bitmask
            visited.Add((i, mask));
            queue.Enqueue((i, mask));
        }
        int res = 0;
        int targetMask = (1 << graph.Length) - 1;
        while (queue.Count > 0) { // BFS
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                (int node, int mask) = queue.Dequeue();
                if (mask == targetMask) return res;  // All nodes visited
                foreach (int neighbor in graph[node]) {
                    int newMask = mask | (1 << neighbor);
                    if (visited.Add((neighbor, newMask))) {
                        queue.Enqueue((neighbor, newMask));
                    }
                }
            }
            res++;
        }
        return -1;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[][] graph = [[1, 2, 3], [0], [0], [0]];
        Debug.Assert(sol.ShortestPathLength(graph) == 4);

        graph = [[1], [0, 2, 4], [1, 3, 4], [2], [1, 2]];
        Debug.Assert(sol.ShortestPathLength(graph) == 4);

        Console.WriteLine("passed");
    }
}