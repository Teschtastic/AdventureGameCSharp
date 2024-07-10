namespace AdventureGame.Actions
{
    public class Actions
    {

        /* HashMap used for storing Lists of different actions that a user might type as values
           and assigning them to an Integer key for easier and prettier parsing */
        public Dictionary<int, List<string>> actionsMap = new();

        /* Constructing the different actions that will be used */
        public Actions()
        {
            actionsMap.Add(1,  new List<string> { "i",      "inventory" });
            actionsMap.Add(2,  new List<string> { "h",      "help"      });
            actionsMap.Add(3,  new List<string> { "wh",     "where"     });
            actionsMap.Add(4,  new List<string> { "n",      "e",        "s",    "w",    "N",    "E",    "S",    "W" });
            actionsMap.Add(5,  new List<string> { "v",      "view",     "l",    "look"  });
            actionsMap.Add(6,  new List<string> { "p",      "pickup",   "g",    "grab"  });
            actionsMap.Add(7,  new List<string> { "dr",     "drop",     "to",   "toss"  });
            actionsMap.Add(8,  new List<string> { "de",     "describe"  });
            actionsMap.Add(9,  new List<string> { "u",      "use"       });
            actionsMap.Add(10, new List<string> { "t",      "talk"      });
            actionsMap.Add(11, new List<string> { "g",      "give"      });
            actionsMap.Add(12, new List<string> { "ta",     "take"      });
            actionsMap.Add(13, new List<string> { "ch",     "character" });
            actionsMap.Add(14, new List<string> { "eq",     "equip"     });
            actionsMap.Add(15, new List<string> { "une",    "unequip"   });
            actionsMap.Add(16, new List<string> { "sa",     "save"      });
            actionsMap.Add(0,  new List<string> { "q",      "quit"      });
        }

        /* Generic type choice message */
        public static void CommandChoice()
        {
            Console.Write("\n--------------------------------------\nType your command choice:\n> ");
        }

        public static void DialogueChoice()
        {
            Console.Write("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\nType your dialogue choice:\n> ");
        }

        public static void ItemChoice()
        {
            Console.Write("\n======================================\nType your item choice:\n> ");
        }

        public static void ContainerChoice()
        {
            Console.Write("\n**************************************\nType your container choice:\n> ");
        }

        public static void BattleChoice()
        {
            Console.Write("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\nType your battle choice:\n> ");
        }

        /* Various messages that will print to the user based oin their choices */
        public static void WelcomeMessage()
        {
            Console.WriteLine("+------------------------------------+\n" +
                              "| Welcome to my Adventure Game!      |\n" +
                              "| This is still a WIP.               |\n" +
                              "| You can move N, E, S, or W         |\n" +
                              "| (Type 'h' or 'help' for help menu) |\n" +
                              "+------------------------------------+");
        }

        /* Method used to display exit message */
        public static void ExitMessage()
        {
            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n" +
                                "@        Thank you for playing       @\n" +
                                "@        Now exiting the game        @\n" +
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n");
        }

        /* Method used to display exit message */
        public static void DeathMessage()
        {
            Console.WriteLine("\n======================================\n" +
                                "#      Your character has died       #\n" +
                                "#        Now exiting the game        #\n" +
                                "======================================\n");
        }

        public static void SaveMessage()
        {

            Console.WriteLine("\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n" +
                                "*    You have saved your progress    *\n" +
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        }

        public static void BattleMessage()
        {

            Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n" +
                                ">        Battle has initiated        <\n" +
                                "<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        }

        /* Method used to display user input error */
        public static void InputError()
        {
            Console.WriteLine("\nError. Not a valid input.\nTry again.");
        }

        /* Method used to display a generic error */
        public static void GenericError()
        {
            Console.WriteLine("\nError.");
        }
    }
}