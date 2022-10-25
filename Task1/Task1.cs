
using System.Xml.Linq;
using System;

namespace task_1
{
    public class Task1
    {
        public static bool IsInArray(int[] arr, int value)
        {
            return IsInArrayRecursive(arr, 0, arr.Length, value);
        }
        /**
         * REKURENCJA
         */
        //Zaimplementuj funkcję, która strategią dziel i zwyciężaj zwróci prawdę jeśli w tablicy
        //'arr' znajduje się wartość parametru 'value'.
        //Przykład
        //int[] arr = { 1, 2, 6 ,9 ,4, 3};
        //Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 0);          //false
        //Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 6);          //true
        //Console.WriteLine(IsInArrayRecursive(new int[]{}, 0, arr.Length - 1, 5);          //false
        public static bool IsInArrayRecursive(int[] arr, int left, int right, int value)
        {
            if (right <= 0 || arr.Length == 0)
            {
                return false;
            }
            else
            {
                if (arr[right] == value)
                {
                    return true;
                }
                else
                    return IsInArrayRecursive(arr, left, right/2, value);
            }
        }


        //Zdefiniuj funkcję rekurecyjną, która oblicza sumę elementów tablicy podzielnych przez 3
        //Nie można używać instrukcji iteracyjnych!!! Wartość funkcja dla pustej tablicy wynosi 0.
        //Można założyć, że tablica nie będzie równa null. Zdefiniuj funkcję pomocniczą która będzie wywoływana
        //rekurencyjnie wewnątrz SumMod3.
        public static long SumMod3(int[] arr)
        {
            return SumMod3Recursive(arr, arr.Length-1);
        }

        private static long SumMod3Recursive(int[] arr, int length)
        {
            if (arr.Length == 0 || length < 0)
                return 0;
            if (arr[length] % 3 == 0)
                return SumMod3Recursive(arr, length - 1) + arr[length];
            else
                return SumMod3Recursive(arr, length - 1);
        }

        //Zdefiniuj funkcję rekurecyjną, która oblicza silnię liczby n
        //Parametr result powinien zawierac wynik 
        public static long Factorial(int n)
        {
            if(n != 0)
                return n * Factorial(n - 1);
            return 1;
        }

        /**
         * ALGORYTMY I ZŁOŻONOŚĆ
         */
        //Zdefiniuj funkcję, która zwróci indeks liczby, która jest równa sumie pozostałych elementów tablicy
        //Przykład
        //int[] arr = {1, 3, 2, 8, 2};
        //int index = IndexOfSumOfOthers(arr);
        //funkcja w `index` powinna zwrócić 3, gdyż pod tym indeksem jest 8 równe sumie 1 + 3 + 2 + 2.
        //Jeśli w tablicy nie ma takiej liczby lub tablica jest pusta to funkcja pownna zwrócić -1.
        public static int IndexOfSumOfOthersRec(int[] arr, int lenght)
        {
            int sum = ArraySumRec(arr, arr.Length-1);
            
            if (arr[lenght] == sum - arr[lenght])
                return lenght;
            if(lenght == 0 || arr.Length==0)
                return -1;
            
            return IndexOfSumOfOthersRec(arr, lenght-1);
        }
        public static int ArraySumRec(int[] arr, int length)
        {
            if (length == 0 || arr.Length == 0)
                return 1;
            return ArraySumRec(arr, length - 1) + arr[length];
        }

        public static int IndexOfSumOfOthers(int[] arr)
        {
            int sum = 0;
            for(int i=0; i<arr.Length; i++)
            sum+=arr[i];

            for (int i = 0; i < arr.Length; i++)
               if (arr[i] == sum - arr[i])
                  return i;
            
            return -1;

        }


        public static void Main(string[] args)
        {
            //1
            int[] arr = { 1, 2, 6 ,9 ,4, 3};
            Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 0));          //false
            Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 6));          //true
            Console.WriteLine(IsInArrayRecursive(new int[]{}, 0, arr.Length - 1, 5));          //false

            //2
            Console.WriteLine();
            int[] arr1 = { 1, 3, 45, 18, 10, 6 };
            Console.WriteLine(SumMod3(arr1));

            //3
            Console.WriteLine();
            Console.WriteLine(Factorial(4));

            //4
            Console.WriteLine();
            int[] arr2 = {1, 3, 2, 8, 2};
            //rekurencyjnie
            int index = IndexOfSumOfOthersRec(arr2, arr2.Length-1);
            Console.WriteLine($"Rekurencyjnie: {index}");

            //iteracyjnie
            index = IndexOfSumOfOthers(arr2);
            Console.WriteLine($"Iteracyjnie: {index}");
        }
    }
}
