namespace lab7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Editor editor = new Editor();
            LayoutDesigner layoutDesigner = new LayoutDesigner();
            Designer designer = new Designer();

            editor.Successor = layoutDesigner;
            layoutDesigner.Successor = designer;

            MagazineTask task1 = new MagazineTask("Внесення правок");
            editor.ProcessTask(task1);

            MagazineTask task2 = new MagazineTask("Оформлення макету");
            editor.ProcessTask(task2);

            MagazineTask task3 = new MagazineTask("Створення дизайну");
            editor.ProcessTask(task3);
        }
    }

    class MagazineTask
    {
        public string Description { get; }

        public MagazineTask(string description) => Description = description;
    }

    abstract class MagazineEditor
    {
        public MagazineEditor Successor { get; set; }
        public abstract void ProcessTask(MagazineTask task);
    }

    class Editor : MagazineEditor
    {
        public override void ProcessTask(MagazineTask task)
        {
            if (task.Description == "Внесення правок")
            {
                Console.WriteLine("Редактор вносить правки.");
            }
            else if (Successor != null)
            {
                Successor.ProcessTask(task);
            }
        }
    }

    class LayoutDesigner : MagazineEditor
    {
        public override void ProcessTask(MagazineTask task)
        {
            if (task.Description == "Оформлення макету")
            {
                Console.WriteLine("Макетувальник оформлює макет.");
            }
            else if (Successor != null)
            {
                Successor.ProcessTask(task);
            }
        }
    }

    class Designer : MagazineEditor
    {
        public override void ProcessTask(MagazineTask task)
        {
            if (task.Description == "Створення дизайну")
            {
                Console.WriteLine("Дизайнер створює дизайн.");
            }
            else if (Successor != null)
            {
                Successor.ProcessTask(task);
            }
        }
    }
}
