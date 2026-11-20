using System.Diagnostics;
using System.Text;

public class Solution {
    public string[] CreateGrid(int m, int n) {
        string[] grid = new string[m];
        for (int i = 0; i < m; i++) {
            StringBuilder sb = new(n);
            for (int j = 0; j < n; j++) {
                char c = (i == 0 || j == n - 1) ? '.' : '#';
                sb.Append(c);
            }
            grid[i] = sb.ToString();
        }
        return grid;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int m = 2;
        int n = 3;
        Debug.Assert(HasExactlyOnePath(sol.CreateGrid(m, n), m, n));

        m = 3;
        n = 3;
        Debug.Assert(HasExactlyOnePath(sol.CreateGrid(m, n), m, n));

        m = 1;
        n = 4;
        Debug.Assert(HasExactlyOnePath(sol.CreateGrid(m, n), m, n));

        Console.WriteLine("passed");
    }

    static bool HasExactlyOnePath(string[] grid, int m, int n) {
        if (grid.Length != m) {
            return false;
        }
        int[] paths = new int[n];
        paths[0] = 1;
        foreach (string row in grid) {
            if (row.Length != n) {
                return false;
            }
            for (int j = 0; j < n; j++) {
                if (row[j] == '#') {
                    paths[j] = 0;
                } else if (row[j] == '.') {
                    if (j > 0) {
                        paths[j] = Math.Min(2, paths[j] + paths[j - 1]);
                    }
                } else {
                    return false;
                }
            }
        }
        return paths[n - 1] == 1;
    }
}
