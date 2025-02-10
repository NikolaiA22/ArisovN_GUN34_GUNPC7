using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public enum Difficulty
    {
        Easy,
        Hard
    }
    public abstract class UnitFactoryDemo
    {
        public abstract Unit CreatePlayer(string name);

        public abstract Unit CreateGoblinEnemy();
    }
    public class EasyUnitFactory : UnitFactoryDemo
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 40, 40, 8);
            player.AddItemToInventory(new Weapon(12, 20, "Sword"));
            player.AddItemToInventory(new Armour(12, 20, "Armour"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            player.AddItemToInventory(new Grindstone("Stone"));
            return player;
        }

        public override Unit CreateGoblinEnemy()
        {
            return new Goblin(GameConstants.Goblin, 15, 15, 1);
        }
    }
    public class HardUnitFactory : UnitFactoryDemo
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 20, 20, 4);
            player.AddItemToInventory(new Weapon(8, 10, "Sword"));
            player.AddItemToInventory(new Armour(8, 10, "Armour"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            player.AddItemToInventory(new Grindstone("Stone"));
            return player;
        }

        public override Unit CreateGoblinEnemy()
        {
            return new Goblin(GameConstants.Goblin, 25, 25, 3);
        }
    }
}
