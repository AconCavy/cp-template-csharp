#!/bin/sh

dotnet pack
dotnet new -i ./bin/Debug/AconCavy.CompetitiveProgramming.Templates.1.0.0.nupkg
