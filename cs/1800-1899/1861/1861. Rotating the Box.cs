using System.Diagnostics;

public class Solution
{
    public char[][] RotateTheBox(char[][] box)
    {
        ShiftRight(box);
        char[][] res = Transpose(box);
        return res;
    }

    private static void ShiftRight(char[][] box)
    {
        for (int i = 0; i < box.Length; i++)
        {
            for (int j = box[i].Length - 1; j >= 0; j--)
            {
                if (box[i][j] == '.' || box[i][j] == '*')
                {
                    continue;
                }
                int k = j;
                for (; k + 1 < box[i].Length && box[i][k + 1] == '.'; k++) ;
                (box[i][j], box[i][k]) = (box[i][k], box[i][j]);
            }
        }
    }

    private static char[][] Transpose(char[][] box)
    {
        char[][] res = new char[box[0].Length][];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = new char[box.Length];
            for (int j = 0; j < res[i].Length; j++)
            {
                res[i][j] = box[box.Length - 1 - j][i];
            }
        }
        return res;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        char[][] box = [['#', '.', '#']];
        char[][] expected = [
            ['.'],
            ['#'],
            ['#']
        ];
        Debug.Assert(Equal(sol.RotateTheBox(box), expected));

        box = [
            ['#', '.', '*', '.'],
            ['#', '#', '*', '.']
        ];
        expected = [
            ['#', '.'],
            ['#', '#'],
            ['*', '*'],
            ['.', '.']          
        ];
        Debug.Assert(Equal(sol.RotateTheBox(box), expected));

        box = [
            ['#', '#', '*', '.', '*', '.'],
            ['#', '#', '#', '*', '.', '.'],
            ['#', '#', '#', '.', '#', '.']
        ];
        expected = [
            ['.', '#', '#'],
            ['.', '#', '#'],
            ['#', '#', '*'],
            ['#', '*', '.'],
            ['#', '.', '*'],
            ['#', '.', '.']
        ];
        Debug.Assert(Equal(sol.RotateTheBox(box), expected));

        Console.WriteLine("passed");
    }

    static bool Equal(char[][] a, char[][] b)
    {
        if (a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++)
        {
            if (!a[i].SequenceEqual(b[i])) return false;
        }
        return true;
    }
}
