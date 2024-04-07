namespace Ex03.ConsoleUI
{

    // This class is where the ValidityChecks happens.
    // Make sure to throw all 3 Exceptions *always!* (ValueInRange Argument Formating).
    // You should use Objects comparison and checks wether object is from some type here (its mandatory).

    // use Garage dictionaries for the checks.
    public class InputValidityChecks
    {
        public static bool ValidateLicensePlate(string i_LicensePlate)
        {
            bool licensePlateIsValid = i_LicensePlate != null;

            return licensePlateIsValid;
        }

        public static bool ValidateUserChoiseForFunction(string i_UserChoise)
        {
            bool userChoiseIsValid = false;
            int o_intUserChoise = 0;

            userChoiseIsValid = int.TryParse(i_UserChoise, out o_intUserChoise);

            return userChoiseIsValid;
        }

        public static bool ValidateIntegerUserChoiseFromMultipleOptions(string i_UserChoise, Dictionary<int, string> i_DictionaryOfOptions, ref int io_IntUserChoiseForFilter)
        {
            int numOfKeys = i_DictionaryOfOptions.Count;
            bool userChoiseIsInValidFormat = int.TryParse(i_UserChoise, out io_IntUserChoiseForFilter);
            bool userChoiseInValidRange = (io_IntUserChoiseForFilter <= numOfKeys) && (io_IntUserChoiseForFilter > 0);
            bool userChoiseIsValid = userChoiseIsInValidFormat && userChoiseInValidRange;

            return userChoiseIsValid;
        }

        public static bool ValidateUserChoiseForFilterPresentation(string i_UserChoise)
        {
            bool userChoiseIsValid = i_UserChoise.ToLower() == "y" || i_UserChoise.ToLower() == "n";

            return userChoiseIsValid;
        }
    }
}
