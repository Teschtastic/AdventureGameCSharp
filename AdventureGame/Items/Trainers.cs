using AdventureGame.save;

namespace AdventureGame.Items
{
    public class Trainers
    {
        public Dictionary<string, Trainer> trainersMap = [];

        public Trainers()
        {
            LoadFromFile.LoadTrainersFromFile(trainersMap);
        }
    }
}
