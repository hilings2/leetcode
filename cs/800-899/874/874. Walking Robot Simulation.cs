using System.Diagnostics;

public class Solution
{
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        int[][] directions = [
            [0, 1],   // North
            [1, 0],   // East
            [0, -1],  // South
            [-1, 0]   // West
        ];
        HashSet<string> hsObstacles = new();
        foreach (int[] obstacle in obstacles)
        {
            hsObstacles.Add(string.Join(",", obstacle));
        }
        int direction = 0;
        int[] pos = [0, 0];
        int r = 0;

        for (int i = 0; i < commands.Length; i++)
        {
            if (commands[i] == -1)
            {
                direction = (direction + 1) % 4;
            }
            else if (commands[i] == -2)
            {
                direction = (direction + 3) % 4;
            }
            else
            {
                pos = EndPos(pos, directions[direction], commands[i], hsObstacles);
                r = System.Math.Max(r, pos[0] * pos[0] + pos[1] * pos[1]);
            }
        }

        return r;
    }

    public int[] EndPos(int[] pos, int[] direction, int steps, HashSet<string> hsObstacles)
    {
        for (int i = 0; i < steps; i++)
        {
            int[] nextPos = [pos[0] + direction[0], pos[1] + direction[1]];

            if (hsObstacles.Contains(string.Join(",", nextPos)))
            {
                break;
            }
            pos = nextPos;
        }
        return pos;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] commands = [4, -1, 3];
        int[][] obstacles = [];
        Debug.Assert(sol.RobotSim(commands, obstacles) == 25);

        commands = [4, -1, 4, -2, 4];
        obstacles = [[2, 4], [3, 5]];
        Debug.Assert(sol.RobotSim(commands, obstacles) == 65);

        commands = [6, -1, -1, 6];
        obstacles = [];
        Debug.Assert(sol.RobotSim(commands, obstacles) == 36);
    }
}
