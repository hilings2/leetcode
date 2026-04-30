using System.Diagnostics;

public class Solution {
    public bool IsLongPressedName(string name, string typed) {
        int i1 = 0, i2 = 0;
        for (int j1, j2; i1 < name.Length && i2 < typed.Length; i1 = j1, i2 = j2)
        {
            if (name[i1] != typed[i2])
            {
                return false;
            }
            for (j1 = i1; j1 < name.Length && name[j1] == name[i1]; j1++);
            for (j2 = i2; j2 < typed.Length && typed[j2] == typed[i2]; j2++);
            if (j2 - i2 < j1 - i1)
            {
                return false;
            }
        }
        return i1 == name.Length && i2 == typed.Length;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string name = "alex";
        string typed = "aaleex";
        Debug.Assert(sol.IsLongPressedName(name, typed) == true);

        name = "saeed";
        typed = "ssaaedd";
        Debug.Assert(sol.IsLongPressedName(name, typed) == false);

        Console.WriteLine("passed");
    }
}