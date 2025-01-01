public class MedianFinder
{

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
        // The count of the high heap will never be larger than low because of the check in AddNum,
        // so I only need to check if the count of low is smaller here, otherwise both heaps will always be the same size.
        if (low.Count > high.Count) return low.Peek();

        // Need to cast to a double here because of the way C# handles integer division (it discards any fractional part).
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

    Brute force solution (not implemented here):
    * Add all numbers to an array
    * Sort the array on calls to FindMedian

    AddNum
    Time: O(1) - in most cases (see explanation below)
    Space: O(n)

    FindMedian
    Time: O(nlogn)
    Space: O(n)

    Note: This solution would require a re-sizeable array/container (a List in C#). For the AddNum function,
    if Count is less than capacity it's an O(1) operation. If Count already equals Capacity, the capacity of the List
    is increased by automatically reallocating the internal array, and the existing elements are copied to the new array before
    the new element is added. This is an O(n) operation.

    Source: The complexities of List operations documented on MSDN.
    
    --------------------------------------------------------------------------------

    Insertion Sort solution (not implemented here):
    * Use an array to store the numbers
    * Insertion sort the new number on each call to AddNum
    * Find median from the middle of the array/list

    AddNum
    Time: O(n) - because in the worst case, all of the elements in the array need to be shifted
    Space: O(n)

    FindMedian
    Time: O(1)
    Space: O(n)

    --------------------------------------------------------------------------------

    Optimized solution:
    * Two heaps
        - One to keep the smaller half of values (Max-heap)
        - One to keep the larger half of values (Min-heap)
    * Keep both heaps the same size (or at least within 1)
    
    AddNum
    Time: O(logn)
    Space: O(n)

    FindMedian
    Time: O(1)
    Space: O(n)

    Note: A heap is only one way (there are other ways) to implement a Priority Queue.

*/
