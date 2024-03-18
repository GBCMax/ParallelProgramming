using System;
using System.Collections.Generic;
using System.Text;

namespace ParallelProgramming_BusinessLogic
{
    public class RandomNumberArrayGenerator
    {
        public long[] GenerateRandomNumberArray()
        {
            Random rnd = new Random();
            //int k = rnd.Next(1, 10000);
            int k =1000000;
            long[] mas = new long[k];
            for(int i = 0; i < k; i++)
            {
                mas[i] = rnd.Next(-1000, 1000);
            }
            return mas;
        }
    }
}
