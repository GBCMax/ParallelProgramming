using Newtonsoft.Json.Serialization;
using ParallelProgramming_BusinessLogic;
using System;
using Xunit;

namespace ParallelProgramming_Tests
{
    public class SortedArrayTest
    {
        [Fact]
        public void CheckingSortingThroughASequentialAlgorithm()
        {
            for (int i = 0; i < 100; i++)
            {
                //arrange
                RandomNumberArrayGenerator randomNumberArrayGenerator = new RandomNumberArrayGenerator();
                SequentialAlgorithmImplementation sequentialAlgorithmImplementation = new SequentialAlgorithmImplementation();
                SortCheck sortCheck = new SortCheck();
                long[] mas = randomNumberArrayGenerator.GenerateRandomNumberArray();
                //act
                mas = sequentialAlgorithmImplementation.QuickSort(mas);
                //assert
                Assert.True(sortCheck.SortChecking(mas));
            }
        }
        [Fact]
        public void CheckingSortingThroughAnAlgorithmWithAnError()
        {
            for (int i = 0; i < 100; i++)
            {
                //arrange
                RandomNumberArrayGenerator randomNumberArrayGenerator = new RandomNumberArrayGenerator();
                ParallelAlgorithmWithAnError parallelAlgorithmWithAnError = new ParallelAlgorithmWithAnError();
                SortCheck sortCheck = new SortCheck();
                long[] mas = randomNumberArrayGenerator.GenerateRandomNumberArray();
                //act
                mas = parallelAlgorithmWithAnError.QuickSort(mas);
                //assert
                Assert.False(sortCheck.SortChecking(mas));
            }
        }
        [Fact]
        public void CheckingSortingThroughAnAlgorithmThreadLocal()
        {
            for (int i = 0; i < 100; i++)
            {
                //arrange
                RandomNumberArrayGenerator randomNumberArrayGenerator = new RandomNumberArrayGenerator();
                ParallelAlgorithmThreadLocal parallelAlgorithmThreadLocal = new ParallelAlgorithmThreadLocal();
                SortCheck sortCheck = new SortCheck();
                long[] mas = randomNumberArrayGenerator.GenerateRandomNumberArray();
                //act
                mas = parallelAlgorithmThreadLocal.QuickSort(mas);
                //assert
                Assert.True(sortCheck.SortChecking(mas));
            }
        }
    }
}
