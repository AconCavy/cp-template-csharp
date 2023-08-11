using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"",
        @"",
        TestName = "{m}-1")]
    [TestCase(
        @"",
        @"",
        TestName = "{m}-2")]
    [TestCase(
        @"",
        @"",
        TestName = "{m}-3")]
    public void SolverTest(string input, string output)
    {
        Utility.InOutTest(Tasks.Solver.Solve, input, output, 1e-9);
    }
}
