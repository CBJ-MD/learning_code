using LeetCodePractice.Problems.Problem10;

namespace UnitTest
{
    [TestClass]
    public class Test10
    {
        [TestMethod]
        [DataRow("", "", true)]
        [DataRow(".*", "abbccc", true)]
        [DataRow("a*", "abbccc", false)]
        [DataRow("a*", "aaa", true)]
        [DataRow("a.*", "abbccc", true)]
        [DataRow("ab.*", "abbccc", true)]
        [DataRow(".b.*", "abbccc", true)]
        [DataRow("c*a*b", "aab", true)]
        [DataRow("ab*a*c*a", "aaa", true)]
        public void TestMethod1(string pattern, string str, bool result)
        {
            Solution s = new();
            bool calc = s.IsMatch(str, pattern);
            Assert.AreEqual(calc, result);
        }
    }
}