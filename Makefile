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

# Performance	
# ps -eo pid,ppid,comm | grep NetFoundy.Performance | grep -v dotnet | awk '{print $1}'
# dotnet-counters ps | grep NetFoundy.Performance | awk '{print $1}'
counters-collect:
	pid=$$(dotnet-counters ps | grep NetFoundy.Performance | awk '{print $$1}'); \
    echo "PID=$$pid"; \
    dotnet-counters collect --duration 00:00:20 --output counters.performance.csv --process-id $$pid 
 
counters-monitor:
	pid=$$(dotnet-counters ps | grep NetFoundy.Performance | awk '{print $$1}'); \
	echo "PID=$$pid"; \
	dotnet-counters monitor --process-id $$pid System.Runtime