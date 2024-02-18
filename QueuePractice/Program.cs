using System;

public class Queue
{
    private int[] array;
    private int front;
    private int rear;
    private int capacity;
    private int count;

    public Queue(int size)
    {
        capacity = size;
        array = new int[size];
        front = 0;
        rear = -1;
        count = 0;
    }

    public void Enqueue(int item)
    {
        if (count == capacity)
        {
            Console.WriteLine("Queue is full. Cannot enqueue.");
            return;
        }

        rear = (rear + 1) % capacity;
        array[rear] = item;
        count++;
    }

    public int Dequeue()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty. Cannot dequeue.");
            return -1; // Return a default value, you might want to throw an exception instead.
        }

        int dequeuedItem = array[front];
        front = (front + 1) % capacity;
        count--;
        return dequeuedItem;
    }

    public int Peek()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty. Cannot peek.");
            return -1; // Return a default value, you might want to throw an exception instead.
        }

        return array[front];
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public bool IsFull()
    {
        return count == capacity;
    }

    public int Size()
    {
        return count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Queue queue = new Queue(5);

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Enqueue(40);
        queue.Enqueue(50);

        Console.WriteLine("Dequeued item: " + queue.Dequeue());
        Console.WriteLine("Peek item: " + queue.Peek());

        queue.Enqueue(60);

        while (!queue.IsEmpty())
        {
            Console.WriteLine("Dequeued item: " + queue.Dequeue());
        }
    }
}