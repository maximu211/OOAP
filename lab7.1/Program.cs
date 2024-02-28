using System.Text;
using lab7._1.ConcreteCommand;

namespace lab7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Invoker invoker = new Invoker();
            Stack<string> stack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("Current text: " + receiver.GetText());
                Console.WriteLine("Options:");
                Console.WriteLine("1. Add text");
                Console.WriteLine("2. Remove text");
                Console.WriteLine("3. Make italic");
                Console.WriteLine("4. Undo");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter text");
                        string textToAdd = Console.ReadLine();
                        invoker.SetCommand(new AddTextCommand(receiver, textToAdd, stack));
                        invoker.ExecuteCommand();
                        break;
                    case "2":
                        Console.WriteLine("Enter start idex to remove");
                        int startIndexToRemove = int.Parse(Console.ReadLine());
                        Console.Write("Enter length to remove: ");
                        int lengthToRemove = int.Parse(Console.ReadLine());
                        invoker.SetCommand(
                            new RemoveTextCommand(receiver, startIndexToRemove, lengthToRemove)
                        );
                        invoker.ExecuteCommand();
                        break;
                    case "3":
                        Console.WriteLine("Enter start index to make italic");
                        int startIndexToItalicize = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter lenght to make italic");
                        int lengthToItalicize = int.Parse(Console.ReadLine());
                        invoker.SetCommand(
                            new MakeItalicCommand(
                                receiver,
                                lengthToItalicize,
                                startIndexToItalicize
                            )
                        );
                        invoker.ExecuteCommand();
                        break;
                    case "4":
                        invoker.UndoLastCommand();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
