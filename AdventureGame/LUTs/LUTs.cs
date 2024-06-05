using AdventureGame.save;

namespace AdventureGame.LUTs
{
    public class LUTs
    {
        public Dictionary<string, LUT> lutsMap = new();
        
        public LUTs()
        {
            LoadFromFile.LoadLUTsFromFile(lutsMap);
        }
    }
}
