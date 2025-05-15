namespace AdventureGame.Actions
{
    public class Actions
    {

        /* HashMap used for storing Lists of different actions that a user might type as values
           and assigning them to an Integer key for easier and prettier parsing */
        public Dictionary<int, List<string>> actionsMap = [];

        /* Constructing the different actions that will be used */
        public Actions()
        {
            actionsMap.Add(1,  ["i",      "inventory"]);
            actionsMap.Add(2,  ["h",      "help"]);
            actionsMap.Add(3,  ["wh",     "where"]);
            actionsMap.Add(4,  ["n",      "e",        "s",    "w"]);
            actionsMap.Add(5,  ["v",      "view",     "l",    "look"]);
            actionsMap.Add(6,  ["p",      "pickup",   "g",    "grab"]);
            actionsMap.Add(7,  ["dr",     "drop",     "to",   "toss"]);
            actionsMap.Add(8,  ["de",     "describe"]);
            actionsMap.Add(9,  ["u",      "use"]);
            actionsMap.Add(10, ["t",      "talk"]);
            actionsMap.Add(11, ["g",      "give"]);
            actionsMap.Add(12, ["ta",     "take"]);
            actionsMap.Add(13, ["ch",     "character"]);
            actionsMap.Add(14, ["sa",     "save"]);
            actionsMap.Add(15, ["b",      "battle"]);
            actionsMap.Add(0,  ["q",      "quit"]);
        }
    }
}