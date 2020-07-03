public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        IList<string> result = new List<string>();
        GenerateOne("", ref result, n, n);
        return result;
    }

    private void GenerateOne(string OneAnswer ,ref IList<string> result, int left, int right) {
        if (left == 0 && right == 0)
        {
            result.Add(OneAnswer);
            return;
        }
        if (left > 0)
        {
            GenerateOne(OneAnswer + "(", ref result, left - 1, right);
        }
        if (left < right)
        {
            GenerateOne(OneAnswer + ")", ref result, left, right - 1);
        }
    }
}