using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice.Problems.Problem783
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Solution
    {
        public void DFS(TreeNode node, ref int preVal, ref int minDiff)
        {
            if (node == null) return;
            DFS(node.left, ref preVal, ref minDiff);
            if (preVal != -1) minDiff = Math.Min(minDiff, Math.Abs(node.val - preVal));
            preVal = node.val;
            DFS(node.right, ref preVal, ref minDiff);
        }

        public int MinDiffInBST(TreeNode root)
        {
            int minDiff = int.MaxValue;
            int preVal = -1;
            DFS(root, ref preVal, ref minDiff);
            return minDiff;
        }
    }
}
