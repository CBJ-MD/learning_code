namespace LeetCodePractice.Problems.Problem5
{
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            string result = string.Empty;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < s.Length; j += (numRows - i) * 2 - 3)
                {
                    result += s[j];
                    s = s.Remove(j, 1);
                }
            }
            return result;
        }
    }
}
