
namespace P08_Snowballs
{
    using System;
    using System.Numerics;

    class Snowballs
    {
        static void Main(string[] args)
        {
            int snowballCount = int.Parse(Console.ReadLine());
            BigInteger snowballValue = 0;
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;


            for (int i = 0; i < snowballCount; i++)
            {
                int currentsnowballSnow = int.Parse(Console.ReadLine());
                int currentsnowballTime = int.Parse(Console.ReadLine());
                int currentsnowballQuality = int.Parse(Console.ReadLine());

                BigInteger currentsnowballValue = BigInteger.Pow((currentsnowballSnow / currentsnowballTime), currentsnowballQuality);
                if (currentsnowballValue > snowballValue)
                {
                    snowballValue = currentsnowballValue;
                    snowballSnow = currentsnowballSnow;
                    snowballTime = currentsnowballTime;
                    snowballQuality = currentsnowballQuality;
                }
            }
            Console.WriteLine($"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})");

        }
    }
}
