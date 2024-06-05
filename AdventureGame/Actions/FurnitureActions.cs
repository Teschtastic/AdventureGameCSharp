using AdventureGame.Globals;
using AdventureGame.Rooms;
using AdventureGame.Furnitures;

namespace AdventureGame.Actions
{
    internal class FurnitureActions
    {
        /* Method used to use a furniture */
        public static void UseFurniture(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            if (room.HasFurniture)
            {
                Furniture furniture = AllObjects.allFurnitures.GetFurniture(room.FurnitureInRoom + " in " + room.Name);

                if (furniture.CanUse)
                {
                    Console.WriteLine(furniture.UseMessage);
                    UsedFurnitureOnPlayer.UseFurniture(player);
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
        public static void DescribeFurniture(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            Furniture furniture = AllObjects.allFurnitures.GetFurniture(room.FurnitureInRoom + " in " + room.Name);

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
