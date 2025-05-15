using System;
using System.Reflection;

namespace Foundation
{
    public class Globals
    {
        /* Generic type choice message */
        public static string CommandChoice()
        {
            return "\n--------------------------------------\nType your command choice:\n> ";
        }

        public static string DialogueChoice()
        {
            return "\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\nType your dialogue choice:\n> ";
        }

        public static string ItemChoice()
        {
            return "\n======================================\nType your item choice:\n> ";
        }

        public static string ContainerChoice()
        {
            return "\n**************************************\nType your container choice:\n> ";
        }

        public static string BattleChoice()
        {
            return "\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\nType your battle choice:\n> ";
        }

        /* Various messages that will print to the user based oin their choices */
        public static string WelcomeMessage()
        {
            return "+------------------------------------+\n" +
                    "| Welcome to my Adventure Game!      |\n" +
                    "| This is still a WIP.               |\n" +
                    "| You can move N, E, S, or W         |\n" +
                    "| (Type 'h' or 'help' for help menu) |\n" +
                    "+------------------------------------+";
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

        public static string BattleMessage()
        {

            return "\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n" +
                    ">        Battle has initiated        <\n" +
                    "<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<";
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

        public enum EChoiceType
        {
            Battle,
            Command,
            Container,
            Dialogue,
            Item
        }
        public enum EState
        {
            Base,
            Battle,
            Inventory,
            Move
        }

        public static object? CallByName<T>(T a, string name, object[] paramsToPass)
        {
            //Search public methods
            MethodInfo? method = a!.GetType().GetMethod(name);
            if (method == null)
            {
                Console.WriteLine($"Method {name} not found on type {a.GetType()}.");
                return null;
            }
            else
            {
                object? result = method.Invoke(a, paramsToPass);
                return result;
            }
        }
    }
}
