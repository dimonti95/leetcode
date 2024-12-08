public class Codec {

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

    The input strings will only consist of ASCII characters.

    Brute force approach:
    1. Choose a non-ASCII character to use as a delimeter
    2. Encode the strings into a single string, delimeted by that non-ASCII character
    Time: O(n)
    Space: O(m)

    Where n is the total number of characters and m is the total number of strings.

    Optimization 1:
    1. Use some uncommon sequence of characters as a delimieter, like "*x"
    2. If that sequence of characters appears anywhere in the input strings, escape them using some escape character, like "#"
        - Any string that includes "*x" is updated to include "#*x" to indicate it's not a delimeter
        - Any string that already includes "#*x" isn't affected
    Time: O(n)
    Space: O(m)

    Where n is the total number of characters and m is the total number of strings.

    Optimization 2:
    1. Use a Chunked transfer encoding
    2. Add the length of each string followed by some delimeter like # before each string
    Time: O(n)
    Space: O(m)

    Where n is the total number of characters and m is the total number of strings.

*/
