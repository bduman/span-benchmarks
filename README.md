# Span Benchmarks

I run benchmark tests based on this [article](https://medium.com/swlh/optimized-codes-using-span-t-an-introduction-ab8b396e131)

If you want to add any kind of span benchmarks, feel free to contribute.

``` ini
BenchmarkDotNet=v0.12.1, OS=macOS 11.1 (20C69) [Darwin 20.2.0]
Apple M1 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET Core SDK=5.0.102
  [Host]     : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  Job-ZCMTQU : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

IterationCount=30  LaunchCount=3  WarmupCount=10  
```
|                 Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |----------:|----------:|----------:|----------:|-------:|------:|------:|----------:|
| GetValueUsingSubstring | 15.559 ns | 0.2645 ns | 0.7330 ns | 15.174 ns | 0.0191 |     - |     - |      40 B |
|      GetValueUsingSpan |  4.526 ns | 0.1095 ns | 0.3034 ns |  4.334 ns |      - |     - |     - |         - |
