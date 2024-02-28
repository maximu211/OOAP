using System;
using System.Collections.Generic;

interface IChatMediator
{
    void SendMessage(string message, Participant participant);
}

class ChatMediator : IChatMediator
{
    private List<Participant> participants = new List<Participant>();

    public void AddParticipant(Participant participant)
    {
        participants.Add(participant);
    }

    public void SendMessage(string message, Participant sender)
    {
        foreach (var participant in participants)
        {
            if (participant != sender)
                participant.Receive(message);
        }
    }
}

abstract class Participant
{
    protected IChatMediator mediator;
    public string Name { get; }

    public Participant(IChatMediator mediator, string name)
    {
        this.mediator = mediator;
        Name = name;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

class ConcreteParticipant : Participant
{
    public ConcreteParticipant(IChatMediator mediator, string name)
        : base(mediator, name) { }

    public override void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        mediator.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{Name} receives: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var mediator = new ChatMediator();

        var participant1 = new ConcreteParticipant(mediator, "Participant 1");
        var participant2 = new ConcreteParticipant(mediator, "Participant 2");
        var participant3 = new ConcreteParticipant(mediator, "Participant 3");

        mediator.AddParticipant(participant1);
        mediator.AddParticipant(participant2);
        mediator.AddParticipant(participant3);

        participant1.Send("Hello, everyone!");
        participant2.Send("Hi there!");
        participant3.Send("Hey folks!");
    }
}
