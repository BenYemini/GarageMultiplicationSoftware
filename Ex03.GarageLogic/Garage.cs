using System.Text;
using Ex03.ConsoleUI;
using Ex03.GarageLogic.Dictionaries;
using Ex03.GarageLogic.eNumsForGarage;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<GarageCarCard> m_carCards = new List<GarageCarCard>();

        public List<GarageCarCard> CarCards
        {
            get { return m_carCards; }
        }

        public void AddCarCard(GarageCarCard i_CarCard)
        {
            bool isCardExsist = CheckIfVehicleIsInGarage(i_CarCard.Vehicle.LicensePlate);

            if (!isCardExsist)
            {
                CarCards.Add(i_CarCard);
                UserInterface.RenderCarAddedMsg();
            }
        }

        public void RemoveCarCard(GarageCarCard i_CarCard)
        {
            CarCards.Remove(i_CarCard);
        }

        public GarageCarCard GetVehicleCard(string i_LisencePlate)
        {
            GarageCarCard vehicleCard = null;
            
            foreach (GarageCarCard card in CarCards)
            {
                if (card.Vehicle.LicensePlate == i_LisencePlate)
                {
                    vehicleCard = card;
                    break;
                }
            }

            return vehicleCard;
        }

        public eVehicleType GetVehicleType(string i_LisencePlate)
        {
            eVehicleType vehicleType;
            GarageCarCard vehicleCard = GetVehicleCard(i_LisencePlate);
            Vehicle vehicle = vehicleCard.Vehicle;
            if (vehicle is Car)
            {
                if (vehicle.Engine is ElectricEngine)
                {
                    vehicleType = eVehicleType.ElectricCar;
                }
                
                else
                {
                    vehicleType = eVehicleType.RegularCar;
                }
            }
            
            else if (vehicle is Motorcycle)
            {
                if (vehicle.Engine is ElectricEngine){
                    vehicleType = eVehicleType.ElectricMotorcycle;
                }
                
                else 
                {
                     vehicleType = eVehicleType.RegularMotorcycle;
                }
            }
            
            else
            {
                vehicleType = eVehicleType.Truck;
            }

            return vehicleType;
        }

        public void SwitchVehicleState(string i_LisencePlate, eVehicleState i_NewState)
        {
            GarageCarCard vehicleCard = GetVehicleCard(i_LisencePlate);
            vehicleCard.VehicleState = i_NewState;
        }

        public override string ToString()
        {
            StringBuilder garageStringB = new StringBuilder();

            foreach (GarageCarCard card in CarCards)
            {
                garageStringB.AppendLine(card.ToString());
            }

            return garageStringB.ToString();
        }

        public List<string> GetVehiclesForPresentingToUser(string i_StateToFilterFrom)
        {
            List<string> vehiclesToPresent = new List<string>();

            foreach (GarageCarCard card in CarCards)
            {
                eVehicleState vehicleState = card.VehicleState;
                string vehicleLicensePlate = card.Vehicle.LicensePlate;
                if (vehicleState.ToString() == i_StateToFilterFrom)
                {
                    vehiclesToPresent.Add(vehicleLicensePlate);
                }
            }

            return vehiclesToPresent;
        }

        public List<string> GetVehiclesForPresentingToUser()
        {
            List<string> vehiclesToPresent = new List<string>();

            foreach (GarageCarCard card in CarCards)
            {
                string vehicleLicensePlate = card.Vehicle.LicensePlate;
                vehiclesToPresent.Add(vehicleLicensePlate);
            }

            return vehiclesToPresent;
        }

        public bool CheckIfVehicleIsInGarage(string i_LicensePlate)
        {
            bool vehicleIsInTheGarage = false;
            
            foreach (GarageCarCard card in CarCards)
            {
                if (card.Vehicle.LicensePlate.Equals(i_LicensePlate))
                {
                    vehicleIsInTheGarage = true;
                }
            }

            return vehicleIsInTheGarage;
        }

        public void AddMaximalAirPressure(string i_LicensePlate)
        {
            GarageCarCard vehicleCard = GetVehicleCard(i_LicensePlate);
            Wheel[] vehicleWheels = vehicleCard.Vehicle.Wheels;
            foreach(Wheel wheel in vehicleWheels)
            {
                wheel.Inflate();
            }
        }

        public bool CheckIfVehicleIsFuelType(string i_LicensePlate)
        {
            GarageCarCard vehicleCard = GetVehicleCard(i_LicensePlate);
            Engine vehicleEngine = vehicleCard.Vehicle.Engine;
            bool VehicleIsFuelType = vehicleEngine is FuelEngine;

            return VehicleIsFuelType;
        }

        public bool CheckIfVehicleIsOfTheSameFuelType(string i_LicensePlate, eFuelType i_FuelType)
        {
            GarageCarCard vehicleCard = GetVehicleCard(i_LicensePlate);
            FuelEngine vehicleEngine = vehicleCard.Vehicle.Engine as FuelEngine;
            eFuelType vehicleFuelType = vehicleEngine.FuelType;
            bool vehicleIsOfTheSameFuelType = (vehicleFuelType == i_FuelType);

            return vehicleIsOfTheSameFuelType;
        }

        public void AddEnergyToVehicle(string i_LicensePlate, float i_FuelToAdd)
        {
            GarageCarCard vehicleCard = GetVehicleCard(i_LicensePlate);
            vehicleCard.Vehicle.Engine.CurrentEnergy += i_FuelToAdd;
        }

        public bool CheckIfVehicleIsElectricType(string i_LicensePlate)
        {
            bool vehicleIsElectricType = !(CheckIfVehicleIsFuelType(i_LicensePlate));

            return vehicleIsElectricType;
        }
    }
}