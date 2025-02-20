build:
	dotnet build NetFoundy.sln

n ?= 

concepts:
	dotnet run --project src/Concepts/NetFoundy.Concepts.csproj -- $(n)

patterns:
	dotnet run --project src/DesignPatterns/NetFoundy.DesignPatterns.csproj -- $(n)