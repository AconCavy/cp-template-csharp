using System;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests;

public static class Utility
{
    public static void InOutTest(Action solve, string input, string output)
    {
        using var reader = new StringReader(input);
        Console.SetIn(reader);
        var builder = new StringBuilder();
        using var writer = new StringWriter(builder);
        Console.SetOut(writer);
        solve();
        var expected = output.Replace("\r", "").Trim();
        var actual = builder.ToString().Replace("\r", "").Trim();
        Assert.That(actual, Is.EqualTo(expected));
    }

    public static void InOutTest(Action solve, string input, string output, double relativeError)
    {
        using var reader = new StringReader(input);
        Console.SetIn(reader);
        var builder = new StringBuilder();
        using var writer = new StringWriter(builder);
        Console.SetOut(writer);
        solve();
        var expectedSource = output.Replace("\r", "").Trim();
        var actualSource = builder.ToString().Replace("\r", "").Trim();
        foreach (var (expectedLine, actualLine) in expectedSource.Split('\n').Zip(actualSource.Split('\n')))
            foreach (var (expected, actual) in expectedLine.Split(' ').Zip(actualLine.Split(' ')))
                if (double.TryParse(expected, out var expectedValue) && double.TryParse(actual, out var actualValue))
                    Assert.That(expectedValue, Is.EqualTo(actualValue).Within(relativeError));
                else Assert.That(actual, Is.EqualTo(expected));
    }
}
