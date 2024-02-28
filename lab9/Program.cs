using System;
using System.Collections.Generic;

class ConversationMemento
{
    public List<string> Words { get; private set; }

    public ConversationMemento(List<string> words)
    {
        Words = new List<string>(words);
    }
}

class Person
{
    private List<string> conversationHistory = new List<string>();

    public void AddWord(string word)
    {
        conversationHistory.Add(word);
    }

    public void PrintConversation()
    {
        Console.WriteLine("Conversation:");
        foreach (var word in conversationHistory)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }

    public ConversationMemento SaveConversation()
    {
        return new ConversationMemento(conversationHistory);
    }

    public void RestoreConversation(ConversationMemento memento)
    {
        conversationHistory = memento.Words;
    }
}

class Memory
{
    private Stack<ConversationMemento> conversationHistoryMemory = new Stack<ConversationMemento>();

    public void SaveConversation(ConversationMemento memento)
    {
        conversationHistoryMemory.Push(memento);
    }

    public ConversationMemento Undo()
    {
        if (conversationHistoryMemory.Count > 1)
        {
            conversationHistoryMemory.Pop();
            return conversationHistoryMemory.Peek();
        }
        else
        {
            return conversationHistoryMemory.Peek();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        Memory memory = new Memory();

        person.AddWord("Привіт");
        person.AddWord("я");
        person.AddWord("програміст");
        person.PrintConversation();

        memory.SaveConversation(person.SaveConversation());

        person.AddWord("вивчаю");
        person.AddWord("патерни");
        person.PrintConversation();

        person.RestoreConversation(memory.Undo());
        person.PrintConversation();
    }
}
