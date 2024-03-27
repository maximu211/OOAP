namespace lab9._1
{
    interface IObserver
    {
        void Update(string message);
    }

    class Client : IObserver
    {
        private string name;

        public Client(string name)
        {
            this.name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{this.name} отримав оновлення: {message}");
        }
    }

    class FootballMatch
    {
        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void DeleteObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(message);
            }
        }

        public void ChangeBet(string betInfo)
        {
            NotifyObservers(betInfo);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            FootballMatch match = new FootballMatch();

            Client client1 = new Client("Клієнт1");
            Client client2 = new Client("Клієнт2");

            match.AddObserver(client1);
            match.AddObserver(client2);

            match.ChangeBet("Ставка Клієнта 1: Перший гол - команда А");
            match.ChangeBet("Ставка Клієнта 2: Результат матчу - нічия");

            match.DeleteObserver(client2);

            match.ChangeBet("Ставка Клієнта 1: Кількість голів більше 2");
        }
    }
}
