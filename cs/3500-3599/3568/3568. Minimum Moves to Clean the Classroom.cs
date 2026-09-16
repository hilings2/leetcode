using System.Diagnostics;

public class Solution {
    private static readonly (int row, int col)[] directions = [
        (-1, 0), (1, 0), (0, -1), (0, 1)
    ];

    public int MinMoves(string[] classroom, int energy) {
        int m = classroom.Length, n = classroom[0].Length;
        (int row, int col) start = (-1, -1);
        int[,] litterId = new int[m, n];
        int litterIndex = 0, fullMask = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                litterId[i, j] = -1;
                if (classroom[i][j] == 'S') {
                    start = (i, j);
                }
                else if (classroom[i][j] == 'L') {
                    fullMask |= 1 << litterIndex;
                    litterId[i, j] = litterIndex++;
                }

            }
        }
        if (fullMask == 0) return 0; // no litter to clean
        int totalStates = 1 << litterIndex;
        // dp[i, j, s] = max energy left when reach (i, j) with state s; 0 means unvisited, since 0-energy states are never enqueued
        int[,,] dp = new int[m, n, totalStates];
        Queue<(int row, int col, int mask, int energyLeft)> q = new(); // BFS
        q.Enqueue((start.row, start.col, 0, energy));
        dp[start.row, start.col, 0] = energy;
        for (int steps = 0; q.Count > 0; steps++) {
            for (int size = q.Count; size > 0; size--) {
                (int row, int col, int mask, int energyLeft) = q.Dequeue();
                foreach ((int dr, int dc) in directions) {
                    (int nr, int nc) = (row + dr, col + dc);
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n) continue;
                    char cell = classroom[nr][nc];
                    if (cell == 'X') continue;
                    int nmask = mask;
                    if (litterId[nr, nc] != -1) nmask |= 1 << litterId[nr, nc];
                    if (nmask == fullMask) return steps + 1;
                    int ne = energyLeft - 1; // never negative: 0-energy states are never enqueued
                    if (cell == 'R') ne = energy;
                    if (ne == 0 || ne <= dp[nr, nc, nmask]) continue;
                    dp[nr, nc, nmask] = ne;
                    q.Enqueue((nr, nc, nmask, ne));
                }
            }
        }
        return -1;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] classroom = ["S.", "XL"];
        int energy = 2;
        Debug.Assert(sol.MinMoves(classroom, energy) == 2);

        classroom = ["LS", "RL"];
        energy = 4;
        Debug.Assert(sol.MinMoves(classroom, energy) == 3);

        classroom = ["L.S", "RXL"];
        energy = 3;
        Debug.Assert(sol.MinMoves(classroom, energy) == -1);

        Console.WriteLine("passed");
    }
}
