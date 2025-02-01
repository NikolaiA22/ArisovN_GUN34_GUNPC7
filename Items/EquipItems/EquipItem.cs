using GamePrototype.Items.EconomicItems;
using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    // Базовый класс для экипировки
    public abstract class EquipItem
    {
        public uint Durability { get; protected set; }
        public string Name { get; }
        public abstract EquipSlot Slot { get; }

        protected EquipItem(uint durability, string name)
        {
            Durability = durability;
            Name = name;
        }

        public void TakeDamage()
        {
            if (Durability > 0)
            {
                Durability--;
                Console.WriteLine($"{Name} получил урон. Осталось прочности: {Durability}");
            }
            else
            {
                Console.WriteLine($"{Name} полностью сломан!");
            }
        }

        public void Repair(uint amount)
        {
            Durability += amount;
            Console.WriteLine($"{Name} восстановлен на {amount}. Теперь прочность: {Durability}");
        }
    }

    // Класс дальнобойного оружия
    public sealed class Weapon : EquipItem
    {
        public Weapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;
        public uint Damage { get; }

        public override EquipSlot Slot => EquipSlot.RangeWeapon;
    }

    // Класс шлема
    public sealed class Armour : EquipItem
    {
        public Armour(uint defence, uint durability, string name) : base(durability, name) => Defence = defence;

        public uint Defence { get; }

        public override EquipSlot Slot => EquipSlot.Helmet;
    }

    // Класс точильного камня
    public sealed class SharpeningStone : InventoryItem
    {
        public SharpeningStone(string name) : base(name) { }

        public void Use(EquipItem item)
        {
            item.Repair(5); // Восстанавливаем 5 единиц прочности
            Console.WriteLine($"Точильный камень использован на {item.Name}.");
        }
    }

    public class InventoryItem
    {
        public string Name { get; }

        // Конструктор, принимающий имя
        public InventoryItem(string name)
        {
            Name = name;
        }
    }

    // Перечисление для слотов экипировки
    public enum EquipSlot
    {
        Armour,
        RangeWeapon,
        Helmet
    }
}
