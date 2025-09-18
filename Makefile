build:
	dotnet build NetFoundy.sln

build-release:
	dotnet build NetFoundy.sln

n ?= 

concepts:
	dotnet run --project src/Concepts/NetFoundy.Concepts.csproj -- $(n)

patterns:
	dotnet run --project src/DesignPatterns/NetFoundy.DesignPatterns.csproj -- $(n)

performance:
	dotnet run -c Release --project src/Performance/NetFoundy.Performance.csproj -- $(n)

async:
	dotnet run --project src/AsynchronousProgramming/NetFoundy.AsynchronousProgramming.csproj -- $(n)