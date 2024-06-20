using AdventureGame.Rooms;
using AdventureGame.Furnitures;
using AdventureGame.Game;

namespace AdventureGame.Actions
{
    internal class FurnitureActions
    {
        /* Method used to use a furniture */
        public static void UseFurniture(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();
            if (room.HasFurniture)
            {
                Furniture? furniture = game.GetFurnitureInRoom();

                if (furniture != null && furniture.CanUse)
                {
                    Console.WriteLine(furniture.UseMessage);
                    UsedFurnitureOnPlayer.UseFurniture(game);
                }
                else
                    Console.WriteLine("\nYou can't use this furniture");
            }
            else
            {
                Console.WriteLine("\nThere isn't furniture in this room");
            }
        }

        /* Method used to describe a furniture */
        public static void DescribeFurniture(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();
            Furniture? furniture = game.GetFurnitureInRoom();

            if (furniture != null && room.HasFurniture)
            {

                Console.WriteLine("\nYou inspect the " + furniture.Name +
                        "\n\nYou describe it as:\n" + furniture.Description);
            }
            else
            {
                Console.WriteLine("\nThere isn't any furniture in this room.");
            }
        }
    }
}
