# Competitive Programming Template for C\#

The template is the dotnet custom template for competitive programming.

The template includes

- Project
- Solver class

## How To Use

### Install

You can install the template by dotnet cli.
You can download the `nupkg` from [Releases](https://github.com/AconCavy/cp-template-csharp/releases), then install the templates using a `dotnet new` command.

```sh
dotnet new -i {/path/to/}AconCavy.CompetitiveProgramming.Templates.{version}.nupkg
```

### Create Project

After installing, you can create a project using a `dotnet new cpproj` command.
And, you can specify the project name using a `-n|--name` option.

```sh
dotnet new cpproj -n Sample
```

And, you can specify a target framework using a `-f|--framework` option.
The default target framework is a `netcoreapp3.1`.

The target frameworks can be specified

- netcoreapp3.1
- net6.0

```sh
dotnet new cpproj -n Sample -f net6.0
```

### Create Solver class

After creating the project, you can create a solver class in the project.
You can create the solver class using a `dotnet new cpsolver` command in the project.

```sh
dotnet new cpsolver -n TaskA
```

Then, the class named `TaskA` will be created.

```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class TaskA
    {
        public static void Main()
        {
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            // implement here!
            // var x = Console.ReadLine();
            // Console.WriteLine(x);
        }
    }
}
```

### Create Tests class

You can check the behavior of the solver class using `NUnit` test class.

```csharp
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"", // input
            @"")] // output
        public void SolverTest(string input, string output)
        {
            Utility.InOutTest(Tasks.Solver.Solve, input, output);
        }
    }
}
```

You can also specify a relative error in the argument of the `Utility.InOutTest` method.

```csharp
[Timeout(2000)]
[TestCase(
    @"1", // input
    @"0.125000000")] // output
public void TaskATest(string input, string output)
{
    Utility.InOutTest(Tasks.TaskA.Solve, input, output, 1e-9); // relative error
}
```

### Execution of the project

If you created multiple solver classes, you should change the `StartupObject` property in the `{Project}.csproj` to execute the specific task.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>

    <!-- update here -->
    <StartupObject>Tasks.TaskA</StartupObject>

  </PropertyGroup>

</Project>
```

Then, you can execute the solver class or tests.

```sh
dotnet run
dotnet test
```

### Uninstall

You can uninstall the template.

```sh
dotnet new -u AconCavy.CompetitiveProgramming.Templates
```
