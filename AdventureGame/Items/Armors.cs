using AdventureGame.save;

namespace AdventureGame.Items
{
    public class Armors
    {
        // Dictionary the armors are stored in
        public Dictionary<string, Armor> armorMap = new();

        public Armors()
        {
            LoadFromFile.LoadArmorsFromFile(armorMap);
        }
    }
}
