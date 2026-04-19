using System.Diagnostics;

public class TopVotedCandidate {
    int leader = -1;
    Dictionary<int, int> votes = new(); // candidate -> votes
    List<int> leaders = new();  // leaders[i] is the leader at time times[i]
    int[] _times;

    public TopVotedCandidate(int[] persons, int[] times) {
        _times = times;
        for (int i = 0; i < persons.Length; i++)
        {
            int candidate = persons[i];
            votes[candidate] = votes.GetValueOrDefault(candidate, 0) + 1;
            if (leader == -1 || votes[candidate] >= votes[leader])
            {
                leader = candidate;
            }
            leaders.Add(leader);            
        }        
    }

    public int Q(int t) {
        int index = Array.BinarySearch(_times, t);
        if (index < 0) index = ~index - 1; // last element <= t
        return leaders[index];
    }
}

class Program {
    static void Main(string[] args) {
        int[] persons = [0, 1, 1, 0, 0, 1, 0];
        int[] times = [0, 5, 10, 15, 20, 25, 30];
        TopVotedCandidate topVotedCandidate = new(persons, times);
        Debug.Assert(topVotedCandidate.Q(3) == 0);
        Debug.Assert(topVotedCandidate.Q(12) == 1);
        Debug.Assert(topVotedCandidate.Q(25) == 1);
        Debug.Assert(topVotedCandidate.Q(15) == 0);
        Debug.Assert(topVotedCandidate.Q(24) == 0);
        Debug.Assert(topVotedCandidate.Q(8) == 1);

        Console.WriteLine("passed");
    }
}
