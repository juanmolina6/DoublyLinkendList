using System;
using System.Collections.Generic;
using System.Linq;

namespace DoubleList;

public class DoubleLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? head;
    private DoubleNode<T>? tail;

    public void AddInOrder(T data)
    {
        var newNode = new DoubleNode<T>(data);

        if (head == null)
        {
            head = tail = newNode;
            return;
        }

        DoubleNode<T>? current = head;
        while (current != null && current.Data!.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        if (current == head)
        {
            newNode.Next = head;
            head!.Prev = newNode;
            head = newNode;
        }
        else if (current == null)
        {
            tail!.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
        else
        {
            newNode.Prev = current.Prev;
            newNode.Next = current;
            current.Prev!.Next = newNode;
            current.Prev = newNode;
        }
    }

    public void ShowForward()
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        var current = head;
        while (current != null)
        {
            Console.Write($"{current.Data}");
            if (current.Next != null)
                Console.Write(" <=> ");
            current = current.Next;
        }
        Console.WriteLine();    
    }

    public void ShowBackward()
    {
        if (tail == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        var current = tail;
        while (current != null)
        {
            Console.Write($"{current.Data}");
            if (current.Prev != null)
                Console.Write(" <=> ");
            current = current.Prev;
        }
        Console.WriteLine();

    }
    public void SortDescending()
    {
        if (head == null || head.Next == null)
            return;

        List<T> tempList = new();
        var current = head;
        while (current != null)
        {
            tempList.Add(current.Data);
            current = current.Next;
        }

        tempList.Sort((a, b) => b.CompareTo(a)); 

        ClearList();

        foreach (var item in tempList)
        {
            var newNode = new DoubleNode<T>(item);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        Console.WriteLine("List sorted in descending order.");
    }
    public void ShowModes()
    {
        Dictionary<T, int> counts = new();
        var current = head;
        while (current != null)
        {
            if (current.Data != null)
            {
                if (!counts.ContainsKey(current.Data))
                    counts[current.Data] = 0;
                counts[current.Data]++;
            }
            current = current.Next;
        }

        if (counts.Count == 0)
        {
            Console.WriteLine("Empty list");
            return;
        }

        int max = counts.Values.Max();
        var modes = counts.Where(p => p.Value == max).Select(p => p.Key);
        Console.WriteLine("Mode(s): " + string.Join(", ", modes));
    }

    public void ShowGraph()
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Dictionary<T, int> counts = new();
        var current = head;
        while (current != null)
        {
            if (current.Data != null)
            {
                if (!counts.ContainsKey(current.Data))
                    counts[current.Data] = 0;
                counts[current.Data]++;
            }
            current = current.Next;
        }

        foreach (var pair in counts)
        {
            Console.WriteLine($"{pair.Key} {new string('*', pair.Value)}");
        }
    }

    public void Exists(T value)
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        var current = head;
        int count = 0;

        while (current != null)
        {
            if (current.Data!.CompareTo(value) == 0)
            {
                count++;
            }
            current = current.Next;
        }

        if (count > 0)
        {
            Console.WriteLine($"{value} exists {count} time(s) in the list.");
        }
        else
        {
            Console.WriteLine($"{value} does not exist.");
        }
    }

    public void RemoveOne(T value)
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        var current = head;
        while (current != null)
        {
            if (current.Data!.CompareTo(value) == 0)
            {
                if (current == head)
                {
                    head = head.Next;
                    if (head != null)
                        head.Prev = null;
                    else
                        tail = null;
                }
                else if (current == tail)
                {
                    tail = tail.Prev;
                    if (tail != null)
                        tail.Next = null;
                }
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }
                Console.WriteLine($"Removed an occurrence of {value}.");
                return;
            }
            current = current.Next;
        }
        Console.WriteLine($"{value} was not found.");
    }

    public void RemoveAll(T value)
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        var current = head;
        bool removed = false;
        while (current != null)
        {
            if (current.Data!.CompareTo(value) == 0)
            {
                var toRemove = current;
                current = current.Next;

                if (toRemove == head)
                {
                    head = head.Next;
                    if (head != null)
                        head.Prev = null;
                    else
                        tail = null;
                }
                else if (toRemove == tail)
                {
                    tail = tail.Prev;
                    if (tail != null)
                        tail.Next = null;
                }
                else
                {
                    toRemove.Prev!.Next = toRemove.Next;
                    toRemove.Next!.Prev = toRemove.Prev;
                }

                removed = true;
            }
            else
            {
                current = current.Next;
            }
        }

        Console.WriteLine(removed
            ? $"All occurrences of {value} were removed."
            : $"{value} was not found.");
    }

    public void ClearList()
    {
        if (head == null)
        {
            Console.WriteLine("The list is already empty.");
            return;
        }

        head = null;
        tail = null;
        Console.WriteLine("The list has been completely cleared.");
    }
}

