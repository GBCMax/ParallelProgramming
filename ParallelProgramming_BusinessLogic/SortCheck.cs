using System;
using System.Collections.Generic;
using System.Text;

namespace ParallelProgramming_BusinessLogic
{
    public class SortCheck
    {
        public bool SortChecking(long[] mas)
        {
            for(int i = 0; i < mas.Length - 1; i++)
            {
                if (mas[i] > mas[i+1])
                    return false;
            }
            return true;
        }
    }
}
