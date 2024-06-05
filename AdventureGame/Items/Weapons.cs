using AdventureGame.save;

namespace AdventureGame.Items
{
    public class Weapons
    {
        public Dictionary<string, Weapon> weaponMap = new();

        public Weapons()
        {
            LoadFromFile.LoadWeaponsFromFile(weaponMap);
        }
    }
}
