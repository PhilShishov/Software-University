
namespace P07_NxNMatrix
{
    using System;

    class NxNMatrix
    {
        static void Main()
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            PrintMatrix(sizeMatrix);
        }

        public static int PrintMatrix(int sizeMatrix)
        {
            for (int row = 0; row < sizeMatrix; row++)
            {
                for (int col = 1; col < sizeMatrix; col++)
                {
                    Console.Write(sizeMatrix + " ");
                }
                Console.WriteLine(sizeMatrix);
            }
            return sizeMatrix;
        }
    }
}
