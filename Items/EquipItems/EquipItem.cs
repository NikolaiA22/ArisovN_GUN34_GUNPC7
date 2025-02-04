using GamePrototype.Items.EconomicItems;
using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public abstract class EquipItem : Item
    {
        private uint _durability;
        private uint _maxDurability;
        public uint Durability { get => _durability; protected set => _durability = value; }
        public override bool Stackable => false;

        public abstract EquipSlot Slot { get; }

        protected EquipItem(uint maxDurability, string name) : base(name) => _maxDurability = maxDurability;

        public void ReduceDurability(uint delta) => _durability -= delta;

        public void Repair(uint delta) => 
            _durability += _durability + delta > _maxDurability 
            ? _maxDurability 
            : _durability + delta;
    }
    public sealed class LeatherArmour : Armour
    {
        public LeatherArmour() : base(defence: 5, durability: 20, name: "Leather Armour")
        {
        }
    }
    public sealed class IronArmour : Armour
    {
        public IronArmour() : base(defence: 15, durability: 30, name: "Iron Armour")
        {
        }
    }
    public sealed class Sword : Weapon
    {
        public Sword() : base(damage: 10, durability: 25, name: "Sword")
        {
        }
    }
    public sealed class Bow : Weapon
    {
        public Bow() : base(damage: 7, durability: 20, name: "Bow")
        {
        }
    }
}
