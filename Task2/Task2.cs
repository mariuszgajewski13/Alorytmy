using System.Collections.Generic;

namespace task_2
{
    public class Task2
    {
        /// <summary>
        /// W tablicy gold znajdują się dodatnie liczby reprezetujące złoto. 
        /// Górnik zbiera złoto z komórek, zaczyna od dowolnej komórki górnego wiersza (n) i 
        /// i porusza się w dół do dolnego wiersza (0). Może przejść tylko do komórki po prawej lub
        /// do komórki na przekątnej: w prawo w górę lub w prawo w dół, ale ostatecznie musi znaleźć się w dolnym wierszu (0).
        /// Zaimplementuj algorytm, który wyznaczy największa liczbę złota zebraną przez górnika.
        /// </summary>
        /// <param name="gold">Dwuwymiarowa tablica liczb dodatnich</param>
        /// <returns>Liczba zebranego złota</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <summary>
        // Przykłady
        // Wejście: gold[][] = {{1, 3, 3},
        //     {2, 1, 4},
        //     {0, 6, 4}};
        // Wyjście: 12
        // {(1,0)->(2,1)->(1,2)}
        //
        // Wejście: gold[][] = { {1, 3, 1, 5},
        //     {2, 2, 4, 1},
        //     {5, 0, 2, 3},
        //     {0, 6, 1, 2}};
        // Wyjście: 16
        //     (2,0) -> (1,1) -> (1,2) -> (0,3) LUB
        //     (2,0) -> (3,1) -> (2,2) -> (2,3)
        //
        // Wejście : gold[][] = {{10, 33, 13, 15},
        //     {22, 21, 04, 1},
        //     {5, 0, 2, 3},
        //     {0, 6, 14, 2}};
        // Wyjście: 83 
        // Uwaga!!!
        // Najłatwiej zrealizować algorytm w postaci rekurencyjnej.
        // Memoizacją zmniejszy złożoność czasową.
        static public int CollectGold(int[,] gold)
        {
            int max = gold[0, 0];
            int[] index = new int[2];
            List<int> maxNeighbours = new List<int>();
            List<int> neighbours = new List<int>();
            for (int j = 0; j < gold.GetLength(1); j++)
            {
                if (gold[0, j] > max)
                {
                    max = gold[0, j];
                    index[0] = 0;
                    index[1] = j;
                }
            }
            for (int i = 0; i < gold.GetLength(0); i++)
            {

                if (index[1] < gold.GetLength(1) - 1 && i < gold.GetLength(0) - 1 && i > 0)
                {
                    neighbours.Add(gold[i, index[1] + 1]);
                    neighbours.Add(gold[i - 1, index[1]+1]);
                    neighbours.Add(gold[i + 1, index[1] + 1]);
                }
                else if(index[1] < gold.GetLength(1) - 1 && i < gold.GetLength(0) - 1)
                {
                    neighbours.Add(gold[i, index[1] + 1]);
                    neighbours.Add(gold[i + 1, index[1] + 1]);
                }
                else if(index[0] >= gold.GetLength(0) - 1)
                {
                    neighbours.Add(gold[i, index[1] + 1]);
                }
                else
                {
                    neighbours.Add(gold[i, index[1]]);
                }

                index[0] = i;
                maxNeighbours.Add(neighbours.Max());
                neighbours.Clear();
            }


            return max + maxNeighbours.Sum();
        }

        /// <summary>
        /// Zaimplementuj funkcję, która wyznaczy najmniejszy ilocz wybranych liczb z tablicy arr.
        /// Przykład 1
        /// Wejscie: int[] arr = [0, 2, 4, 6]
        /// Wyjście: 0
        /// 
        /// Przykład 2
        /// Wejscie: int[] arr = [-2, -1, 10, 10_000, -1]
        /// Wyjście: -200_000
        /// 
        /// Przykład 3
        /// Wejscie: int[] arr = [2, -1, -10, 10_000, 1]
        /// Wyjście: 1
        /// </summary>
        /// <param name="arr">tablica liczb całkowitych</param>
        /// <returns>najmniejszy iloczyn tablicy wejściowej arr</returns>
        static public int MinProduct(int[] arr)
        {
            List<int> minIloczyn = new List<int>();

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    minIloczyn.Add(arr[i] * arr[j]);
                }
            }
            return minIloczyn.Min();

        }

        public static void Main(string[] args)
        {
            //Zadanie 1
            int[,] gold1 = {{1, 3, 3},
                            {2, 1, 4},
                            {0, 6, 4}};

            int[,] gold2 = {{1, 3, 1, 5},
                            {2, 2, 4, 1},
                            {5, 0, 2, 3},
                            {0, 6, 1, 2}};
            
            int[,] gold3 =  {{10, 33, 13, 15},
                             {22, 21, 04, 1},
                             {5, 0, 2, 3},
                             {0, 6, 14, 2}};
            Console.WriteLine($"Zadanie 1: {CollectGold(gold1)}, {CollectGold(gold2)}, {CollectGold(gold3)}");

            //Zadanie 2
            int[] arr1 = { 0, 2, 4, 6 };
            int[] arr2 = { -2, -1, 10, 10_000, -1 };
            int[] arr3 = { 2, -1, -10, 10_000, 1 };
            Console.WriteLine($"Zadanie 2: {MinProduct(arr1)}, {MinProduct(arr2)}, {MinProduct(arr3)} ");
        }
    }
}
