using AdventureGame.Actions;
using AdventureGame.Player;
using AdventureGame.save;

Dictionary<int, List<string>> userActions = new Actions().actionsMap;
    
LoadFromFile.LoadPlayerFromFile(out Player? player);

if (player != null)
{
    ActionsParser.GameLoop(player, userActions);
}