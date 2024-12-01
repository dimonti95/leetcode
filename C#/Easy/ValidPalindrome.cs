public class Solution {
    public bool IsPalindrome(string s) {
        int left = 0;
        int right = s.Length - 1;

        while (left <= right)
        {
            while (!Char.IsLetterOrDigit(s[left]) && left < right) left++;
            while (!Char.IsLetterOrDigit(s[right]) && left < right) right--;

            char c1 = s[left];
            char c2 = s[right];
            bool isAlphanumeric = Char.IsLetterOrDigit(c1) && Char.IsLetterOrDigit(c2);
            if (isAlphanumeric && Char.ToLower(c1) != Char.ToLower(c2)) return false;
            
            right--;
            left++;
        }

        return true;
    }
}

/*

  Two pointers on each end ignoring case and non-alphanumerics

  Time Complexity: O(n)
  Space Complexity: O(1)

*/
