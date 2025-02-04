using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        public Armour EquippedArmour { get; private set; }
        public Weapon EquippedWeapon { get; private set; }

        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }
        public void EquipItem(EquipItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (_equipment.TryGetValue(item.Slot, out var oldItem))
            {
                AddItemToInventory(oldItem);
                Console.WriteLine($"[System]: {oldItem.Name} был снят и возвращен в инвентарь.");
            }

            _equipment[item.Slot] = item;
            Console.WriteLine($"Экипирован {item.Name} в слот {item.Slot}");

            if (item is Armour armour)
            {
                EquippedArmour = armour;
            }
            else if (item is Weapon weapon)
            {
                EquippedWeapon = weapon;
            }
        }
        public void UnequipItem(EquipSlot slot)
        {
            if (_equipment.TryGetValue(slot, out var item))
            {
                AddItemToInventory(item);
                _equipment.Remove(slot);
                Console.WriteLine($"Снят {item.Name} из слота {slot}");

                if (slot == EquipSlot.Armour)
                {
                    EquippedArmour = null;
                }
                else if (slot == EquipSlot.Weapon)
                {
                    EquippedWeapon = null;
                }
            }
            else
            {
                Console.WriteLine($"[System]: Нет предмета экипированого в {slot}.");
            }
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                return BaseDamage + weapon.Damage;
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
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

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem && _equipment.TryAdd(equipItem.Slot, equipItem)) 
            {
                // Item was equipped
                return;
            }
            base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem, EquipItem equipItemToRestore = null)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Health += healthPotion.HealthRestore;
            }
            else if (economicItem is Grindstone grindstone)
            {
                if (equipItemToRestore != null)
                {
                    equipItemToRestore.Repair(grindstone.DurabilityRestore);
                }
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) 
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
    }
}
