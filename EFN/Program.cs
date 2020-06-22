using System;

namespace EFN
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[1000000];
            int i = 2;
            arr[i - 2] = 1;
            arr[i - 1] = 2;
            int n = arr[i];
            long sum = 0;

            for(i=2; arr[i-1]<=4000000; i++)
            {
                arr[i] = arr[(i - 1)] + arr[(i - 2)];
            }
            for(int f = 0; f<=arr.Length -1; f++)
            {
                if (arr[f] % 2 == 0)
                    sum += arr[f];
            }
            Console.WriteLine(sum); //answer: 4613732
        }
    }
}
