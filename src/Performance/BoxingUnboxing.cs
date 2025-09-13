using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace NetFoundy.Performance;

class BoxingUnboxing
{
    public static void Run()
    {
        // Boxing and Unboxing
        int value = 42;

        // Boxing
        object boxedValue = value;

        // Unboxing
        int unboxedValue = (int)boxedValue;

        Num num = new(100);

        // Boxing
        // Why? Because structs cannot be directly assigned to interface types
        INum boxedNum = num;

        // Unboxing
        // Why? Because we need to cast back to the struct type
        boxedNum.GetValue();

        // Benchmarking
        BenchmarkRunner.Run<BoxingBenchmarks>();
    }
}

interface INum
{
    int GetValue();
}

struct Num : INum
{
    private int value;
    public Num(int value)
    {
        this.value = value;
    }
    public int GetValue()
    {
        return value;
    }
}

[MemoryDiagnoser]
public class BoxingBenchmarks
{
    private readonly BenchmarkDotNet.Engines.Consumer consumer = new();
    private readonly int value = 42;
    private readonly object boxedValue;

    public BoxingBenchmarks()
    {
        boxedValue = (object)Environment.TickCount;
    }

    [Benchmark]
    public object Box() => value;

    [Benchmark]
    public void Unbox() {
        int result = (int)boxedValue;
        consumer.Consume(result);
    }

    [Benchmark]
    public int UnboxLoop()
    {
        int sum = 0;
        for (int i = 0; i < 1000; i++)
        {
            sum += (int)boxedValue;
        }
        return sum;
    }

    [Benchmark]
    public int NoBoxing() => value;
}