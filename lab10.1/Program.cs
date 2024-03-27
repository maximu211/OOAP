using System;
using System.Collections.Generic;

namespace DarkForestGame
{
    interface IStrategy
    {
        void Execute(GameUnit unit);
    }

    class GameUnit
    {
        public string Name { get; set; }
        public List<string> MagicItems { get; set; }
        private IStrategy strategy;

        public GameUnit(string name, List<string> magicItems)
        {
            this.Name = name;
            this.MagicItems = magicItems;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            if (strategy != null)
                strategy.Execute(this);
            else
                Console.WriteLine("No strategy set!");
        }

        public bool CanPassObstacle(string obstacle)
        {
            return MagicItems.Contains(obstacle);
        }
    }

    class ForestStrategy : IStrategy
    {
        public void Execute(GameUnit unit)
        {
            if (unit.CanPassObstacle("Lantern"))
            {
                Console.WriteLine("Passing through the dark forest with Lantern...");
            }
            else
            {
                Console.WriteLine("Cannot pass through the dark forest without necessary items...");
            }
        }
    }

    class RiverStrategy : IStrategy
    {
        public void Execute(GameUnit unit)
        {
            if (unit.CanPassObstacle("Boat"))
            {
                Console.WriteLine("Crossing the rapid river with Boat...");
            }
            else
            {
                Console.WriteLine("Cannot cross the rapid river without necessary items...");
            }
        }
    }

    class MountainStrategy : IStrategy
    {
        public void Execute(GameUnit unit)
        {
            if (unit.CanPassObstacle("Rope"))
            {
                Console.WriteLine("Scaling the treacherous mountains with Rope...");
            }
            else
            {
                Console.WriteLine(
                    "Cannot scale the treacherous mountains without necessary items..."
                );
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> magicItems1 = new List<string> { "Lantern", "Map" };
            List<string> magicItems2 = new List<string> { "Boat", "Compass" };
            List<string> magicItems3 = new List<string> { "Rope", "Pickaxe" };

            GameUnit unit1 = new GameUnit("Unit 1", magicItems1);
            GameUnit unit2 = new GameUnit("Unit 2", magicItems2);
            GameUnit unit3 = new GameUnit("Unit 3", magicItems3);

            IStrategy forestStrategy = new ForestStrategy();
            IStrategy riverStrategy = new RiverStrategy();
            IStrategy mountainStrategy = new MountainStrategy();

            // Set strategy for units
            unit1.SetStrategy(forestStrategy);
            unit2.SetStrategy(riverStrategy);
            unit3.SetStrategy(mountainStrategy);

            // Execute strategies
            unit1.ExecuteStrategy();
            unit2.ExecuteStrategy();
            unit3.ExecuteStrategy();
        }
    }
}
