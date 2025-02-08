using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;
using static GamePrototype.Utils.DungeonBuilder;
using System;

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();
        
        public void StartGame() 
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop

        private void Initialize()
        {
            Console.WriteLine("Welcome, player!");
            var difficulty = ChooseDifficulty();
            DungeonBuilder builder = difficulty == "easy"
                ? new EasyDungeonBuilder(new HardUnitFactory())
                : new HardDungeonBuilder(new EasyUnitFactory());
            _dungeon = builder.BuildDungeon();
            Console.WriteLine("Enter your name");
            UnitFactoryDemo factory = new EasyUnitFactory();
            _player = factory.CreatePlayer(Console.ReadLine());
            Console.WriteLine($"Hello {_player.Name}");
            //Console.WriteLine("Welcome, player!");
            //DungeonBuilder builder = new EasyDungeonBuilder(new EasyUnitFactory());
            //_dungeon = builder.BuildDungeon();
            //Console.WriteLine("Enter your name");
            //UnitFactoryDemo factory = new EasyUnitFactory();
            //_player = factory.CreatePlayer(Console.ReadLine());
            //Console.WriteLine($"Hello {_player.Name}");
        }
        private string ChooseDifficulty()
{
    Console.WriteLine("Choose difficulty level (easy/hard):");
    string choice;
    while (true)
    {
        choice = Console.ReadLine().ToLower();
        if (choice == "easy" || choice == "hard")
        {
            break;
        }
        Console.WriteLine("Invalid choice. Please select 'easy' or 'hard'.");
    }
    return choice;
}

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            
            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) ) 
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Wrong direction!");
                    }
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null) 
            {
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int) room.Key}\t");
            }
        }

        
        #endregion
    }
}
