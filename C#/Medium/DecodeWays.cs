public class Solution
{
    public int NumDecodings(string s)
    {
        var memo = new Dictionary<int, int>();

        int NumDecodingsRecurse(int i, string s)
        {
            if (memo.ContainsKey(i)) return memo[i];
            if (i == s.Length) return 1;
            if (s[i] == '0') return 0;
            if (i == s.Length - 1) return 1;

            int result = NumDecodingsRecurse(i + 1, s);

            string pair = s.Substring(i, 2);
            if (int.Parse(pair) <= 26)
            {
                result += NumDecodingsRecurse(i + 2, s);
            }

            memo[i] = result;
            return memo[i];
        }

        return NumDecodingsRecurse(0, s);
    }
}

/*

    Top-down DP (memoization)

    Time: O(N)
    Space: O(N)

*/



public class Solution
{
    public int NumDecodings(string s)
    {
        var table = new int[s.Length + 1];
        table[0] = 1;
        if(s[0] != '0') table[1] = 1;

        for (int i = 2; i < table.Length; i++)
        {
            if (s[i - 1] != '0')
            {
                table[i] = table[i - 1];
            }

            string twoDigit = s.Substring(i - 2, 2);
            if (int.Parse(twoDigit) >= 10 && int.Parse(twoDigit) <= 26)
            {
                table[i] += table[i - 2];
            }
        }

        return table[table.Length - 1];
    }
}

/*

    Bottom-up DP (tabulation)
    Time: O(n)
    Space: O(n)

    --------------------------------------------------------------------------------

    Example:
    Input: s="26201"
    Output: 2

    i = -
    table = [1,0,0,0,0,0]  always init the first index of the table to 1
               2 6 2 0 1

    i = -                  check single character at s[0]
    table = [1,1,0,0,0,0]  set table[1] to 1 because the first character in the string is not '0'
               2 6 2 0 1

    i = 2
    table = [1,1,1,0,0,0]  set table[2] = table[1] because '6' is not '0'
               2 6 2 0 1   
                 ^
    table = [1,1,2,0,0,0]  set table[2] += table[0] since 10 <= 26 <= 26
               2 6 2 0 1
                 ^
    
    i = 3
    table = [1,1,2,2,0,0]  set table[3] = table[2], because '2' is not '0'
               2 6 2 0 1   
                   ^ 
    table = [1,1,2,2,0,0]  keep table[3] at 2, since 26 <= 62
               2 6 2 0 1   
                   ^ 
    
    i = 4
    table = [1,1,2,2,0,0]  keep table[4] at 0, because the second character of '20' is '0'
               2 6 2 0 1
                     ^ 
    table = [1,1,2,2,2,0]  set table[4] += table[2], since 10 <= 20 <= 26
               2 6 2 0 1   
                     ^

    i = 5
    table = [1,1,1,2,2,2]  set table[5] = table[4], because the second character of '01' is not '0'
               2 6 2 0 1  
                       ^
    table = [1,1,2,2,2,2]  keep table[5] at 2, since 01 <= 10  
               2 6 2 0 1
                       ^   

*/
