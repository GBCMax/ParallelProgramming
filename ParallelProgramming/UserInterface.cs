using ParallelProgramming_BusinessLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ParallelProgramming
{
    public class UserInterface
    {
        readonly RandomNumberArrayGenerator randomNumberArrayGenerator = new RandomNumberArrayGenerator();
        readonly SequentialAlgorithmImplementation sequentialAlgorithmImplementation = new SequentialAlgorithmImplementation();
        readonly ParallelAlgorithmWithAnError implementationOfAParallelAlgorithmWithAnError = new ParallelAlgorithmWithAnError();
        readonly ParallelAlgorithmThreadLocal parallelAlgorithmThreadLocal = new ParallelAlgorithmThreadLocal();
        readonly SortCheck sortCheck = new SortCheck();
        private long[] mas, mas1, mas2;
        public void GenerateRandomNumberArray()
        {
            mas = randomNumberArrayGenerator.GenerateRandomNumberArray();
            mas1 = (long[])mas.Clone();
            mas2 = (long[])mas.Clone();
            Console.WriteLine("Сгенерированный рандомный массив:");
            PrintArray(mas);
            Console.WriteLine();
        }
        private void PrintArray(long[] massive)
        {
            Console.WriteLine("Начало:");
            for (int i = 0; i < massive.Length; i++)
            {
                Console.Write(massive[i].ToString() + " ");
            }
            Console.WriteLine("Конец.");
        }
        public void SequentialAlgorithm()
        {
            Stopwatch stopwatchSequentialAlgorithm = new Stopwatch();
            stopwatchSequentialAlgorithm.Start();
            long[] masForSequentialAlgorithm = sequentialAlgorithmImplementation.QuickSort(mas);
            stopwatchSequentialAlgorithm.Stop();
            Console.WriteLine("Время выполнения:");
            Console.WriteLine(stopwatchSequentialAlgorithm.Elapsed.TotalSeconds + " секунд");
            CheckSortedArray(masForSequentialAlgorithm);
            Console.WriteLine("Последовательная сортировка:");
            //PrintArray(masForSequentialAlgorithm);
            Console.WriteLine();
        }
        public void ParallelAlgorithmWithError()
        {
            Stopwatch stopwatchParallelAlgorithmWithError = new Stopwatch();
            stopwatchParallelAlgorithmWithError.Start();
            long[] masForAlgorithmWithError = implementationOfAParallelAlgorithmWithAnError.QuickSort(mas1);
            stopwatchParallelAlgorithmWithError.Stop();
            Console.WriteLine("Время выполнения:");
            Console.WriteLine(stopwatchParallelAlgorithmWithError.Elapsed.TotalSeconds + " секунд");
            CheckSortedArray(masForAlgorithmWithError);
            Console.WriteLine("Параллельная сортировка с ошибкой:");
            //PrintArray(masForAlgorithmWithError);
            Console.WriteLine();
        }
        public void ParallelAlgorithmThreadLocal()
        {
            Stopwatch stopwatchParallelAlgorithmThreadLocal = new Stopwatch();
            stopwatchParallelAlgorithmThreadLocal.Start();
            long[] masForAlgorithmThreadLocal = parallelAlgorithmThreadLocal.QuickSort(mas2);
            stopwatchParallelAlgorithmThreadLocal.Stop();
            Console.WriteLine("Время выполнения:");
            Console.WriteLine(stopwatchParallelAlgorithmThreadLocal.Elapsed.TotalSeconds + " секунд");
            CheckSortedArray(masForAlgorithmThreadLocal);
            Console.WriteLine("Параллельная сортировка через локальную переменную:");
            //PrintArray(masForAlgorithmThreadLocal);
            Console.WriteLine();
        }
        private void CheckSortedArray(long[] sortedMas)
        {
            if(sortCheck.SortChecking(sortedMas))
            {
                Console.WriteLine("Массив отсортирован!");
            }
            else
            {
                Console.WriteLine("Массив не отсортирован!");
            }
        }
    }
}
