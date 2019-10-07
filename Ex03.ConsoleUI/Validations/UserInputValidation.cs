using System;

namespace Ex03.ConsoleUI.Validations
{
    internal class UserInputValidation
    {
        public static int GetValidMenuOptionFromUser(Type i_EnumElement)
        {
            int userInput = ParseUserInputToInt();

            while (!Enum.IsDefined(i_EnumElement, userInput))
            {
                UserMessages.IncorrectMenuOptionMessage();
                userInput = ParseUserInputToInt();
            }

            return userInput;
        }

        public static int ParseUserInputToInt()
        {
            string userInput = Console.ReadLine();
            int userInputAsInt;

            while (!int.TryParse(userInput, out userInputAsInt))
            {
                UserMessages.IncorrectMenuOptionMessage();
                userInput = Console.ReadLine();
            }

            return userInputAsInt;
        }


        public static float GetEnergyPercentageStatusFromUser()
        {
            UserMessages.EnterCurrentEnergyPercentageMsg();
            string currentPercentageInput = Console.ReadLine();

            float givenPercentage;

            while (!float.TryParse(currentPercentageInput, out givenPercentage) || !(givenPercentage >= 0 && givenPercentage <= 100))
            {
                UserMessages.PleaseEnterValidPercentageMsg();
                currentPercentageInput = Console.ReadLine();
            }

            return givenPercentage;
        }


        public static bool YesOrNoAnswer()
        {
            string userInput = Console.ReadLine();
            bool yesOrNoBool = userInput.Equals("Yes");

            if (userInput.Equals("No"))
            {
                yesOrNoBool = false;
            }
            else if(!yesOrNoBool)
            {
                UserMessages.EnterYesOrNoOnlyMsg();
                yesOrNoBool = YesOrNoAnswer();
            }

            return yesOrNoBool;
        }

        public static float ParseUserInputToFloat()
        {
            string userInput = Console.ReadLine();
            float parseUserInputToFloat;

            while (!float.TryParse(userInput, out parseUserInputToFloat))
            {
                UserMessages.IncorrectMenuOptionMessage();
                userInput = Console.ReadLine();
            }

            return parseUserInputToFloat;
        }

        public static string GetPhoneNumberFromUser()
        {
            UserMessages.EnterYourPhoneNumberMsg();
            string userNumber = Console.ReadLine();
            bool allDigits = true;

            foreach(char digit in userNumber)
            {
                if(!int.TryParse(digit.ToString(), out int checkDigits))
                {
                    allDigits = false;
                }
            }

            if(!allDigits)
            {
                UserMessages.IncorrectPhoneNumberMsg();
                GetPhoneNumberFromUser();
            }

            return userNumber;
        }
    }
}
