using System.Diagnostics;

public class Solution {
    public bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2) {
        int closetX = Math.Clamp(xCenter, x1, x2), closetY = Math.Clamp(yCenter, y1, y2);
        int dx = xCenter - closetX, dy = yCenter - closetY;
        return dx * dx + dy * dy <= radius * radius;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int radius = 1;
        int xCenter = 0;
        int yCenter = 0;
        int x1 = 1;
        int y1 = -1;
        int x2 = 3;
        int y2 = 1;
        Debug.Assert(sol.CheckOverlap(radius, xCenter, yCenter, x1, y1, x2, y2) == true);

        radius = 1;
        xCenter = 1;
        yCenter = 1;
        x1 = 1;
        y1 = -3;
        x2 = 2;
        y2 = -1;
        Debug.Assert(sol.CheckOverlap(radius, xCenter, yCenter, x1, y1, x2, y2) == false);

        radius = 1;
        xCenter = 0;
        yCenter = 0;
        x1 = -1;
        y1 = 0;
        x2 = 0;
        y2 = 1;
        Debug.Assert(sol.CheckOverlap(radius, xCenter, yCenter, x1, y1, x2, y2) == true);

        Console.WriteLine("passed");
    }
}