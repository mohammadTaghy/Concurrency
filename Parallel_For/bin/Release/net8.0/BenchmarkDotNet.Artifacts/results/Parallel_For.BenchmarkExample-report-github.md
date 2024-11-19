```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2


```
| Method             | Mean       | Error   | StdDev  |
|------------------- |-----------:|--------:|--------:|
| UseParallelForeach |   290.9 ms | 5.67 ms | 5.57 ms |
| UseParallelFor     |   283.6 ms | 5.56 ms | 9.89 ms |
| UselFor            | 1,236.1 ms | 9.26 ms | 8.66 ms |
