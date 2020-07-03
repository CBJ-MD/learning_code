public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        if (nums.Length<2)
        {
            return new int[0];
        }
        var dic = new Dictionary<int,int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int temp = target - nums[i];
            if (dic.ContainsKey(temp))
            {
                return new int[]{dic[temp],i};
            }
            else if (!dic.ContainsKey(nums[i]))
            {
                dic.Add(nums[i],i);   
            }
        }
        return new int[0];
    }
}