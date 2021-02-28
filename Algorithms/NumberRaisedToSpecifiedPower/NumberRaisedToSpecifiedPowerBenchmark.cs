using System;
using BenchmarkDotNet.Attributes;

namespace Algorithms.NumberRaisedToSpecifiedPower
{
    // |    Method |        Mean |     Error |    StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
    // |---------- |------------:|----------:|----------:|------:|------:|------:|----------:|
    // | SlowSolve | 126.9477 ns | 1.6967 ns | 1.5870 ns |     - |     - |     - |         - |
    // | FastSolve |  82.0894 ns | 1.6355 ns | 2.3455 ns |     - |     - |     - |         - |
    // |  Math.Pow |   0.1709 ns | 0.0292 ns | 0.0814 ns |     - |     - |     - |         - |
    [MemoryDiagnoser]
    public class NumberRaisedToSpecifiedPowerBenchmark
    {
        [Benchmark(Description = "SlowSolve")]
        public void MyMathSlowPow()
        {
            NumberRaisedToSpecifiedPowerSolver.SlowSolve(2, 32);
        }
        
        [Benchmark(Description = "FastSolve")]
        public void MyMathFastPow()
        {
            NumberRaisedToSpecifiedPowerSolver.FastSolve(2, 32);
        }
        
        [Benchmark(Description = "Math.Pow")]
        public void MathPow()
        {
            // Math.Pow implementation
            //     [MethodImpl(MethodImplOptions.InternalCall), SecuritySafeCritical]
            //     public static extern double Pow(double x, double y);
            // Method is actually implemented in the CLR, written in C++. The just-in-time compiler consults a table with internally implemented methods and compiles the call to the C++ function directly.
            
            Math.Pow(2, 32);
        }
    }
}