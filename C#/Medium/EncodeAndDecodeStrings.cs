public class Codec {

    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs)
    {
        var sb = new StringBuilder();
        foreach (string str in strs)
        {
            sb.Append(str.Replace("/", "//") + "/*");
        }

        return sb.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s)
    {
        var strs = new List<string>();
        var sb = new StringBuilder();

        int i = 0;
        while (i < s.Length)
        {
            if (i + 1 < s.Length && s[i] == '/' && s[i + 1] == '*')
            {
                strs.Add(sb.ToString());
                sb.Clear();
                i += 1;
            }
            else if (i + 1 < s.Length && s[i] == '/' && s[i + 1] == '/')
            {
                sb.Append(s[i]);
                i += 1;
            }
            else
            {
                sb.Append(s[i]);
            }
            i += 1;
        }

        return strs;
    }
}

/*

    Note: The input strings will only consist of ASCII characters.

    Brute force approach:
    1. Choose a non-ASCII character to use as a delimeter
    2. Encode the strings into a single string, delimeted by that non-ASCII character
    Time: O(n)
    Space: O(m)

    Where n is the total number of characters and m is the total number of strings.

    ----------------------------------------------------------------------------------------

    Follow up: Could you write a generalized algorithm to work on any possible set of characters?

    Solution (optimization 1):
    1. Use some sequence of characters as a delimieter, like "/*" (this is called an escape sequence)
    2. If the escape sequence ("/*") appears anywhere in the input strings, escape it using a designated escape character, such as "/"
        - Any string that includes "/*" is updated to include "//*" to indicate that the "/* is not a delimeter
    Time: O(n)
    Space: O(m) because we're adding additional space for each delimeter

    Where n is the total number of characters and m is the total number of strings.

    This works the same way as C# escape sequences like "\n", which allow you to represent special characters that cannot be
    directly typed into a string, such as tab, newline, or quotation marks. If you want the character sequence "\n" (backslash followed by the letter n)
    to appear as part of the string literally, without it being interpreted as a newline character, you need to escape the backslash.
    
*/



public class Codec2
{

    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs)
    {
        var sb = new StringBuilder();   
        foreach (string s in strs)
        {
            sb.Append(s.Length + "#" + s);
        }

        return sb.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s)
    {
        var res = new List<string>();
        int i = 0;
        while (i < s.Length)
        {
            int j = s.IndexOf("#", i);
            int len = Int32.Parse(s.Substring(i, j - i));
            res.Add(s.Substring(j + 1, len));
            i = j + len + 1;
        }

        return res;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));

/*

    Note: The input strings will only consist of ASCII characters.

    Optimization 2:
    1. Use a Chunked transfer encoding
    2. Add the length of each string followed by some delimeter like # before each string
    Time: O(n)
    Space: O(m)

    Where n is the total number of characters and m is the total number of strings.

*/
