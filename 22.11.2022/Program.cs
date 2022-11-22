class Program
{
    static void Main(string[] args)
    {
        LinkedStack<string> stack = new LinkedStack<string>();
        
        if (stack.IsEmpty())
            Console.WriteLine("Passed");
        else
            Console.WriteLine("Fail");
        
        stack.Push("Adam");
        stack.Push("Marcin");
        stack.Push("Kamil");

        if (!stack.IsEmpty())
            Console.WriteLine("Passed");
        else
            Console.WriteLine("Fail");

        if(stack.Pop() == "Kamil")
            Console.WriteLine("Passed");
        else
            Console.WriteLine("Fail");

        stack.Pop();
        stack.Pop();

        if (stack.IsEmpty())
            Console.WriteLine("Passed");
        else
            Console.WriteLine("Fail");

        Console.WriteLine();

        LinkedQueue<int> q = new LinkedQueue<int>();
        Console.WriteLine(q.IsEmpty());
        q.Enqueue(1);
        q.Enqueue(3);
        q.Enqueue(7);
        Console.WriteLine(!q.IsEmpty());
        Console.WriteLine(q.Dequeue() == 1);
        Console.WriteLine(q.Dequeue() == 3);
        Console.WriteLine(q.Dequeue() == 7);
        Console.WriteLine(q.IsEmpty());
    }

}

internal class Node<T>
{
    public T Value { get; set; }

    public Node<T> Next { get; set; }
}

public class LinkedStack<T>
{
    private Node<T> head;

    public void Push(T item)
    {
        if (IsEmpty())
            head = new Node<T>() { Value = item, Next = null };
        else
        {
            var node = new Node<T>() { Value = item, Next = head };
            head = node;
        }
    }

    public T Pop()
    {
        if (!IsEmpty())
        {
            T result = head.Value;
            head = head.Next;
            return result;
        }
        else
            throw new InvalidOperationException();
    }

    public bool IsEmpty() => head == null;

}

public class LinkedQueue<T>
{
    private Node<T> head;
    private Node<T> tail;

    public void Enqueue(T item)
    {
        if (IsEmpty())
        {
            head = new Node<T>() { Value = item, Next = null };
            tail = head;
        }
        else
        {
            var node = new Node<T>() { Value = item, Next = null };
            tail.Next = node;
            tail = node;
        }
    }

    public T Dequeue()
    {
        if (!IsEmpty())
        {
            T result = head.Value;
            head = head.Next;
            return result;
        }
        else
            throw new InvalidOperationException();
    }

    public bool IsEmpty() => head == null;
}