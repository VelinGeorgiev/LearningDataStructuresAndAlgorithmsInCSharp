using Learning.InterviewQuestions.Graphs;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Graphs
{
    [TestFixture]
    public class BaseGraphsTests
    {
        private readonly BaseGraphs _g;

        public BaseGraphsTests()
        {
            _g = new BaseGraphs();
        }

        [Test]
        public void IsIsland()
        {
            int[,] m =  {
                {1, 1, 0, 0, 0},
                {0, 1, 0, 0, 1},
                {1, 0, 0, 1, 1},
                {0, 0, 0, 0, 0},
                {1, 0, 1, 0, 1}
            };
           Assert.AreEqual(_g.CountIslands(m), 5);
        }
    }
}
