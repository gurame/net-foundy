build:
	dotnet build NetFoundy.sln

n ?= 

concepts:
	dotnet run --project src/Concepts/NetFoundy.Concepts.csproj -- $(n)