using LeetCodePractice.Problems.Problem1991;

namespace UnitTest.ProblemTests
{
    [TestClass]
    public class Test1991
    {
        [TestMethod]
        [DataRow(new int[] { 2, 3, -1, 8, 4 }, 3)]
        [DataRow(new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
        [DataRow(new int[] { 1, -1, 4 }, 2)]
        [DataRow(new int[] { 2, 5 }, -1)]
        public void TestMethod1(int[] nums, int result)
        {
            Solution s = new();
            int calc = s.FindMiddleIndex(nums);
            Assert.AreEqual(calc, result);
        }
    }
}
