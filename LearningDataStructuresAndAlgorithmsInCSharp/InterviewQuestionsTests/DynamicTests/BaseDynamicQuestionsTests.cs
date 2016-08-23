using System.Collections.Generic;
using Learning.InterviewQuestions.DynamicProgramming;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.DynamicTests
{
    [TestFixture]
    public class BaseDynamicQuestionsTests
    {
        private readonly BaseDynamicQuestions _dynamic;

        public BaseDynamicQuestionsTests()
        {
            _dynamic = new BaseDynamicQuestions();
        }

        [Test]
        public void NumberOfPaths()
        {
            Assert.AreEqual(_dynamic.NumberOfPaths(4, 4), 20);
        }

        [Test]
        public void PrintUniqueMatrixRows()
        {
            var set = new HashSet<string>();
            int[,] mat = { 
                { 0, 1, 0, 0, 1 }, 
                { 1, 0, 1, 1, 0 }, 
                { 0, 1, 0, 0, 1 }, 
                { 1, 1, 1, 0, 0 }
            };
            _dynamic.PrintUniqueMatrixRows(mat, set);

            Assert.AreEqual(set.Count, 3);
        }

        [Test]
        public void PrintMatrixInSpiralForm()
        {
            int[,] a = { 
                {1,  2,  3,  4,  5,  6},
                {7,  8,  9,  10, 11, 12},
                {13, 14, 15, 16, 17, 18}
            };
            var list = new List<int>();
            _dynamic.PrintMatrixInSpiralForm(a, list);

            // 1 2 3 4 5 6 12 18 17 16 15 14 13 7 8 9 10 11
            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[17], 11);
        }

        [Test]
        public void CelebrityProblem()
        {
            // Person with 2 is celebrity
            int[,] a = {
                    { 0, 0, 1, 0},
                    { 0, 0, 1, 0},
                    { 0, 0, 0, 0},
                    { 0, 0, 1, 0}
            };
            Assert.AreEqual(_dynamic.CelebrityProblem(4, a), 2);
        }
    }
}
