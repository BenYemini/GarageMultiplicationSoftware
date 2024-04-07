using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eNumsForGarage;

namespace Ex03.GarageLogic
{
    namespace Dictionaries
    {
        internal static class GarageDictionaries
        {
            internal static readonly Dictionary<eVehicleType, int> sr_VehicleNumberOfWheels = new Dictionary<eVehicleType, int>()
            {
                { eVehicleType.ElectricCar, 5 },
                { eVehicleType.RegularCar, 5 },
                { eVehicleType.ElectricMotorcycle, 2 },
                { eVehicleType.RegularMotorcycle, 2 },
                { eVehicleType.Truck, 12}
            };

            internal static readonly Dictionary<eVehicleType, float> sr_VehicleWheelMaximalAirPressure = new Dictionary<eVehicleType, float>()
            {
                { eVehicleType.ElectricCar, 32 },
                { eVehicleType.RegularCar, 32 },
                { eVehicleType.ElectricMotorcycle, 30 },
                { eVehicleType.RegularMotorcycle, 30 },
                { eVehicleType.Truck, 27}
            };

            internal static readonly Dictionary<eVehicleType, eFuelType> sr_VehicleFuelType = new Dictionary<eVehicleType, eFuelType>()
            {
                {eVehicleType.RegularCar, eFuelType.Octan95},
                {eVehicleType.RegularMotorcycle, eFuelType.Octan98},
                {eVehicleType.Truck, eFuelType.Soler}
            };

            internal static readonly Dictionary<eVehicleType, float> sr_MaxEngineCapacity = new Dictionary<eVehicleType, float>()
            {
                { eVehicleType.RegularCar, 44f },
                { eVehicleType.ElectricCar, 5.2f },
                { eVehicleType.RegularMotorcycle, 6.2f },
                { eVehicleType.ElectricMotorcycle, 2.4f },
                { eVehicleType.Truck, 130f }
            };

            internal static readonly Dictionary<int, string> sr_UserChoiseToAction = new Dictionary<int, string>()
            {
                {1, "Add new vehicle"},
                {2, "Present garage vehicles"},
                {3, "Change vehicle state"},
                {4, "Add Maximal air pressure to wheels"},
                {5, "Add fuel to the vehicle"},
                {6, "Add electric power to the vehicle"},
                {7, "Present vehicle info"},
                {8, "Quit"}
            };

            internal static Dictionary<int, string> s_VehicleStates = createVehicleStatesDictionary();

            internal static Dictionary<int, string> createVehicleStatesDictionary()
            {
                Dictionary<int, string> vehicleStates = new Dictionary<int, string>();
                int key = 1;

                foreach (eVehicleState value in Enum.GetValues(typeof(eVehicleState)))
                {
                    vehicleStates.Add(key, value.ToString());
                    key++;
                }

                return vehicleStates;
            }

            internal static Dictionary<int, string> s_FuelTypes = CreateFuelTypesDictionary();

            internal static Dictionary<int, string> CreateFuelTypesDictionary()
            {
                Dictionary<int, string> fuelTypes = new Dictionary<int, string>();
                int key = 1;

                foreach (eFuelType value in Enum.GetValues(typeof(eFuelType)))
                {
                    fuelTypes.Add(key, value.ToString());
                    key++;
                }

                return fuelTypes;
            }

            internal static Dictionary<int, string> s_VehicleTypes = CreateVehicleTypesDictionary();

            internal static Dictionary<int, string> CreateVehicleTypesDictionary()
            {
                Dictionary<int, string> vehicleTypes = new Dictionary<int, string>();
                int key = 1;

                foreach (eVehicleType value in Enum.GetValues(typeof(eVehicleType)))
                {
                    vehicleTypes.Add(key, value.ToString());
                    key++;
                }

                return vehicleTypes;
            }

            internal static Dictionary<int, string> s_CarColorTypes = CreateCarColorTypesDictionary();

            internal static Dictionary<int, string> CreateCarColorTypesDictionary()
            {
                Dictionary<int, string> carColors = new Dictionary<int, string>();
                int key = 1;

                foreach (eCarColor value in Enum.GetValues(typeof(eCarColor)))
                {
                    carColors.Add(key, value.ToString());
                    key++;
                }

                return carColors;
            }

            internal static Dictionary<int, string> s_NumberOfDoors = CreateNumberOfDoorsDictionary();

            internal static Dictionary<int, string> CreateNumberOfDoorsDictionary()
            {
                Dictionary<int, string> numOfDoors = new Dictionary<int, string>();
                int key = 1;

                foreach (eNumberOfDoors value in Enum.GetValues(typeof(eNumberOfDoors)))
                {
                    numOfDoors.Add(key, value.ToString());
                    key++;
                }

                return numOfDoors;
            }

            internal static Dictionary<int, string> s_LicenseTypes = CreateLicenseTypesDictionary();

            internal static Dictionary<int, string> CreateLicenseTypesDictionary()
            {
                Dictionary<int, string> licenseTypes = new Dictionary<int, string>();
                int key = 1;

                foreach (eMotorcycleLicenseType value in Enum.GetValues(typeof(eMotorcycleLicenseType)))
                {
                    licenseTypes.Add(key, value.ToString());
                    key++;
                }

                return licenseTypes;
            }
        }
    }
}
