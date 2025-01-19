public class Solution
{
    public string AddBinary(string a, string b)
    {
        if (a.Length < b.Length) return AddBinary(b, a);

        var sb = new StringBuilder();
        int j = b.Length - 1;
        int carry = 0;
        for (int i = a.Length - 1; i >= 0; i--)
        {
            if (a[i] == '1')
                carry++;
            if (j >= 0 && b[j--] == '1')
                carry++;
            
            sb.Append(carry % 2);
            carry /= 2;
        }

        if (carry == 1) sb.Append('1');
        return new string(sb.ToString().Reverse().ToArray());
    }
}

/*

    Binary manipulation

    Time: O(max(n,m))
    Space: O(max(n,m)) - for the result, which may or may not count towards space complexity

    Where n is the length of a and m is the length of b

*/
