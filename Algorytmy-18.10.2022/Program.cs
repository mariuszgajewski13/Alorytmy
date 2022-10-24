public class App
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Repeat("#", 5));
        Console.WriteLine(RepeatRec("#", 4));

        int[] waluty = {1, 2, 5 };
        Console.WriteLine(String.Join(',', Reminder(9, waluty)));
        Console.WriteLine(Fib(4));
        Console.WriteLine(QuickFib(44));

        int[] tab = { 1, 4, 3, 6 };
        BubbleSort(tab);
        Console.WriteLine(String.Join(',', tab));

        double[] v = { 12, 1.4, 2 };
        Console.WriteLine(SumRec(v, 0, v.Length));

        long[] mem = new long[50];
        Console.WriteLine(FibMemArr(44, mem));
    }

    public static string Repeat(string symbol, int n)
    {
        string result = "";
        for (int i = 0; i < n; i++)
            result += symbol;
        return result;
    }

    public static string RepeatRec(string symbol, int n)
    {
        if (n == 0) return "";
        return RepeatRec(symbol, n - 1) + symbol;
    }

    //Zaimplementuj postać rekurencyjną funkcję obliczającej sumę elementów tablicy
    public static double SumRec(double[] arr, int start, int end)
    {
        if (end <= 0)
            return 0;
        return (SumRec(arr, 0, end - 1) + arr[end - 1]);
    }

    //Przerobić na dowolny system monetarny np.1, 2, 5, 10, 20, .. //pętla -- DONE
    public static int[] Reminder(int amount, int[] system)
    {
        int[] result = new int[system.Length];
        for(int i = system.Length-1; i >= 0; i--)
        {
            if (amount / system[i] > 0)
            {
                result[i] = amount / system[i];
                amount -= result[i] * system[i];
            }
        }
        return result;
    }

    public static long Fib(int n)
    {
        if (n < 2) return 1;
        return Fib(n-1)+Fib(n-2);
    }

    //stwórz własną implementację z tablicą do memoizacji, ale tylko dla n<50
    private static long FibMem(int n, Dictionary<int, long> mem)
    {
        if (n < 2) return 1;

        if (!mem.ContainsKey(n - 1)) 
            mem[n - 1] = FibMem(n - 1, mem);
        if (!mem.ContainsKey(n - 2))
            mem[n - 2] = FibMem(n - 2, mem);

        return mem[n - 1] + mem[n - 2];
    }

    public static long FibMemArr(int n, long[] mem)
    {
        if (n < 2) return 1;

        if (!mem.Contains(n - 1))
            mem[n - 1] = FibMemArr(n - 1, mem);
        if (!mem.Contains(n - 2))
            mem[n - 2] = FibMemArr(n - 2, mem);

        return mem[n - 1] + mem[n - 2];
    }

    public static long QuickFib(int n)
    {
        if (n > 50 || n < 0) throw new ArgumentException("Działa tylko dla n < 50 i większego od 0");

        return FibMem(n, new Dictionary<int, long>());
    }

    public static void BubbleSort(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
            for(int j = arr.Length-1; j > i; j--)
                if (arr[j] < arr[j - 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j-1];
                    arr[j] = temp;
                }
                
    }
}