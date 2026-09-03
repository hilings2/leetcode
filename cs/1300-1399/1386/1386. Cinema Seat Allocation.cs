using System.Diagnostics;

public class Solution {
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) {
        Dictionary<int, HashSet<int>> reservedSeatsMap = [];
        foreach (int[] seat in reservedSeats) {
            (int row, int col) = (seat[0], seat[1]);
            if (!reservedSeatsMap.ContainsKey(row)) {
                reservedSeatsMap[row] = [];
            }
            reservedSeatsMap[row].Add(col);
        }
        int res = (n - reservedSeatsMap.Count) * 2; // start with numbers of rows without reserved seats
        foreach (HashSet<int> reservedCols in reservedSeatsMap.Values) {
            bool left = !reservedCols.Overlaps(new HashSet<int> { 2, 3, 4, 5 });
            bool middle = !reservedCols.Overlaps(new HashSet<int> { 4, 5, 6, 7 });
            bool right = !reservedCols.Overlaps(new HashSet<int> { 6, 7, 8, 9 });
            if (left && right) {
                res += 2;
            } else if (left || middle || right) {
                res += 1;
            }            
        }
        return res;
    }

    public int MaxNumberOfFamilies2(int n, int[][] reservedSeats) {
        const int LeftSeats = 0b00_0011_1100;
        const int MiddleSeats = 0b00_1111_0000;
        const int RightSeats = 0b11_1100_0000;
        Dictionary<int, int> reservedMasks = [];
        foreach (int[] seat in reservedSeats) {
            (int row, int col) = (seat[0], seat[1]);
            if (col == 1 || col == 10) {
                continue;
            }
            reservedMasks[row] = reservedMasks.GetValueOrDefault(row) | (1 << col);
        }
        int res = (n - reservedMasks.Count) * 2;
        foreach (int reservedMask in reservedMasks.Values) {
            bool left = (reservedMask & LeftSeats) == 0;
            bool middle = (reservedMask & MiddleSeats) == 0;
            bool right = (reservedMask & RightSeats) == 0;
            if (left && right) {
                res += 2;
            } else if (left || middle || right) {
                res += 1;
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 3;
        int[][] reservedSeats = [[1, 2], [1, 3], [1, 8], [2, 6], [3, 1], [3, 10]];
        Debug.Assert(sol.MaxNumberOfFamilies(n, reservedSeats) == 4);
        Debug.Assert(sol.MaxNumberOfFamilies2(n, reservedSeats) == 4);

        n = 2;
        reservedSeats = [[2, 1], [1, 8], [2, 6]];
        Debug.Assert(sol.MaxNumberOfFamilies(n, reservedSeats) == 2);
        Debug.Assert(sol.MaxNumberOfFamilies2(n, reservedSeats) == 2);

        n = 4;
        reservedSeats = [[4, 3], [1, 4], [4, 6], [1, 7]];
        Debug.Assert(sol.MaxNumberOfFamilies(n, reservedSeats) == 4);
        Debug.Assert(sol.MaxNumberOfFamilies2(n, reservedSeats) == 4);

        Console.WriteLine("passed");
    }
}