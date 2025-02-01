using GamePrototype.Units;

namespace GamePrototype.Items.EquipItems
{
    public class RangeWeapon : Player.EquipItem
    {
        public uint Damage { get; }

        public RangeWeapon(uint damage, uint durability, string name) : base(durability, name)
        {
            Damage = damage;
        }

        public override EquipSlot Slot => EquipSlot.RangeWeapon;
    }
}

