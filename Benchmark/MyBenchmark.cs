using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using CollectionTest;
using CollectionTest.Collections;

namespace Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class MyBenchmark
    {
        //[Benchmark]
        //public void BenchmarkCollectionTest()
        //{
        //    CollectionTest.Program.Run();
        //}

        [Benchmark]
        public void IntArrayCollectionTest()
        {
            IntArrayCollection intArrayCollection = new IntArrayCollection();
            List<int> list = intArrayCollection.GetValues();
            //Console.WriteLine(list.Count);
        }

        [Benchmark]
        public void IntListCollectionTest()
        {
            IntListCollection intListCollection = new IntListCollection();
            List<int> list = intListCollection.GetValues();
            //Console.WriteLine(list.Count);
        }


    }
}
