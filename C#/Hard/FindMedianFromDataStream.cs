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

    --------------------------------------------------------------------------------
    --------------------------------------------------------------------------------
    ------------------------------Follow-up Questions-------------------------------
    --------------------------------------------------------------------------------
    --------------------------------------------------------------------------------

    - What if the data is very very large. How would you handle it?
    - If all integer numbers from the stream are in the range [0, 100], how would you optimize your solution?
    - If 99% of all integer numbers from the stream are in the range [0, 100], how would you optimize your solution?

    --------------------------------- Q: What if the data is very very large. How would you handle it?
    
    If we're dealing with a massive stream of numbers, we have to assume we can't keep all of the numbers in memory.
    
    So we'll have to consider memory contraints and streaming techniques. The current approach is efficient in terms 
    of time complexity, but the total memeory usage is O(n) where n is the number of elements in the data stream. So,
    for large data, we might hit memory limits.

    Sampling: If an exact median is not strictly necessary and an approximation of the median is acceptable, we could maintain
    a smaller sample of the stream and calculate the median from that. This would reduce memory usage.

    Disk storage: Store some of the data on disk, using external storage or a distributed computing system to store the numbers

    --------------------------------- Q: If all integer numbers from the stream are in the range [0, 100], how would you optimize your solution?

    Counting (Bucket Sort)

    Since the numbers are constrained to a small range, we could count the occurrences of each integer and maintain a count array for all 
    integers in that range.

    For example, if the stream of numbers (calls to AddNum) was the following: [1,2,3,4,5,5,5]

    Since the total number of values is 7, there is a single middle numbers (4 in this example). The "buckets" would be [0,1,1,1,1,3]
                                                                                                                         0 1 2 3 4 5

    If the total number of values in the stream is even, the we just take the two middle numbers rather than one.

    To find the median, we can simply walk through the count array to find the middle element(s) by counting occurrences.

    AddNum:
    Time: O(1)
    Space: O(1) - because the size of the array of buckets would never grow past 100

    FindMedian:
    Time: O(1) - because O(100) = O(1)
    Space: O(1)

    --------------------------------- Q: If 99% of all integer numbers from the stream are in the range [0, 100], how would you optimize your solution?

    ...

*/
