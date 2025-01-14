public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in nums)
        {
            if (set.Contains(num))
                return true;
            set.Add(num);
        }

        return false;
    }
}

/*

  Keep a set of unique numbers and return false on duplicates
  
  Time Complexity: O(n)
  Space Complexity: O(n)

  Where n is the size of the array    

*/
