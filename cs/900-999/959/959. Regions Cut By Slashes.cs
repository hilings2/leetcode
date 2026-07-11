using System.Diagnostics;

public class Solution {
    public int RegionsBySlashes(string[] grid) {
        int n = grid.Length, size = 3 * n;
        int[][] graph = new int[size][];
        for (int i = 0; i < size; i++) {
            graph[i] = new int[size];
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '/') {
                    graph[i*3][j*3+2] = 1;
                    graph[i*3+1][j*3+1] = 1;
                    graph[i*3+2][j*3] = 1;
                } else if (grid[i][j] == '\\') {
                    graph[i*3][j*3] = 1;
                    graph[i*3+1][j*3+1] = 1;
                    graph[i*3+2][j*3+2] = 1;
                }
            }
        }
        bool[][] visited = new bool[size][];
        for (int i = 0; i < size; i++) {
            visited[i] = new bool[size];
        }

        int count = 0;
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                if (visited[i][j] || graph[i][j] == 1)  continue;
                count++;
                visited[i][j] = true;
                Queue<(int, int)> q = new();
                q.Enqueue((i, j));
                while (q.Count > 0) {
                    (int x, int y) = q.Dequeue();
                    foreach ((int dx, int dy) in new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) }) {
                        int nx = x + dx, ny = y + dy;
                        if (nx < 0 || nx >= size || ny < 0 || ny >= size || visited[nx][ny] || graph[nx][ny] == 1) {
                            continue;
                        }
                        visited[nx][ny] = true;
                        q.Enqueue((nx, ny));
                    }                    
                }
            }
        }
        return count;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] grid = [" /", "/ "];
        Debug.Assert(sol.RegionsBySlashes(grid) == 2);

        grid = [" /", "  "];
        Debug.Assert(sol.RegionsBySlashes(grid) == 1);

        grid = ["/\\", "\\/"];
        Debug.Assert(sol.RegionsBySlashes(grid) == 5);

        Console.WriteLine("passed");
    }
}
