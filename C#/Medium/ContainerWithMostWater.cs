public class Solution
{
    public int MaxArea(int[] height)
    {
        int max = 0;
        int left = 0;
        int right = height.Length - 1;
        while (left < right)
        {
            int w = right - left;
            int h = Math.Min(height[left], height[right]);
            max = Math.Max(max, w * h);

            if (height[left] < height[right]) left++;
            else right--;
        }

        return max;
    }
}

/*

    Two pointers, move the pointer at the smaller value
    
    Time Complexity: O(n)
    Space Complexity: O(1)

    Key insight: Moving the pointer at the larger value will always decrease the area (container size).

*/
