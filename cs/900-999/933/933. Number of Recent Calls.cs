using System.Diagnostics;

public class RecentCounter
{
    private readonly Queue<int> q = [];
    public RecentCounter()
    {
        q.Clear();
    }

    public int Ping(int t)
    {
        q.Enqueue(t);
        while (q.Peek() < t - 3000)
        {
            q.Dequeue();
        }
        return q.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        RecentCounter obj = new();

        Debug.Assert(obj.Ping(1) == 1);
        Debug.Assert(obj.Ping(100) == 2);
        Debug.Assert(obj.Ping(3001) == 3);
        Debug.Assert(obj.Ping(3002) == 3);

        Console.WriteLine("passed");
    }
}
