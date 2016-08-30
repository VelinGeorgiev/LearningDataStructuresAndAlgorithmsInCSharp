using System.Collections.Generic;
using Learning.InterviewQuestions.Strings;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Strings
{
    [TestFixture]
    public class StringQuestionsTests
    {
        private readonly StringsQuestions _sq;

        public StringQuestionsTests()
        {
            _sq = new StringsQuestions();
        }

        [Test]
        public void Permute()
        {
            char[] arr = { 'a', 'b', 'c' };
            IList<char[]> list = new List<char[]>();
            _sq.Permute(arr, 0, arr.Length - 1, list);

            Assert.AreEqual(list[5][0], 'c'); // todo: fix this
            Assert.AreEqual(list[5][1], 'a');
            Assert.AreEqual(list[5][2], 'b');
        }


        [Test]
        public void RemoveDirtyCharacters()
        {
            Assert.AreEqual(_sq.RemoveDirtyCharacters("geeksforgeeks", "geeks"), "for");
        }

        [Test]
        public void RunLengthEncoding()
        {
            Assert.AreEqual(_sq.RunLengthEncoding("wwwwaaadexxxxxx"), "w4a3d1e1x6");
        }

        [Test]
        public void Convert0To5()
        {
            Assert.AreEqual(_sq.Convert0To5(10120), 15125);
        }

        [Test]
        public void CountSubStr()
        {
           Assert.AreEqual(_sq.CountSubStr(("00100101").ToCharArray(), 8), 3);
        }

        [Test]
        public void FirstNonRepeatedCharacter()
        {
            Assert.AreEqual(_sq.FirstNonRepeatedCharacter("geeksforgeeks"), 'f');
        }

        [Test]
        public void KthNonRepeatedCharacter()
        {
            Assert.AreEqual(_sq.KthNonRepeatedCharacter("geeksforgeeks", 3), 'r');
        }

        [Test]
        public void PatternSearch()
        {
            Assert.AreEqual(_sq.PatternSearch("AAAB", "AAAAAAAAB"), 5);
        }
        [Test]
        public void IsIsomorphic()
        {
            Assert.IsTrue(_sq.IsIsomorphic("egg", "add"));
            Assert.IsFalse(_sq.IsIsomorphic("foo", "bar"));
        }
        
    }
}
