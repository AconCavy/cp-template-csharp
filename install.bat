@echo off

dotnet pack
dotnet new -i ./bin/Debug/AconCavy.CompetitiveProgramming.Templates.1.1.0.nupkg
