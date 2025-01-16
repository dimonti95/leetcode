public class MyQueue
{
    private Stack<int> _stackOne;
    private Stack<int> _stackTwo;

    public MyQueue()
    {
        _stackOne = new Stack<int>();
        _stackTwo = new Stack<int>();
    }
    
    public void Push(int x)
    {
        while (_stackOne.Count > 0)
        {
            _stackTwo.Push(_stackOne.Pop());
        }
        _stackTwo.Push(x);

        while (_stackTwo.Count > 0)
        {
            _stackOne.Push(_stackTwo.Pop());
        }
    }
    
    public int Pop()
    {
        return _stackOne.Pop();
    }
    
    public int Peek()
    {
        return _stackOne.Peek();
    }
    
    public bool Empty()
    {
        return _stackOne.Count == 0 && _stackTwo.Count == 0;
    }
}

/*

    Solution 1
    * Use one stack to hold the elements
    * Use another stack to re-order the elements

    Push
    Time: O(n)
    Space: O(n)

    Pop
    Time: O(1)
    Space: O(1)

    Peek
    Time: O(1)
    Space: O(1)

    Empty
    Time: O(1)
    Space: O(1)

*/



public class MyQueue2
{
    private Stack<int> _stackOne;
    private Stack<int> _stackTwo;
    private int _front;

    public MyQueue()
    {
        _stackOne = new Stack<int>();
        _stackTwo = new Stack<int>();
    }
    
    public void Push(int x)
    {
        if (_stackOne.Count == 0)
            _front = x;
            
        _stackOne.Push(x);
    }
    
    public int Pop()
    {
        if (_stackTwo.Count == 0)
        {
            while (_stackOne.Count > 0)
            {
                _stackTwo.Push(_stackOne.Pop());
            }
        }

        return _stackTwo.Pop();
    }
    
    public int Peek()
    {
        if (_stackTwo.Count > 0)
            return _stackTwo.Peek();

        return _front;
    }
    
    public bool Empty()
    {
        return _stackOne.Count == 0 && _stackTwo.Count == 0;
    }
}

/*

    Solution 2:
    * Push all nodes onto Stack One
    * Whenever pop is called, push all Stack One nodes onto Stack Two (in FIFO order)
    * If Stack Two contains elements, the first-in will always be at the top
    * If Stack Two is empty, the node at the bottom of Stack One is the first-in

    Push
    Time: O(1)
    Space: O(n)

    Pop
    Time: Worst case = O(n) amortized = O(1)
    Space: O(1)

    Peek
    Time: O(1)
    Space: O(1)

    Empty
    Time: O(1)
    Space: O(1)

    Amortized analysis evaluates the average performance of each operation over time, even in the worst-case scenario.
    The idea is that a single worst-case operation often changes the system's state, preventing similar worst cases from happening frequently,
    thereby spreading out its cost.

*/
