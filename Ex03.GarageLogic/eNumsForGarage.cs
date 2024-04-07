using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    namespace eNumsForGarage
    {
        public enum eVehicleState
        {
            UnderRepair,
            Fixed,
            Paid
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public enum eMotorcycleLicenseType
        {
            A,
            A1,
            A2,
            AB
        }

        public enum eCarColor
        {
            Black,
            White,
            Red,
            Blue
        }

        public enum eNumberOfDoors
        {
            TwoDoors = 2,
            ThreeDoors = 3,
            FourDoors = 4,
            FiveDoors = 5
        }

        public enum eVehicleType
        {
            RegularCar,
            ElectricCar,
            RegularMotorcycle,
            ElectricMotorcycle,
            Truck
        }
    }
}
