public class Solution {
    public int SingleNumber(int[] nums) {
        nums.Sort();
        for (int i = 0; i < nums.Length; i+=2)
        {
            if (i + 1 == nums.Length)
            {
                return nums[i];
            }
            if (nums[i] != nums[i+1])
            {
                return nums[i];
            }   
        }
    }

    public int SingleNumber(int[] nums) {
        List<int> lst = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (lst.Contains(nums[i]))
            {
                lst.Remove(nums[i]);
            }
            else
            {
                lst.Add(nums[i]);
            }
        }
        return lst[0];
    }

    public int SingleNumber(int[] nums) {
        List<int> lst = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (lst.Contains(nums[i]))
            {
                lst.Remove(nums[i]);
            }
            else
            {
                lst.Add(nums[i]);
            }
        }
        return lst[0];
    }

    public int SingleNumber(int[] nums) {
        int a = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            a ^= nums[i];
        }
        return a;
    }
}