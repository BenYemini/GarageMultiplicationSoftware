using Ex03.GarageLogic;
using Ex03.GarageLogic.eNumsForGarage;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        public static string GetLicensePlate()
        {
            System.Console.WriteLine("Please enter a valid license plate:");
            string licensePlate = System.Console.ReadLine();

            return licensePlate;
        }

        public static void RenderVehicleIsInTheGarageMSG()
        {
            System.Console.WriteLine("The Vehicle is in the garage already. We have changed his state to 'Under Repair'.");
        }

        public static string GetUserChoiseForFunction()
        {
            string userChoise;

            System.Console.WriteLine("Please select one of the options:");
            userChoise = System.Console.ReadLine();

            return userChoise;
        }

        public static void RenderWelcomeMSG()
        {
            System.Console.WriteLine("Welcome to Ben & Ariel's Garage!");
            System.Console.WriteLine();

        }

        public static void RenderGarageMenu(Dictionary<int, string> i_GarageMenu)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Check out our menu: ");
            foreach (var option in i_GarageMenu)
            {
                Console.WriteLine($"{option.Key}: {option.Value}");
            }
        }

        public static string GetIntegerUserChoiseFromMultipleOptions(Dictionary<int, string> i_DictionaryOfOptions)
        {
            string optionChoise = "";

            System.Console.WriteLine("Here are the options to choose from, please type the integer of a valid option:");
            foreach (var option in i_DictionaryOfOptions)
            {
                Console.WriteLine($"{option.Key}: {option.Value}");
            }
            optionChoise = System.Console.ReadLine();

            return optionChoise;
        }

        public static void PresentVehiclesToUser(List<string> i_VehiclesToRender)
        {
            foreach (string licensePlate in i_VehiclesToRender)
            {
                System.Console.WriteLine(string.Format("Car with license plate {0} is in the garage.", licensePlate));
                Console.WriteLine();
            }
        }

        public static string GetUserChoiseForFilterOrNot()
        {
            System.Console.WriteLine("Would you like to filter it by certain type? (Y/N)");
            string userChoise = System.Console.ReadLine();

            return userChoise;
        }

        public static void InformUserVehicleIsNotInTheGarage()
        {
            System.Console.WriteLine("This vehicle is not in the garage!");
        }

        public static void PresentVehicleInfo(GarageCarCard vehicleCard)
        {
            System.Console.WriteLine(vehicleCard.ToString());
        }

        public static string GetFloatValue(string i_TypeOfFloatToGet)
        {
            System.Console.WriteLine(string.Format("Type the {0} you would like to add (Float value): ", i_TypeOfFloatToGet));
            string userChoise = System.Console.ReadLine();

            return userChoise;
        }

        public static string GetStringValue(string i_StringToGet)
        {
            System.Console.WriteLine(string.Format("Please enter {0}", i_StringToGet));
            string stringToReturn = System.Console.ReadLine();

            return stringToReturn;
        }

        public static void RenderCarAddedMsg()
        {
            System.Console.WriteLine("The vehicle was added to our garage and will be fixed soon :)");
            System.Console.WriteLine();
        }

        internal static void renderVehicleTypeDoesntMatch()
        {
            System.Console.WriteLine("The vehicle type doesn't match the method you chose..");
            System.Console.WriteLine();
        }

        internal static void renderInvalidChoise()
        {
            System.Console.WriteLine("One or more of you're choices is not valid..");
            System.Console.WriteLine();
        }
    }
}