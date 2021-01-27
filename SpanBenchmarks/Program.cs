using BenchmarkDotNet.Running;

namespace SpanBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ReadOnlySpanBenchmarkTests>();
        }
    }
}
