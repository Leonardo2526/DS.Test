``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1526 (20H2/October2020Update)
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4470.0), X86 LegacyJIT  [AttachedDebugger]
  DefaultJob : .NET Framework 4.8 (4.8.4470.0), X86 LegacyJIT


```
|                  Method |     Mean |   Error |  StdDev | Rank | Allocated |
|------------------------ |---------:|--------:|--------:|-----:|----------:|
| BenchmarkCollectionTest | 124.7 ms | 0.73 ms | 0.65 ms |    1 |      8 MB |
