using System.Diagnostics;

public class FreqStack0 {
    static int pos = 0;
    Dictionary<int, Stack<int>> valueToPos = new();
    Dictionary<int, int> posToValue = new();

    Dictionary<int, int> valueToFreq = new();    
    Dictionary<int, SortedSet<int>> freqToPos = new();

    public FreqStack0() {
        valueToPos.Clear();
        posToValue.Clear();
        valueToFreq.Clear();
        freqToPos.Clear();
    }
    
    public void Push(int val) {
        // maintain position
        valueToPos.TryAdd(val, new Stack<int>());
        posToValue[pos] = val;

        // maintain frequency  
        valueToFreq.TryAdd(val, 0);
        int freq = valueToFreq[val];
        if (freq > 0)
        {
            freqToPos[freq].Remove(valueToPos[val].Peek());
            if (freqToPos[freq].Count == 0)
            {
                freqToPos.Remove(freq);
            }
        }
        valueToPos[val].Push(pos);

        valueToFreq[val]++;
        freq = valueToFreq[val];
        freqToPos.TryAdd(freq, new SortedSet<int>());
        freqToPos[freq].Add(valueToPos[val].Peek());

        pos++;
    }

    public int Pop() {
        int freq = freqToPos.Keys.Max();
        int pos = freqToPos[freq].Max;
        freqToPos[freq].Remove(pos);
        if (freqToPos[freq].Count == 0)
        {
            freqToPos.Remove(freq);
        }

        int val = posToValue[pos];
        valueToPos[val].Pop();
        valueToFreq[val]--;

        freq = valueToFreq[val];
        if (freq > 0)
        {
            freqToPos.TryAdd(freq, new SortedSet<int>());
            freqToPos[freq].Add(valueToPos[val].Peek());
        }

        return val;
    }
}

public class FreqStack {
    readonly Dictionary<int, int> valueToFreq = new();
    readonly Dictionary<int, Stack<int>> freqToValues = new();
    private int maxFreq = 0;
    public FreqStack() {
    }
    
    public void Push(int val) {
        valueToFreq.TryAdd(val, 0);
        valueToFreq[val]++;
        int freq = valueToFreq[val];
        if (freq > maxFreq)
        {
            maxFreq = freq;
        }

        freqToValues.TryAdd(freq, new Stack<int>());
        freqToValues[freq].Push(val);
    }
    
    public int Pop() {
        int val = freqToValues[maxFreq].Pop();
        valueToFreq[val]--;

        if (freqToValues[maxFreq].Count == 0)
        {
            freqToValues.Remove(maxFreq);
            maxFreq--;
        }
        return val;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(val);
 * int param_2 = obj.Pop();
 */

 class Program
{   
    static void Main()
    {
        Console.WriteLine("LeetCode 895 Maximum Frequency Stack, C# ...");

        FreqStack freqStack = new();

        freqStack.Push(5); // [5]
        freqStack.Push(7); // [5,7]
        freqStack.Push(5); // [5,7,5]
        freqStack.Push(7); // [5,7,5,7]
        freqStack.Push(4); // [5,7,5,7,4]
        freqStack.Push(5); // [5,7,5,7,4,5]

        Debug.Assert(freqStack.Pop() == 5);   // [5,7,5,7,4]
        Debug.Assert(freqStack.Pop() == 7);   // [5,7,5,4]
        Debug.Assert(freqStack.Pop() == 5);   // [5,7,4]
        Debug.Assert(freqStack.Pop() == 4);   // [5,7]

        // case2
        // [[],[5],[1],[2],[5],[5],[5],[1],[6],[1],[5],[],[],[],[],[],[],[],[],[],[]]
        freqStack = new();
        freqStack.Push(5);  // [5]
        freqStack.Push(1);  // [5,1]
        freqStack.Push(2);  // [5,1,2]
        freqStack.Push(5);  // [5,1,2,5]
        freqStack.Push(5);  // [5,1,2,5,5]
        freqStack.Push(5);  // [5,1,2,5,5,5]
        freqStack.Push(1);  // [5,1,2,5,5,5,1]
        freqStack.Push(6);  // [5,1,2,5,5,5,1,6]
        freqStack.Push(1);  // [5,1,2,5,5,5,1,6,1]
        freqStack.Push(5);  // [5,1,2,5,5,5,1,6,1,5]

        Debug.Assert(freqStack.Pop() == 5); // [5,1,2,5,5,5,1,6,1]
        Debug.Assert(freqStack.Pop() == 5); // [5,1,2,5,5,1,6,1]
        Debug.Assert(freqStack.Pop() == 1); // [5,1,2,5,5,1,6]
        Debug.Assert(freqStack.Pop() == 5); // [5,1,2,5,1,6]
        Debug.Assert(freqStack.Pop() == 1); // [5,1,2,5,6]
        Debug.Assert(freqStack.Pop() == 5); // [5,1,2,6]
        Debug.Assert(freqStack.Pop() == 6); // [5,1,2]
        Debug.Assert(freqStack.Pop() == 2); // [5,1]
        Debug.Assert(freqStack.Pop() == 1); // [5]
        Debug.Assert(freqStack.Pop() == 5); // []
    }
}