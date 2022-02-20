``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1526 (20H2/October2020Update)
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4470.0), X86 LegacyJIT  [AttachedDebugger]
  DefaultJob : .NET Framework 4.8 (4.8.4470.0), X86 LegacyJIT


```
|                 Method |     Mean |    Error |   StdDev | Rank |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|----------------------- |---------:|---------:|---------:|-----:|---------:|---------:|---------:|----------:|
| IntArrayCollectionTest | 11.53 ms | 0.034 ms | 0.031 ms |    1 | 390.6250 | 390.6250 | 390.6250 |      1 MB |
|  IntListCollectionTest | 12.09 ms | 0.082 ms | 0.072 ms |    2 | 562.5000 | 562.5000 | 562.5000 |      2 MB |
