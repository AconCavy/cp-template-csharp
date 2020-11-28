using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public static class Tester
    {
        public static void InOutTest(Action solve, string input, string output)
        {
            using var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var builder = new StringBuilder();
            using var stringWriter = new StringWriter(builder);
            Console.SetOut(stringWriter);

            solve();

            using var expectedReader = new StringReader(output.ToString());
            using var actualReader = new StringReader(builder.ToString());
            while (true)
            {
                var expected = expectedReader.ReadLine();
                var actual = actualReader.ReadLine();
                if (actual == null && expected == null) return;
                Assert.AreEqual(expected, actual);
            }
        }

        public static void InOutTest(Action solve, string input, string output, double delta)
        {
            using var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var builder = new StringBuilder();
            using var stringWriter = new StringWriter(builder);
            Console.SetOut(stringWriter);

            solve();

            using var expectedReader = new StringReader(output.ToString());
            using var actualReader = new StringReader(builder.ToString());
            while (true)
            {
                var expected = expectedReader.ReadLine();
                var actual = actualReader.ReadLine();
                if (actual == null && expected == null) return;
                if (double.TryParse(expected, out var expectedValue)
                && double.TryParse(actual, out var actualValue))
                    Assert.AreEqual(expectedValue, actualValue, delta);
                else Assert.AreEqual(expected, actual);
            }
        }
    }
}