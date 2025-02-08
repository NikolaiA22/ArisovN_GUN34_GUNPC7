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
    public sealed class Helmet : Armour
    {
        public override EquipSlot Slot => EquipSlot.Head;
        public Helmet() : base(defence: 5, durability: 20, name: "Helmet")
        {
        }
    }
    public sealed class WoodShield : Weapon
    {
        public override EquipSlot Slot => EquipSlot.LeftHand;
        public WoodShield() : base(damage: 10, durability: 25, name: "WoodShield")
        {
        }
    }
    public sealed class Sword : Weapon
    {
        public override EquipSlot Slot => EquipSlot.RightHand;

        public Sword() : base(damage: 15, durability: 30, name: "Sword")
        {
        }
    }
    public sealed class Bow : Weapon
    {
        public override EquipSlot Slot => EquipSlot.Weapon;

        public Bow() : base(damage: 15, durability: 30, name: "Bow")
        {
        }
    }
}
