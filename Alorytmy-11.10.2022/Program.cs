using System.Buffers;
using System.Collections.Generic;
using System.Globalization;

namespace AlgorytmyLab1
{
    public class Lab1
    {
        public static void Main(string[] args)
        {
            int[] arr1 = { 23, 1, 56, 345, 1, 5, 67, 11 };
            int index = findTwoDigitMin(arr1);
            if(index == 7)
                Console.WriteLine("OK");
            else
                Console.WriteLine("Fail");

            int[] arr2 = { };
            index= findTwoDigitMin(arr2);
            if (index == -1)
                Console.WriteLine("OK");
            else
                Console.WriteLine("Fail");

            int[] arr3 = {1, 3, 4, 123, 1234 };
            index = findTwoDigitMin(arr3);
            if (index == -1)
                Console.WriteLine("OK");
            else
                Console.WriteLine("Fail");
        }
        
        /// <summary>
        /// Funkcja szuka indexu najmniejszej liczby dwucyfrowej
        /// </summary>
        /// <param name="arr">tablica liczb dodatnich</param>
        /// <returns>index znalezionej liczby lub -1, gdy brak takiej liczby</returns>
        public static int findTwoDigitMin(int[] arr)
        {
            int min = 0;
            if (arr.Length == 0)
                return -1;

            for(int i=0;i<arr.Length; i++)
            {
                if (arr[i] >= 10 && arr[i] <= 99)
                    break;
                return -1;
            }

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 10 && arr[i] <= 99)
                {
                    min = arr[i];
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] >= 10 && arr[j] <= 99)
                        {
                            if (arr[j] <= min)
                                min = arr[j];
                        }
                    }
                }
            } 
            return Array.IndexOf(arr, min);
        }

        public static int findTwoDigitMinV2(int[] arr)
        {
            List<int> twoDigits = new List<int>();
            
            if (arr.Length == 0)
                return -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 10 && arr[i] <= 99)
                    twoDigits.Add(arr[i]);
            }

            if (twoDigits.Count == 0)
                return -1;

            return Array.IndexOf(arr, twoDigits.Min());
        }
    }
}