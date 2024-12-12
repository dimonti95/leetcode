public class Solution {
    public int[] TopKFrequent(int[] nums, int k)
    {
        var frequency = new Dictionary<int, int>();
        var pQueue = new PriorityQueue<int, int>();
        var result = new List<int>();

        // Init the dictionary
        foreach (int num in nums)
        {
            if (!frequency.ContainsKey(num)) frequency.Add(num, 0);
            frequency[num] += 1;
        }
        
        // Add k elements to the heap (don't want it growing larger than k)
        foreach (var pair in frequency)
        {
            int num = pair.Key;
            int freq = pair.Value;
            pQueue.Enqueue(num, freq);
            if (pQueue.Count > k) pQueue.Dequeue();
        }

        // Move k largest elements into list
        while (pQueue.Count > 0)
        {
            result.Add(pQueue.Dequeue());
        }

        return result.ToArray();
    }
}

/*

    Solution:
    1. Create a count map (value -> count)
    2. Add k elements to a min heap (prioritized by count <value, count>)
    3. Remove any elements after k so that the heap doesn't grow to be larger than k
    4. Move k remaining elements from the heap (only the largest elements will remain)
    Time: O(nlogk)
    Space: O(n + k)

*/
