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
            Inventory = [];
            KnownRecipes = [];
            CurrentQuest = "";
            AvailableQuests = [];
            CompletedQuests = [];
            FailedeQuests = [];
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

        public Player ShallowCopy()
        {
            return (Player)MemberwiseClone();
        }

        public Player DeepCopy()
        {
            Player other = (Player)MemberwiseClone();
            other.Name = Name + "Copy";
            return other;
        }

        public static int Operator(string logic, int x, int y)
        {
            return logic switch
            {
                "+=" => x += y,
                "-=" => x -= y,
                "=" => y,
                _ => throw new Exception("invalid logic"),
            };
        }

        public static string Operator(string logic, string y)
        {
            return logic switch
            {
                "=" => y,
                _ => throw new Exception("invalid logic"),
            };
        }

        public void UpdatePlayerStatus(Item.StatusType sType, object sModifier, string direction)
        {
            Dictionary<string, string> op = new()
            {
                { "increased", "+=" },
                { "decreased", "-=" },
                { "changed",   "=" },
            };

            Console.WriteLine($"\nYour {sType} {direction} by {sModifier}.");

            switch (sType)
            {
                case Item.StatusType.Default:
                    throw new NotImplementedException();
                case Item.StatusType.Name:
                    Name = Operator(op[direction], (string)sModifier);
                    break;
                case Item.StatusType.CurrentHealth:
                    CurrentHealth = Operator(op[direction], CurrentHealth, (int)sModifier);
                    break;
                case Item.StatusType.MaximumHealth:
                    MaximumHealth = Operator(op[direction], MaximumHealth, (int)sModifier);
                    break;
                case Item.StatusType.ArmorClass:
                    ArmorClass = Operator(op[direction], ArmorClass, (int)sModifier);
                    break;
                case Item.StatusType.AttackDamage:
                    AttackDamage = Operator(op[direction], AttackDamage, (int)sModifier);
                    break;
                case Item.StatusType.CurrentCarryWeight:
                    CurrentCarryWeight = Operator(op[direction], CurrentCarryWeight, (int)sModifier);
                    break;
                case Item.StatusType.MaximumCarryWeight:
                    MaximumCarryWeight = Operator(op[direction], MaximumCarryWeight, (int)sModifier);
                    break;
                default:
                    throw new NotImplementedException();
            };
        }
            

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

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Name);
            hash.Add(CurrentHealth);
            hash.Add(CurrentCarryWeight);
            hash.Add(MaximumHealth);
            hash.Add(CurrentCarryWeight);
            hash.Add(MaximumCarryWeight);
            hash.Add(ArmorClass);
            hash.Add(AttackDamage);
            hash.Add(EquippedArmor);
            hash.Add(EquippedWeapon);
            return hash.ToHashCode();
        }
    }
}