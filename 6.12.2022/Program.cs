using System.Data;

internal class Program
{
    public static void Main()
    {
        Heap sterta = new Heap();
        sterta.Instert(4);
        sterta.Instert(5);
        sterta.Instert(1);
        sterta.Instert(100);
        sterta.Instert(7);

        if(sterta.Remove() == 100)
            Console.WriteLine("OK");
        
        PriorityQueue<int, int> q = new PriorityQueue<int, int>(new IntComparer());
        q.Enqueue(4, 4);
        q.Enqueue(5, 5);
        q.Enqueue(1, 1);
        q.Enqueue(100, 100);
        q.Enqueue(7, 7);

        Console.WriteLine(q.Dequeue());

        PriorityQueue<string, string> students = new PriorityQueue<string, string>();
        students.Enqueue("Rafał", "Rafał");
        students.Enqueue("Adam", "Adam");
        students.Enqueue("Ewa", "Ewa");
        students.Enqueue("Damian", "Damian");
        Console.WriteLine(students.Dequeue());
        Console.WriteLine(students.Dequeue());
        //Zdefiniowaną kolejkę priorytetową z prorytetem leksykongraficzny, tzw. imiona w porzadku alfabetycznym


    }

    class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return -x.CompareTo(y);
        }
    }

    class Heap
    {
        private int[] tab = new int[100];
        private int last = -1;

        int Left(int i) => 2 * i + 1;
        int Right(int i) => 2 * i + 2;
        int Parent(int i) => (i-1)/2;

        public bool Instert(int value)
        {
            if (IsFull())
                return false;

            tab[++last] = value;
            RebuildUp(last);
            return true;
        }

        void RebuildUp(int i)
        {
            int value = tab[i];
            while (i > 0)
            {
                int parentValue = tab[Parent(i)];
                if (value > parentValue)
                {
                    (tab[i], tab[Parent(i)]) = (tab[Parent(i)], tab[i]);
                    i = Parent(i);
                }
                else
                    break;
            }
        }

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            int result = tab[0];
            //przebudowa drzewa
            return result;
        }

        public bool IsFull() => last >= tab.Length - 1;
        public bool IsEmpty() => last < 0;


    }

}