using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems.Problem98
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    /* public class Solution {
    public bool IsValidBST(TreeNode root) {
        return IsValid(root, null, null);
    }

    private bool IsValid(TreeNode root, int? max, int? min){
        if(root == null) return true;
        if(max != null && root.val >= max) return false;
        if(min != null && root.val <= min) return false;

        return IsValid(root.left, root.val, min)&&
            IsValid(root.right, max, root.val);
    }
}
*/
    public class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            int[] nodelist = GetNodes(root).ToArray();
            int[] sortednodelist = nodelist.Clone() as int[];
            Array.Sort(sortednodelist);
            return nodelist.Equals(sortednodelist);
        }

        private List<int> GetNodes(TreeNode root)
        {
            if (root == null) return new List<int>();
            List<int> result = GetNodes(root.left);
            result.Add(root.val);
            result.AddRange(GetNodes(root.right));
            return result;

        }
    }
}