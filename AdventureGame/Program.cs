using AdventureGame.Actions;
using AdventureGame.Game;
using Foundation;

GameObject game = new();
MessageQueue queue = new();
GameState gameState = new(queue);
gameState.AddEntity(game.Player);

ActionsParser.GameLoop(game, gameState);