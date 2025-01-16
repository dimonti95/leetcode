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
