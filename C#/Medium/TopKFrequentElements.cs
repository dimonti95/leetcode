public class Solution
{
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
        foreach (KeyValuePair<int, int> pair in frequency)
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

    Brute force solution (not implemented here):
    1. Create a coup map (value -> count)
    2. Sort by value (the count)
    3. Add the largest k values
    Time: O(nlogn)
    Space: O(n)

    Where n is the number of integers in the input array nums

    ----------------------------------------------------------------------

    Solution (implemented):
    1. Create a count map (value -> count)
    2. Add k elements to a min heap (prioritized by count <value, count>)
    3. Remove any elements after k so that the heap doesn't grow to be larger than k
    4. Move k remaining elements from the heap (only the largest elements will remain)
    Time: O(nlogk)
    Space: O(n + k)

    Where n is the number of integers in the input array nums

*/



public class Solution2
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var count = new Dictionary<int, int>();
        var buckets = new List<int>[nums.Length + 1]; // n + 1 since count can be n
        var result = new List<int>();

        // Map integer value to count
        foreach (int num in nums)
        {
            if (!count.ContainsKey(num)) count.Add(num, 0);
            count[num] += 1;
        }

        for (int i = 0; i < nums.Length + 1; i++) buckets[i] = new List<int>();
        foreach (KeyValuePair<int, int> pair in count) buckets[pair.Value].Add(pair.Key);

        // Take the k largest elements
        for (int i = buckets.Length - 1; i >= 0; i--)
        {
            List<int> vals = buckets[i];
            foreach (int num in vals)
            {
                result.Add(num);
                if (result.Count == k) return result.ToArray();
            }
        }

        return result.ToArray();
    }
}

/*

    Solution 3 (optimal):
    1. Create a count map (value -> count)
    2. Run a bucket sort 
    3. Take the elements with the highest frequency count
    Time: O(n)
    Space: O(n)

    Where n is the number of integers in the input array nums

*/
