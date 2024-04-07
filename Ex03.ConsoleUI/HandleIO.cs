namespace Ex03.ConsoleUI
{
    //This is where all the inputs are managed, YOU CAN NOT Read or Write to the user from here!! Use the UserInterface to do that.
    // From this class we send the inputs back to the SessionExecuter.
    // All the inputs are sent if and only if they are valid, otherwise, the user will be asked to insert another input (use while loop with validity check)
    // As explained above, this is where all the validity checks are called (using InputValidityCheck class).
    // You should use the "try catch" technique here and throw the Exceptions in the InputValiditCheck class.
    // Call Amir Danieli, he explained it to me when we were at your house.

    // This class talks only with UserInterface & InputValidityCheck. 
    public class HandleIO
    {
        public static string GetLicensePlate()
        {
            bool licensePlateIsValid = false;
            string licensePlate = "";

            while(!licensePlateIsValid)
            {
                licensePlate = UserInterface.GetLicensePlate();
                licensePlateIsValid = InputValidityChecks.ValidateLicensePlate(licensePlate);
            }
            
            return licensePlate;
        }

        public static int GetUserChoiseForFunction()
        {
            bool userChoiseIsValid = false;
            string userChoise = "";
            
            while(!userChoiseIsValid)
            {
                userChoise = UserInterface.GetUserChoiseForFunction();
                userChoiseIsValid = InputValidityChecks.ValidateUserChoiseForFunction(userChoise);
            }
            
            return int.Parse(userChoise);
        }

        public static string GetUserChoiseFromMultipleOptions(Dictionary<int, string> i_DictionaryOfOptions)
        {
            int intUserChoiseForFilter = 0;
            bool userChoiseIsValid = false;
            string userInput;
            string userChoise;
            
            while (!userChoiseIsValid)
            {
                userInput = UserInterface.GetIntegerUserChoiseFromMultipleOptions(i_DictionaryOfOptions);
                userChoiseIsValid = InputValidityChecks.ValidateIntegerUserChoiseFromMultipleOptions(userInput, i_DictionaryOfOptions, ref intUserChoiseForFilter);
                if (!userChoiseIsValid)
                {
                    UserInterface.renderInvalidChoise();
                }
            }

            userChoise = i_DictionaryOfOptions[intUserChoiseForFilter];

            return userChoise;
        }

        public static bool CheckIfUserWantsToFilter()
        {
            bool userWantsToFilter = false;
            bool userChoiseIsValid = false;
            string userChoise = "";

            while (!userChoiseIsValid)
            {
                userChoise = UserInterface.GetUserChoiseForFilterOrNot();
                userChoiseIsValid = InputValidityChecks.ValidateUserChoiseForFilterPresentation(userChoise);
            }
            if (userChoise.ToLower() == "y")
            {
                userWantsToFilter = true;
            }

            return userWantsToFilter;
        }

        public static float GetFloatValue(string i_typeOfFloatToGet)
        {
            bool userChoiseIsValid = false;
            float floatValueToReturn = 0;
            string strFloatValueToReturn = "";

            while (!userChoiseIsValid)
            {
                strFloatValueToReturn = UserInterface.GetFloatValue(i_typeOfFloatToGet);
                if (i_typeOfFloatToGet == "Energy Percentage")
                {
                    userChoiseIsValid = float.TryParse(strFloatValueToReturn, out floatValueToReturn);
                    if (!userChoiseIsValid || floatValueToReturn < 0 || floatValueToReturn > 100)
                    {
                        userChoiseIsValid = false;
                    }
                }

                userChoiseIsValid = float.TryParse(strFloatValueToReturn, out floatValueToReturn);
            }

            return floatValueToReturn;
        }

        public static int GetIntValue(string typeOfIntToGet)
        {
            bool userChoiseIsValid = false;
            int intValueToReturn = 0;
            string strIntValueToReturn = "";

            while (!userChoiseIsValid)
            {
                strIntValueToReturn = UserInterface.GetFloatValue(typeOfIntToGet);
                userChoiseIsValid = int.TryParse(strIntValueToReturn, out intValueToReturn);
            }

            return intValueToReturn;
        }

        public static bool GetBoolValue(string typeOfBoolToGet)
        {
            bool userChoiseIsValid = false;
            bool boolValueToReturn = false;
            string strIntValueToReturn = "";

            while (!userChoiseIsValid)
            {
                strIntValueToReturn = UserInterface.GetFloatValue(typeOfBoolToGet);
                userChoiseIsValid = bool.TryParse(strIntValueToReturn, out boolValueToReturn);
            }

            return boolValueToReturn;
        }

        public static string GetStringValue(string i_StringTypeToGet)
        {
            string stringToReturn = UserInterface.GetStringValue(i_StringTypeToGet);

            return stringToReturn;
        }

    }
}