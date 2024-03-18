using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming_BusinessLogic
{
    public class ParallelAlgorithmThreadLocal//че за хрень тут происходит
    {
        /// <summary>
        /// метод для обмена элементов массива
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Swap(ref long x, ref long y)
        {
            var t = x;
            x = y;
            y = t;
        }

        /// <summary>
        /// метод возвращающий индекс опорного элемента
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="minIndex"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        private long Partition(long[] mas, long minIndex, long maxIndex)//убрать распараллеливание
        {
            long pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (mas[i] < mas[maxIndex])
                {
                    pivot++;
                    Swap(ref mas[pivot], ref mas[i]);
                }
            }

            pivot++;
            Swap(ref mas[pivot], ref mas[maxIndex]);
            return pivot;
        }

        /// <summary>
        /// быстрая сортировка
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="minIndex"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        private long[] QuickSort(long[] mas, long minIndex, long maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return mas;
            }

            long pivotIndex = Partition(mas, minIndex, maxIndex);
            if (((pivotIndex - 1) - minIndex > 1000) && (maxIndex - (pivotIndex + 1) > 1000))
            {
                Parallel.Invoke
                    (
                    () => QuickSort(mas, minIndex, pivotIndex - 1),
                    () => QuickSort(mas, pivotIndex + 1, maxIndex)
                    );
            }
            else
            {
                QuickSort(mas, minIndex, pivotIndex - 1);
                QuickSort(mas, pivotIndex + 1, maxIndex);
            }

            return mas;
        }

        public long[] QuickSort(long[] mas)
        {
            return QuickSort(mas, 0, mas.Length - 1);
        }
    }
}
