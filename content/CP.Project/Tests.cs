using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"",
            @"")]
        [TestCase(
            @"",
            @"")]
        [TestCase(
            @"",
            @"")]
        public void SolverTest(string input, string output)
        {
            Utility.InOutTest(Tasks.Solver.Solve, input, output, 1e-9);
        }
    }
}
