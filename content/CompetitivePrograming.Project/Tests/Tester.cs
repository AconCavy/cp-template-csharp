using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public static class Tester
    {
        public static void InOutTest(Action solve, string input, string output)
        {
            using var reader = new StringReader(input);
            Console.SetIn(reader);
            var builder = new StringBuilder();
            using var writer = new StringWriter(builder);
            Console.SetOut(writer);
            solve();
            Assert.AreEqual(output, builder.ToString());
        }

        public static void InOutTest(Action solve, string input, string output, double relativeError)
        {
            using var reader = new StringReader(input);
            Console.SetIn(reader);
            var builder = new StringBuilder();
            using var writer = new StringWriter(builder);
            Console.SetOut(writer);
            solve();
            foreach (var (expectedLine, actualLine) in output.Split('\n').Zip(builder.ToString().Split('\n')))
                foreach (var (expected, actual) in expectedLine.Split(' ').Zip(actualLine.Split(' ')))
                    if (double.TryParse(expected, out var expectedValue) && double.TryParse(actual, out var actualValue))
                        Assert.AreEqual(expectedValue, actualValue, relativeError);
                    else Assert.AreEqual(expected, actual);
        }
    }
}
