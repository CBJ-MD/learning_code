public class Solution {
    public bool IsHappy(int n) {
        List<int> lst = new List<int>();
        while (n != 1)
        {
            if (lst.Contains(n))
            {
                return false;
            }
            lst.Add(n);
            n = DigitSquare(n);
        }
        return true;
    }

    private int DigitSquare(int num){
        int sum = 0;
        while (num!=0)
        {
            sum += (int)Math.Pow(num%10,2);
            num /= 10;
        }
        return sum;
    }
}