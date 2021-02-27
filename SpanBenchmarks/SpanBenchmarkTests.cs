using BenchmarkDotNet.Attributes;
using System;

namespace SpanBenchmarks
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    [MemoryDiagnoser]
    public class SpanBenchmarkTests
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

        [Benchmark]
        public void GetArrayUsingSpan()
        {
            Span<int> array = stackalloc int[5];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
        }

        [Benchmark]
        public void GetArray()
        {
            int[] array = new int[5];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
        }

        [Benchmark]
        public void GetSliceOfArrayUsingSpan()
        {
            Span<int> span = stackalloc int[5];

            for (int i = 0; i < span.Length; i++)
            {
                span[i] = i;
            }

            var span2 = span.Slice(start: 1, length: 3);
        }

        //TODO: Memory<T>
    }
}
