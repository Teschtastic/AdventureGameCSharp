using AdventureGame.Items;

namespace AdventureGame.Actions
{
    internal class EquipItemToPlayer
    {
        public static void EquipArmor(Player.Player player, Armor armor)
        {
            Console.WriteLine(armor.UseMessage);
            Console.WriteLine("\nYour armor class increased by " + armor.ArmorClass + ".");
            player.EquippedArmor = armor.Name;
            player.HasEquippedArmor = true;
            player.ArmorClass += armor.ArmorClass;
            player.RemoveFromInventory(armor);
        }

        public static void EquipWeapon(Player.Player player, Weapon weapon)
        {
            Console.WriteLine(weapon.UseMessage);
            Console.WriteLine("\nYour attack damage increased by " + weapon.AttackDamage + ".");
            player.EquippedWeapon = weapon.Name;
            player.HasEquippedWeapon = true;
            player.AttackDamage += weapon.AttackDamage;
            player.RemoveFromInventory(weapon);
        }
    }
}
