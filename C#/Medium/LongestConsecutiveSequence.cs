public class Solution {
    public int LongestConsecutive(int[] nums) {
        var set = new HashSet<int>(nums);

        int max = 0;
        foreach (int num in nums)
        {
            if (!set.Contains(num - 1))
            {   
                int count = 1;
                while (set.Contains(num + count)) count += 1;
                max = Math.Max(max, count);
            }
        }

        return max;
    }
}

/*

    Brute force solution:
    1. Iterates over each value in the input array nums
    2. Iterate over the array a second time looking for the next value (nums[i] + 1)
    3. Keep a running max streak/count that increments each time the nums[i] + 1 number is found in nums
    4. Once the streak fails, reset the max count and go back to step 2 and try again starting from nums[i] + 1
    Time: O(n^3)
    Space: O(1)

    Optimization 1:
    1. Sort the array
    2. Iterate through the array, keeping a count that gets reset each time a number is found that doesn't incremember by one
    3. Return the max count
    Time: O(nlogn)
    Space: O(logn or n) depending on the sorting algorithm (which depends on the language)

    Optimization 2:
    1. Iterate over the nums array and add each value to a HashSet
    2. At each nums[i], check the HashSet for nums[i] - 1
    3. If that number existing move on to the next iteration
    4. If that number doesn't exist, then use the HashSet to find the sequence size by checking nums[i] + 1, nums[i] + 2,... nums[i] + j
    Time: O(n)
    Space: O(n)

*/
