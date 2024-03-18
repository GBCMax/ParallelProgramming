using System;

namespace ParallelProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            userInterface.GenerateRandomNumberArray();
            userInterface.SequentialAlgorithm();
            userInterface.ParallelAlgorithmWithError();
            userInterface.ParallelAlgorithmThreadLocal();
        }
    }
}
