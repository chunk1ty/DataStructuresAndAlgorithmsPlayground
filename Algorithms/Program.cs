﻿using Algorithms.MatchingBrackets;
using BenchmarkDotNet.Running;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
             BenchmarkRunner.Run(typeof(Program).Assembly);
            // MatchingBracketPlayground.Play();
            
        }
    }
}