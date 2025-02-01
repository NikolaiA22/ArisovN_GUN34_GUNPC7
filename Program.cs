using GamePrototype.Game;
using GamePrototype.Units;

namespace GamePrototype
{
    internal class Program
    {
        public enum DifficultyLevel
        {
            Easy,
            Hard
        }

        static void Main(string[] args)
        {
            DungeonBuilder builder = new EasyDungeonBuilder();
            Dungeon dungeon = builder.CreateDungeon();

            Console.WriteLine($"Создано подземелье: {dungeon.Name}, сложность: {dungeon.Difficulty}, количество монстров: {dungeon.MonstersCount}");
        }

        public abstract class DungeonBuilder
        {
            public abstract Dungeon CreateDungeon();
        }

        public class EasyDungeonBuilder : DungeonBuilder
        {
            public override Dungeon CreateDungeon()
            {
                return new Dungeon { Name = "Легкое подземелье", Difficulty = "Easy", MonstersCount = 5 };
            }
        }

        public class HardDungeonBuilder : DungeonBuilder
        {
            public override Dungeon CreateDungeon()
            {
                return new Dungeon { Name = "Тяжелое подземелье", Difficulty = "Hard", MonstersCount = 10 };
            }
        }

        public class Dungeon
        {
            public string Name { get; set; }
            public string Difficulty { get; set; }
            public int MonstersCount { get; set; }
        }
    }
}