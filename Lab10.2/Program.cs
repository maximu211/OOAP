namespace Lab10._2
{
    abstract class GameAI
    {
        public void TemplateMethod()
        {
            this.CreateWorkers();
            this.CollectMinerals();
            this.BuildStructers();
            this.BuildArmy();
            this.AddBuffToUnits();
        }

        void CreateWorkers()
        {
            Console.WriteLine("Building workers...");
        }

        void CollectMinerals()
        {
            Console.WriteLine("Collecting minerals...");
        }

        void BuildStructers()
        {
            Console.WriteLine("Building structure...");
        }

        protected abstract void BuildArmy();

        protected abstract void AddBuffToUnits();
    }

    class Terran : GameAI
    {
        protected override void AddBuffToUnits()
        {
            Console.WriteLine("all units have stimpack");
        }

        protected override void BuildArmy()
        {
            Console.WriteLine("Build marrine");
        }
    }

    class Protoss : GameAI
    {
        protected override void AddBuffToUnits()
        {
            Console.WriteLine("All units have energy shield");
        }

        protected override void BuildArmy()
        {
            Console.WriteLine("Build Zealot");
        }
    }

    class Zerg : GameAI
    {
        protected override void AddBuffToUnits()
        {
            Console.WriteLine("All units have aditional move speed");
        }

        protected override void BuildArmy()
        {
            Console.WriteLine("Build A LOT zerglings");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Terran terran = new Terran();
            Zerg zerg = new Zerg();
            Protoss protoss = new Protoss();

            Console.WriteLine("TERRANS");
            terran.TemplateMethod();
            Console.WriteLine();
            Console.WriteLine("PROTOSS");
            protoss.TemplateMethod();
            Console.WriteLine();
            Console.WriteLine("OMG ZERG RUSH");
            zerg.TemplateMethod();
        }
    }
}
