using Ex03.GarageLogic.Dictionaries;
using Ex03.GarageLogic.eNumsForGarage;

namespace Ex03.GarageLogic
{
    public class VehiclesObjectsCreation
    {
        public static Vehicle CreateNewVehicle(string i_LicensePlate, eVehicleType i_VehicleType)
        {
            Vehicle newVehicle;
            Engine newEngine = createNewEngine(i_VehicleType);
            Wheel[] newWheels = createNewWheels(i_VehicleType);

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    newVehicle = new Car(i_LicensePlate, newEngine as ElectricEngine, newWheels);
                    break;

                case eVehicleType.RegularCar:
                    newVehicle = new Car(i_LicensePlate, newEngine as FuelEngine, newWheels);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new Motorcycle(i_LicensePlate, newEngine as ElectricEngine, newWheels);
                    break;

                case eVehicleType.RegularMotorcycle:
                    newVehicle = new Motorcycle(i_LicensePlate, newEngine as FuelEngine, newWheels);
                    break;

                case eVehicleType.Truck:
                    newVehicle = new Truck(i_LicensePlate, newEngine as FuelEngine, newWheels);
                    break;

                default:
                    newVehicle = null;
                    break;
            }

            return newVehicle;
        }

        private static Engine createNewEngine(eVehicleType i_VehicleType)
        {
            Engine engine = null;
            float maxCapacity = GarageDictionaries.sr_MaxEngineCapacity[i_VehicleType];


            if (i_VehicleType == eVehicleType.ElectricCar || i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                engine = new ElectricEngine(maxCapacity);
            }
            else if (i_VehicleType == eVehicleType.RegularCar || i_VehicleType == eVehicleType.RegularMotorcycle || i_VehicleType == eVehicleType.Truck)
            {
                engine = new FuelEngine(GarageDictionaries.sr_VehicleFuelType[i_VehicleType], maxCapacity);
            }

            return engine;

        }

        private static Wheel[] createNewWheels(eVehicleType i_VehicleType)
        {
            Wheel[] newWheels = new Wheel[GarageDictionaries.sr_VehicleNumberOfWheels[i_VehicleType]];

            for (int i = 0; i < newWheels.Length; i++)
            {
                newWheels[i] = new Wheel(GarageDictionaries.sr_VehicleWheelMaximalAirPressure[i_VehicleType]);
            }

            return newWheels;
        }
    }
}
