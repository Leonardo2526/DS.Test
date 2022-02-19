using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using CollectionTest;

namespace Benchmark
{

    [MemoryDiagnoser]
    [RankColumn]
    public class MyBenchmark
    {
      

        [Benchmark] 
        public void BenchmarkCollectionTest() 
        {
            CollectionTest.Program.Run();
        }

        //[Benchmark]
        //public void TestBenchmark2()
        //{
        //    //test.Test2();
        //}
    }
}
