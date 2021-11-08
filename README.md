# Overview

The template is the dotnet custom templates for competitive programming.

The templates include

- Project
- Solver class
- Test class

# How To Use

## Install

You should install the templates.
You can download the `nupkg` from [Releases](https://github.com/AconCavy/CompetitiveProgrammingTemplateCSharp/releases), then install the templates using a `dotnet new` command.

```sh
dotnet new -i {/path/to/}AconCavy.CompetitiveProgramming.Templates.{version}.nupkg
```

## Create Project

After installing, you can create a project to use a `dotnet new cpproj` command.
And, you can specify the project name using a `-n|--name` option.

Then, the base project that includes a `Tasks` and a `Tests` project is created.

```sh
dotnet new cpproj -n Sample
```

And, you can specify a target framework using a `-f|--framework` option.
The default target framework is a `netcoreapp3.1`.

The target frameworks can be specified

- net6.0
- netcoreapp3.1
- netstandard2.1
- netstandard2.0

```sh
dotnet new cpproj -n Sample -f net6.0
```

Or, you can specify another target framework using a `--target-framework-override` option.

## Create Solver class

After creating the project, you should create a solver class in the `Tasks` project.
You can create the solver class to use a `dotnet new cpsolver` command and place it under `Tasks`.

```sh
dotnet new cpsolver -n TaskA -o ./Tasks
```

After that, you can check the created class named `TaskA` like the following.
Then, you can implement a `Solve` method for tasks.

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
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            // implement here !
            // var x = Console.ReadLine();
            // Console.WriteLine(x);
        }
    }
}
```

## Create Tests class

You can check the behavior of the solver class to use the `MSTest` test class.

You can create the solver class to use a `dotnet new cptests` command and place it under `Tests`.

```sh
dotnet new cptests -n TaskA -o ./Tests
```

Then, you can create test cases for the solver class.
You should fill in `input` and `output`.

As options, you can edit the `TimeLimit` field that can specify the execution time limit.

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TaskATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"Foo"; // input
            const string output = @"FooBar"; // expected output 
            Tester.InOutTest(Tasks.TaskA.Solve, input, output);
        }
    }
}
```

You can also specify the relative error using the `RelativeError` field by adding to the argument in the `Tester.InOutTest` method.

```csharp
[TestMethod, Timeout(TimeLimit)]
public void Test2()
{
    const string input = @"1";
    const string output = @"0.125000000";
    Tester.InOutTest(Tasks.TaskA.Solveinput, output, RelativeError); // add argument
}
```

## Execution of the project

If you created multiple solver classes, you should change the `StartupObject` property in the `Tasks.csproj` to execute the specific task.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>

    <!-- change here -->
    <StartupObject>Tasks.TaskA</StartupObject>
    <!-- <StartupObject>Tasks.TaskB</StartupObject> -->
    <!-- ... -->

  </PropertyGroup>

</Project>
```

Then, you can execute the solver class.

```sh
dotnet run -p ./Tasks
```

Or, you can execute the tests.

```sh
dotnet test
```

## Uninstall

You can uninstall the templates from your environment.

```sh
dotnet new -u AconCavy.CompetitiveProgramming.Templates
```
