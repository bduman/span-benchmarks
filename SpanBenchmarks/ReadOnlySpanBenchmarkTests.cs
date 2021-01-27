using System;
using BenchmarkDotNet.Attributes;

namespace SpanBenchmarks
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    [MemoryDiagnoser]
    public class ReadOnlySpanBenchmarkTests
    {
        [Benchmark]
        public string GetValueUsingSubstring()
        {
            string expression = "gender=female";
            var lastEqualSignIndex = expression.LastIndexOf('=');

            return lastEqualSignIndex == -1
              ? string.Empty
              : expression.Substring(lastEqualSignIndex + 1);
        }

        [Benchmark]
        public ReadOnlySpan<char> GetValueUsingSpan()
        {
            ReadOnlySpan<char> expression = "gender=female";
            var lastEqualSignIndex = expression.LastIndexOf('=');

            return lastEqualSignIndex == -1
            ? ReadOnlySpan<char>.Empty
            : expression.Slice(lastEqualSignIndex + 1);
        }
    }
}
