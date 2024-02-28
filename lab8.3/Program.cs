using System;
using System.Collections.Generic;

namespace lab8._3
{
    interface IIterator
    {
        bool HasNext();
        PhoneBookEntry Next();
    }

    class DoublyLinkedListIterator : IIterator
    {
        private Node current;

        public DoublyLinkedListIterator(Node head)
        {
            current = head;
        }

        public bool HasNext()
        {
            return current != null;
        }

        public PhoneBookEntry Next()
        {
            if (current == null)
                throw new InvalidOperationException("End of the list");

            PhoneBookEntry data = current.Data;
            current = current.Next;
            return data;
        }
    }

    interface IAggregate
    {
        IIterator GetIterator();
    }

    class DoublyLinkedList : IAggregate
    {
        private Node head;
        private Node tail;

        public void Add(PhoneBookEntry data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        public IIterator GetIterator()
        {
            return new DoublyLinkedListIterator(head);
        }
    }

    class PhoneBookEntry
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneBookEntry(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }

    class Node
    {
        public PhoneBookEntry Data { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(PhoneBookEntry data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList phoneBook = new DoublyLinkedList();

            phoneBook.Add(new PhoneBookEntry("John", "1234567890"));
            phoneBook.Add(new PhoneBookEntry("Jane", "9876543210"));
            phoneBook.Add(new PhoneBookEntry("Alice", "5551234567"));

            IIterator iterator = phoneBook.GetIterator();
            while (iterator.HasNext())
            {
                PhoneBookEntry entry = iterator.Next();
                Console.WriteLine($"Name: {entry.Name}, Phone Number: {entry.PhoneNumber}");
            }
        }
    }
}
