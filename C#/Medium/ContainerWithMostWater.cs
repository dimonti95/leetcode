public class Solution {
    public int MaxArea(int[] height) {
        int left = 0;
        int right = height.Length - 1;
        int max = 0;

        while (left < right)
        {
            int minHeight = Math.Min(height[left], height[right]);
            int distance = right - left;
            max = Math.Max(max, minHeight * distance);

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        
        return max;
    }
}

/*

    Two pointers, move the pointer at the smaller value
    
    Time Complexity: O(n)
    Space Complexity: O(1)

*/
