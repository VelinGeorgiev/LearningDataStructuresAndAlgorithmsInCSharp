using Learning.Recursion;
using NUnit.Framework;

namespace Learning.RecursionTests
{
    [TestFixture]
    public class RecursionTests
    {
        private readonly Permutations _permutation;

        public RecursionTests()
        {
            _permutation = new Permutations();
        }

        [Test]
        public void GetPermutationOfInts()
        {
            var array = new[] {1,2,3};
            _permutation.GetPermutation(array);
        }

        [Test]
        public void GetPermutationOfChars()
        {
            var array = new[] { 'a', 'b', 'c' };
            _permutation.GetPermutation(array);
        }
    }
}
