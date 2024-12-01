public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();

        foreach (char c in s)
        {
            if (c == '{' || c == '[' || c == '(')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0) return false;
                char c1 = stack.Pop();
                bool isInvalid = (c == '}' && c1 != '{') || (c == ']' && c1 != '[') || (c == ')' && c1 != '(');
                if (isInvalid) return false;
            }
        }

        return stack.Count == 0;
    }
}

/*
    
    Time Complexity: O(n)
    Space Complexity: O(n)
    
    Where n is the length of the string

*/
