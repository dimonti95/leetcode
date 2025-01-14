public class Solution
{
    public bool IsValid(string s)
    {
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
                if (c == '}' && c1 != '{') return false;
                if (c == ']' && c1 != '[') return false;
                if (c == ')' && c1 != '(') return false;
            }
        }

        return stack.Count == 0;
    }
}

/*
    
    Time Complexity: O(n)
    Space Complexity: O(n)
    
    Where n is the length of the string

    Key insights: 
    * Once you validate a opening/closing pair, you can ignore it
    * You're always comparing with the most recent open bracket

*/
