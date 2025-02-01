using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;
using EquipSlot = GamePrototype.Items.EquipItems.EquipSlot;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public uint UnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.RangeWeapon, out var item) && item is RangeWeapon weapon) 
            {
                return BaseDamage + weapon.Damage;
            }
            return BaseDamage;
        }

        public void HandleCombat()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }
        public class Item
        {
            public string Name { get; set; }
        }

        public abstract class EquipItem : Item
        {
            public uint Durability { get; protected set; }
            public abstract EquipSlot Slot { get; }

            protected EquipItem(uint durability, string name)
            {
                Name = name;
                Durability = durability;
            }
        }

        public void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem)
            {
                // Логика для EquipItem
                Console.WriteLine($"Добавлен предмет экипировки: {equipItem.Name}");
            }
            else
            {
                // Логика для обычного Item
                Console.WriteLine($"Добавлен обычный предмет: {item.Name}");
            }
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Health += healthPotion.HealthRestore;
            }
        }

        protected uint CalculateDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Helmet, out var item) && item is Helmet armour) 
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
            }
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            throw new NotImplementedException();
        }

        public override uint GetUnitDamage()
        {
            throw new NotImplementedException();
        }

        public override void HandleCombatComplete()
        {
            throw new NotImplementedException();
        }
    }
}
