public class MedianFinder {

    private PriorityQueue<int, int> low;
    private PriorityQueue<int, int> high;

    public MedianFinder()
    {
        // Max-heap
        low = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        // Min-heap
        high = new PriorityQueue<int, int>();
    }
    
    // low (Max-heap) = Smaller half of values
    // high (Min-heap) = Larger half of values
    // AddNum(1) => low=[1], high=[], 
    // AddNum(2) => low=[1], high=[2]
    // AddNum(10) => low=[2,1], high=[10]
    // AddNum(11) => low=[2,1], high=[10,11]
    // AddNum(13) => low=[10,2,1], high=[11,13]
    public void AddNum(int num)
    {
        low.Enqueue(num, num);
        high.Enqueue(low.Peek(), low.Dequeue());

        if (high.Count > low.Count)
        {
            low.Enqueue(high.Peek(), high.Dequeue());
        }
    }
    
    public double FindMedian()
    {
        if (low.Count > high.Count) return low.Peek();
        else return (double)(low.Peek() + high.Peek()) / 2;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */

/*

    Solution 2:
    * Two Queues
        - One to keep the smaller half of values (Max-heap)
        - One to keep the larger half of values (Min-heap)
    * Keep both heaps the same size (or at least within 1)
    
    AddNum
    Time: O(logn)
    Space: O(n)

    FindMedian
    Time: O(1)
    Space: O(n)

*/
