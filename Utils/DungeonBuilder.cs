using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public abstract class DungeonBuilder
    {
        public abstract DungeonRoom BuildDungeon();
        //{
        //    var enter = new DungeonRoom("Enter");
        //    var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
        //    var emptyRoom = new DungeonRoom("Empty");
        //    var lootRoom = new DungeonRoom("Loot1", new Gold());
        //    var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
        //    var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

        //    enter.TrySetDirection(Direction.Right, monsterRoom);
        //    enter.TrySetDirection(Direction.Left, emptyRoom);

        //    monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
        //    monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

        //    emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

        //    lootRoom.TrySetDirection(Direction.Forward, finalRoom);
        //    lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

        //    return enter;
        //}
        public class EasyDungeonBuilder : DungeonBuilder
        {
            //public override DungeonRoom BuildDungeon()
            //{
            //    //var enter = new DungeonRoom("Enter");
            //    //var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
            //    //var emptyRoom = new DungeonRoom("Empty");
            //    //var lootRoom = new DungeonRoom("Loot1", new Gold());
            //    //var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            //    //var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            //    //enter.TrySetDirection(Direction.Right, monsterRoom);
            //    //enter.TrySetDirection(Direction.Left, emptyRoom);

            //    //monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            //    //monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            //    //emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            //    //lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            //    //lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            //    //return enter;
            //}
            private readonly UnitFactoryDemo unitFactory;

            public EasyDungeonBuilder(UnitFactoryDemo unitFactory)
            {
                this.unitFactory = unitFactory;
            }

            public override DungeonRoom BuildDungeon()
            {
                var enter = new DungeonRoom("Enter");
                var monsterRoom = new DungeonRoom("Monster", unitFactory.CreateGoblinEnemy());
                var emptyRoom = new DungeonRoom("Empty");
                var lootRoom = new DungeonRoom("Loot1", new Gold());
                var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
                var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

                enter.TrySetDirection(Direction.Right, monsterRoom);
                enter.TrySetDirection(Direction.Left, emptyRoom);

                monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
                monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

                emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

                lootRoom.TrySetDirection(Direction.Forward, finalRoom);
                lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

                return enter;
            }
        }
        public class HardDungeonBuilder : DungeonBuilder
        {
            //public override DungeonRoom BuildDungeon()
            //{
            //    var enter = new DungeonRoom("Enter");
            //    var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
            //    var emptyRoom = new DungeonRoom("Empty");
            //    var lootRoom = new DungeonRoom("Loot1", new Gold());
            //    var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            //    var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            //    enter.TrySetDirection(Direction.Right, monsterRoom);
            //    enter.TrySetDirection(Direction.Left, emptyRoom);

            //    monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            //    monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            //    emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            //    lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            //    lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            //    return enter;
            //}
            private readonly UnitFactoryDemo unitFactory;

            public HardDungeonBuilder(UnitFactoryDemo unitFactory)
            {
                this.unitFactory = unitFactory;
            }

            public override DungeonRoom BuildDungeon()
            {
                var enter = new DungeonRoom("Enter");
                var monsterRoom = new DungeonRoom("Monster", unitFactory.CreateGoblinEnemy());
                var emptyRoom = new DungeonRoom("Empty");
                var lootRoom = new DungeonRoom("Loot1", new Gold());
                var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
                var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

                enter.TrySetDirection(Direction.Right, monsterRoom);
                enter.TrySetDirection(Direction.Left, emptyRoom);

                monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
                monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

                emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

                lootRoom.TrySetDirection(Direction.Forward, finalRoom);
                lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

                return enter;
            }
        }
    }
}
