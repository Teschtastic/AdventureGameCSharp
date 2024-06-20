using AdventureGame.Furnitures;
using AdventureGame.Game;
using AdventureGame.LUTs;

namespace AdventureGame.Actions
{
    public class LUTActions
    {
        public static void ProcessLUT(GameObject game, Container container)
        {
            LUT lut = game.GetLUT(container.Lut);

            foreach (var pool in lut.Pools)
            {
                var roll = new Random().Next(pool.Rolls.Min, pool.Rolls.Max);
                var weight = 0;
                List<string> entries = new();

                int index = 0;
                foreach (var entry in pool.Entries)
                {
                    weight += entry.Weight;

                    for (int i = index; i < weight; i++)
                    {
                        entries.Insert(index, entry.Name);
                        index = i + 1;
                    }

                    if (entry.Functions != null && entry.Functions.Count > 0)
                    {
                        foreach (var function in entry.Functions)
                        {
                            GlobalMethods.CallByName(new LUTActions(), function.FunctionFunction, new object[] { container, entry.Name, function.Count.Min, function.Count.Max });
                        }
                    }
                }

                for (int i = 0; i < roll; i++)
                {
                    var selectedItemRoll = new Random().Next(0, weight);

                    container.AddToInventory(entries[selectedItemRoll]);
                }
            }

            container.FirstOpen = true;
            container.Lut = "";
        }

        public static void SetCount(Container container, string itemName, int min, int max)
        {
            var itemCount = new Random().Next(min, max);

            for (int i = 0; i < itemCount; i++)
            {
                container.AddToInventory(itemName);
            }
        }
    }
}
