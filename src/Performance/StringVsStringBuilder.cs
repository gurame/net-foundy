using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

class StringVsStringBuilder
{
    public static void Run()
    {
        // Benchmarking
        BenchmarkRunner.Run<StringVsStringBuilderBenchmarks>();
    }
}

[MemoryDiagnoser]
public class StringVsStringBuilderBenchmarks
{
    private const int Iterations = 10_000;

    [Benchmark]
    public string StringConcat()
    {
        string s = string.Empty;
        for (int i = 0; i < Iterations; i++)
        {
            s += "x"; // crea un nuevo string en cada iteración
        }
        return s;
    }

    [Benchmark]
    public string StringBuilderAppend()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < Iterations; i++)
        {
            sb.Append("x"); // escribe en el buffer interno
        }
        return sb.ToString();
    }
}