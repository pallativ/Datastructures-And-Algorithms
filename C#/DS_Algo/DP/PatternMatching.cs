using Xunit;

namespace Datastructures.DP
{
    public class PatternMatching
    {

        public bool IsMatch(string s, string p)
        {
            // if s or p is empty return false.
            if (s == string.Empty || p == string.Empty)
                return false;

            // pattern contains = "*" return return true.
            if (p == "*")
                return true;
            bool[,] memo = new bool[s.Length + 1, p.Length + 1];
            // got to next first both characters are equal or pattern contains ?
            // if the next character in pattern contains "*"
            // we consider the * and move to the next character.
            // or don't consider and move to the next character.
            return IsMatch(s, p, 0, 0, memo);
        }

        public bool IsMatch(string s, string p, int sIndex, int pIndex, bool[,] memo)
        {
            if (memo[sIndex, pIndex])
                return true;

            bool ans = false;
            if (pIndex == p.Length)
                ans = (sIndex == s.Length);
            else
            {
                bool first_match = sIndex < s.Length && (s[sIndex] == p[pIndex] || p[pIndex] == '.');


                // Consider * and Skip * case.
                if (pIndex + 1 < p.Length && p[pIndex + 1] == '*')
                    ans = IsMatch(s, p, sIndex, pIndex + 2, memo) || 
                        (first_match && IsMatch(s, p, sIndex + 1, pIndex, memo));
                else
                    ans = first_match && IsMatch(s, p, sIndex + 1, pIndex + 1, memo);
            }
            memo[sIndex, pIndex] = ans;
            return ans;
        }


        [Theory]
        [InlineData("aa", "a", false)]
        [InlineData("aa", "a*", true)]
        [InlineData("ab", ".*", true)]
        [InlineData("aab", "c*a*b", true)]
        [InlineData("mississippi", "mis*is*p*.", false)]
        public void Test(string s, string p, bool expected)
        {
            var actual = IsMatch(s, p);
            Assert.Equal(actual, expected);
        }
    }
}
