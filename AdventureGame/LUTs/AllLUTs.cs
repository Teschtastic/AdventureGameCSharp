namespace AdventureGame.LUTs
{
    public class AllLUTs
    {
        private readonly Dictionary<string, LUT> luts = new LUTs().lutsMap;

        public Dictionary<string, LUT> allLUTs = [];

        public AllLUTs()
        {
            luts.ToList().ForEach(x => allLUTs.Add(x.Key, x.Value));
        }

        public LUT? GetLUT(string lutName)
        {
            return allLUTs.TryGetValue(lutName, out LUT? value) ? value : null;
        }
    }
}
