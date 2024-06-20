using AdventureGame.Items;
using AdventureGame.Rooms;

namespace AdventureGame.Player
{
    public class Player
    {
        // Constructing the player object
        public Player()
        {
            Name = "";
            RoomIsIn = "";
            EquippedArmor = "";
            EquippedWeapon = "";
            Inventory = new();
            KnownRecipes = new();
            CurrentQuest = "";
            AvailableQuests = new();
            CompletedQuests = new();
            FailedeQuests = new();
        }

        public string       Name                { get; set; }
        public int          CurrentHealth       { get; set; }
        public int          MaximumHealth       { get; set; }
        public int          ArmorClass          { get; set; }
        public int          AttackDamage        { get; set; }
        public int          CurrentCarryWeight  { get; set; }
        public int          MaximumCarryWeight  { get; set; }
        public List<string> Inventory           { get; set; }
        public string       RoomIsIn            { get; set; }
        public string       EquippedArmor       { get; set; }
        public bool         HasEquippedArmor    { get; set; }
        public string       EquippedWeapon      { get; set; }
        public bool         HasEquippedWeapon   { get; set; }
        public List<string> KnownRecipes        { get; set; }
        public string       CurrentQuest        { get; set; }
        public List<string> AvailableQuests     { get; set; }
        public List<string> CompletedQuests     { get; set; }
        public List<string> FailedeQuests       { get; set; }

        public void AddToInventory(Item item)
        {
            Inventory.Add(item.Name);
            CurrentCarryWeight += item.ItemWeight;
        }

        public void AddToInventory(List<Item> items)
        {
            foreach (Item item in items)
            {
                AddToInventory(item);
            }
        }

        public void RemoveFromInventory(Item item)
        {
            Inventory.Remove(item.Name);
            CurrentCarryWeight -= item.ItemWeight;
        }

        public void RemoveFromInventory(List<Item> items)
        {
            foreach (Item item in items)
            {
                RemoveFromInventory(item);
            }
        }

        public void SetRoomIsIn(string roomName)
        {
            RoomIsIn = roomName;
        }

        public void SetRoomIsIn(Room room)
        {
            RoomIsIn = room.Name;
        }

        public void SetEquippedArmor(string equippedArmorName)
        {
            if (equippedArmorName != "Clothes")
            {
                EquippedArmor = equippedArmorName;
                HasEquippedArmor = true;
            }
            else
            {
                EquippedArmor = "Clothes";
                HasEquippedArmor = false;
            }
        }

        public void SetEquippedWeapon(string equippedWeaponName)
        {

            if (equippedWeaponName != "Fists")
            {
                EquippedWeapon = equippedWeaponName;
                HasEquippedWeapon = true;
            }
            else
            {
                EquippedWeapon = "Fists";
                HasEquippedWeapon = false;
            }
        }

        public void AddToRecipes(string recipe)
        {
            KnownRecipes.Add(recipe);
        }

        public void AddToRecipes(List<string> recipes)
        {
            KnownRecipes.AddRange(recipes);
        }

        public override string ToString()
        {
            return "\nPlayer Description:\n\n" +
                    "Name:            " + Name                  + "\n" +
                    "Current health:  " + CurrentHealth         + "\n" +
                    "Maximum health:  " + MaximumHealth         + "\n" +
                    "Current weight:  " + CurrentCarryWeight    + "\n" +
                    "Maximum weight:  " + MaximumCarryWeight    + "\n" +
                    "Armor class:     " + ArmorClass            + "\n" +
                    "Attack damage:   " + AttackDamage          + "\n" +
                    "Equipped armor:  " + EquippedArmor         + "\n" +
                    "Equipped weapon: " + EquippedWeapon;
        }
    }
}