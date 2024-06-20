using AdventureGame.Items;

namespace AdventureGame.Actions
{
    internal class UnEquipItemFromPlayer
    {
        public static void UnEquipArmor(Player.Player player, Armor armor)
        {
            Console.WriteLine("\nYou un equip your " + armor.Name);
            Console.WriteLine("Your armor class decreases by " + armor.ArmorClass + ".");
            player.EquippedArmor = "Clothes";
            player.HasEquippedArmor = false;
            player.ArmorClass -= armor.ArmorClass;
            player.AddToInventory(armor);
        }

        public static void UnEquipWeapon(Player.Player player, Weapon weapon)
        {
            Console.WriteLine("\nYou un equip your " + weapon.Name);
            Console.WriteLine("Your attack damage decreases by " + weapon.AttackDamage + ".");
            player.EquippedWeapon = "Fists";
            player.HasEquippedWeapon = false;
            player.AttackDamage -= weapon.AttackDamage;
            player.AddToInventory(weapon);
        }
    }
}
