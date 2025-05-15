using static Foundation.Globals;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventureGame.Game
{
    public class GameGlobals
    {
        public static string PresentMenu(string question, EChoiceType choiceType, List<string> optionNums, List<string> optionChoices)
        {
            string outputMessage = string.Empty;

            if (string.IsNullOrEmpty(question))
            {
                outputMessage = "\nNo question was supplied.";
            }
            else if (optionNums.Count == 0 || optionChoices.Count == 0)
            {
                outputMessage = "\nNo options supplied.";
            }
            else if (optionNums.Count != optionChoices.Count)
            {
                outputMessage = "\nOption counts don't match.";
            }
            else
            {
                outputMessage += question;
                for (int i = 0; i < optionNums.Count; i++)
                {
                    outputMessage += $"\n{optionNums[i]} - {optionChoices[i]}";
                }

                switch (choiceType)
                {
                    case EChoiceType.Battle:
                        outputMessage += $"\n{BattleChoice()}";
                        break;
                    case EChoiceType.Command:
                        outputMessage += $"\n{CommandChoice()}";
                        break;
                    case EChoiceType.Container:
                        outputMessage += $"\n{ContainerChoice()}";
                        break;
                    case EChoiceType.Dialogue:
                        outputMessage += $"\n{DialogueChoice()}";
                        break;
                    case EChoiceType.Item:
                        outputMessage += $"\n{ItemChoice()}";
                        break;
                }
            }

            return outputMessage;
        }

        public static string ReadInput(List<string> optionNums, out int userChoice)
        {
            bool isError = false;
            string errorMessage = string.Empty;
            string choiceString = Console.ReadLine() ?? "";

            if (string.IsNullOrEmpty(choiceString))
            {
                errorMessage = "\nInvalid input.";
                isError = true;
            }
            else
            {
                if (!optionNums.Contains(choiceString))
                {
                    errorMessage = "\nInvalid choice.";
                    isError = true;
                }
            }

            if (isError)
            {
                userChoice = int.MinValue;
            }
            else
            {
                userChoice = int.Parse(choiceString);
            }
            return errorMessage;
        }
    }
}
