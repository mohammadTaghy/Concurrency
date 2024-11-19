```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2


```
| Method          | Mean         | Error      | StdDev     |
|---------------- |-------------:|-----------:|-----------:|
| ParallelSum     |  5,958.65 ns | 118.185 ns | 227.702 ns |
| ParallelLinqSum | 15,106.69 ns |  81.649 ns |  72.380 ns |
| ParallelForSum  |     27.68 ns |   0.226 ns |   0.211 ns |
