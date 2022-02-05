using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CompetitivePrograming.TestsTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"";
            const string output = @"";
            Utility.InOutTest(Tasks.CompetitivePrograming.Tests.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"";
            const string output = @"";
            Utility.InOutTest(Tasks.CompetitivePrograming.Tests.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"";
            const string output = @"";
            Utility.InOutTest(Tasks.CompetitivePrograming.Tests.Solve, input, output);
        }
    }
}
