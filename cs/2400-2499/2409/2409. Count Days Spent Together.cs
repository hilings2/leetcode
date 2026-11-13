using System.Diagnostics;

public class Solution {
    private static readonly int[] DaysInMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob) {
        int aliceStart = GetDayOfYear(arriveAlice);
        int aliceEnd = GetDayOfYear(leaveAlice);
        int bobStart = GetDayOfYear(arriveBob);
        int bobEnd = GetDayOfYear(leaveBob);

        if (bobStart > aliceEnd || aliceStart > bobEnd) {
            return 0;
        }

        return Math.Min(aliceEnd, bobEnd) - Math.Max(aliceStart, bobStart) + 1;
    }

    private static (int month, int day) ParseDate(string date) {
        int month = int.Parse(date.AsSpan(0, 2));
        int day = int.Parse(date.AsSpan(3, 2));
        return (month, day);
    }

    private static int GetDayOfYear(string date) {
        (int month, int day) = ParseDate(date);
        int dayOfYear = day;
        for (int i = 0; i < month - 1; i++) {
            dayOfYear += DaysInMonth[i];
        }
        return dayOfYear;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string arriveAlice = "08-15";
        string leaveAlice = "08-18";
        string arriveBob = "08-16";
        string leaveBob = "08-19";
        Debug.Assert(sol.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob) == 3);
        Debug.Assert(sol.CountDaysTogether(arriveBob, leaveBob, arriveAlice, leaveAlice) == 3);

        arriveAlice = "10-01";
        leaveAlice = "10-31";
        arriveBob = "11-01";
        leaveBob = "12-31";
        Debug.Assert(sol.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob) == 0);

        arriveAlice = "11-01";
        leaveAlice = "12-31";
        arriveBob = "10-01";
        leaveBob = "10-31";
        Debug.Assert(sol.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob) == 0);

        arriveAlice = "08-15";
        leaveAlice = "08-18";
        arriveBob = "08-18";
        leaveBob = "08-19";
        Debug.Assert(sol.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob) == 1);

        arriveAlice = "08-01";
        leaveAlice = "08-31";
        arriveBob = "08-15";
        leaveBob = "08-18";
        Debug.Assert(sol.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob) == 4);

        arriveAlice = "02-27";
        leaveAlice = "03-02";
        arriveBob = "02-28";
        leaveBob = "03-01";
        Debug.Assert(sol.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob) == 2);

        arriveAlice = "01-01";
        leaveAlice = "12-31";
        arriveBob = "01-01";
        leaveBob = "12-31";
        Debug.Assert(sol.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob) == 365);

        Console.WriteLine("passed");
    }
}
