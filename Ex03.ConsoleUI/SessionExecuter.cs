namespace Ex03.ConsoleUI
{   
    public class SessionExecuter
    {
        private Ex03.GarageLogic.Garage m_Garage;

        public Garage Garage
        {
            get { return m_Garage;}
        }
     
        public SessionExecuter()
        {
            m_Garage = new Garage();
        }

        public void StartSessionWithUser()
        {
            bool userWantsToQuit = false;
            UserInterface.RenderWelcomeMSG();
            while (!userWantsToQuit)
            {
                try
                {
                    UserInterface.RenderGarageMenu(GarageDictionaries.sr_UserChoiseToAction);
                    string UserChoise = GarageDictionaries.sr_UserChoiseToAction[HandleIO.GetUserChoiseForFunction()];
                    switch (UserChoise)
                    {
                        case "Add new vehicle":
                            executeAddNewVehicle();
                            break;
                        case "Present garage vehicles":
                            executePresentVehicles();
                            break;
                        case "Change vehicle state":
                            executeChangeVehicleState();
                            break;
                        case "Add Maximal air pressure to wheels":
                            executeAddMaximalAirPressureToWheels();
                            break;
                        case "Add fuel to the vehicle":
                            executeAddFuelToVehicle();
                            break;
                        case "Add electric power to the vehicle":
                            executeAddElectricPowerToVehicle();
                            break;
                        case "Present vehicle info":
                            executePresentVehicleInfo();
                            break;
                        case "Quit":
                            userWantsToQuit = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    UserInterface.renderInvalidChoise();
                }
               
            }
        }

        private void executeAddNewVehicle(){
            string licensePlate = HandleIO.GetLicensePlate();
            Vehicle newVehicle;
            GarageCarCard newVehiclesCard;
            bool vehicleIsInTheGarage = Garage.CheckIfVehicleIsInGarage(licensePlate);

            if (vehicleIsInTheGarage){
                UserInterface.RenderVehicleIsInTheGarageMSG();
                Garage.SwitchVehicleState(licensePlate, eVehicleState.UnderRepair); 
            }
            else
            {
                eVehicleType o_VehicleTypeToAdd;
                Enum.TryParse(HandleIO.GetUserChoiseFromMultipleOptions(GarageDictionaries.s_VehicleTypes), out o_VehicleTypeToAdd);

                newVehicle = VehiclesObjectsCreation.CreateNewVehicle(licensePlate, o_VehicleTypeToAdd);
                setPropertiesForNewVehicle(newVehicle, o_VehicleTypeToAdd);
                GarageCarCard vehicleCard = createNewCard(newVehicle);
                Garage.AddCarCard(vehicleCard);
            }
        }

        private void executePresentVehicles(){
            List<string> vehiclesToPresent;
            bool userWantsTofilter = HandleIO.CheckIfUserWantsToFilter();
            
            if (userWantsTofilter)
            {
                string stateToFilterFrom = HandleIO.GetUserChoiseFromMultipleOptions(GarageDictionaries.s_VehicleStates);
                vehiclesToPresent = Garage.GetVehiclesForPresentingToUser(stateToFilterFrom);
            }
            else
            {
                vehiclesToPresent = Garage.GetVehiclesForPresentingToUser();
            }
            UserInterface.PresentVehiclesToUser(vehiclesToPresent);
        }

        private void executeChangeVehicleState(){
            eVehicleState o_eNewVehicleState;
            string licensePlate = HandleIO.GetLicensePlate();
            bool vehicleIsInTheGarage = Garage.CheckIfVehicleIsInGarage(licensePlate);

            if (vehicleIsInTheGarage){
                Enum.TryParse(HandleIO.GetUserChoiseFromMultipleOptions(GarageDictionaries.s_VehicleStates), out o_eNewVehicleState);
                Garage.SwitchVehicleState(licensePlate, o_eNewVehicleState); 
            }
            else
            {
                UserInterface.InformUserVehicleIsNotInTheGarage();
            }
        }

        private void executeAddMaximalAirPressureToWheels()
        {
            string licensePlate = HandleIO.GetLicensePlate();
            bool vehicleIsInTheGarage = Garage.CheckIfVehicleIsInGarage(licensePlate);

            if (vehicleIsInTheGarage)
            {
                Garage.AddMaximalAirPressure(licensePlate);
            }
            else
            {
                UserInterface.InformUserVehicleIsNotInTheGarage();
            }
        }

        private void executeAddFuelToVehicle()
        {
            string licensePlate = HandleIO.GetLicensePlate();
            bool vehicleIsInTheGarage = Garage.CheckIfVehicleIsInGarage(licensePlate);
            eFuelType o_FuelTypeToAdd;

            if (vehicleIsInTheGarage){
                bool vehicleIsFuelType = Garage.CheckIfVehicleIsFuelType(licensePlate);
                if (vehicleIsFuelType)
                {
                    Enum.TryParse(HandleIO.GetUserChoiseFromMultipleOptions(GarageDictionaries.s_FuelTypes), out o_FuelTypeToAdd);
                    bool vehicleIsOfTheSameFuelType = Garage.CheckIfVehicleIsOfTheSameFuelType(licensePlate, o_FuelTypeToAdd);

                    if (vehicleIsOfTheSameFuelType)
                    {
                        float amountOfEnergyToAdd = HandleIO.GetFloatValue("Amount Of Energy");
                        Garage.AddEnergyToVehicle(licensePlate, amountOfEnergyToAdd);
                    }
                    else
                    {
                        UserInterface.renderVehicleTypeDoesntMatch();
                    }
                }
                else
                {
                    UserInterface.renderVehicleTypeDoesntMatch();
                }
            }
            else
            {
                UserInterface.InformUserVehicleIsNotInTheGarage();
            }
        }

        private void executeAddElectricPowerToVehicle()
        {
            string licensePlate = HandleIO.GetLicensePlate();
            bool vehicleIsInTheGarage = Garage.CheckIfVehicleIsInGarage(licensePlate);

            if (vehicleIsInTheGarage)
            {
                bool vehicleIsElectricType = Garage.CheckIfVehicleIsElectricType(licensePlate);
                if (vehicleIsElectricType)
                {
                    float hoursToAdd = HandleIO.GetFloatValue("Amount Of Energy");
                    Garage.AddEnergyToVehicle(licensePlate, hoursToAdd);
                }
                else
                {
                    UserInterface.renderVehicleTypeDoesntMatch();
                }
            }
            else
            {
                UserInterface.InformUserVehicleIsNotInTheGarage();
            }
        }

        private void executePresentVehicleInfo()
        {
            Dictionary<string, string> vehicleProperties;
            string licensePlate = HandleIO.GetLicensePlate();
            bool vehicleIsInTheGarage = Garage.CheckIfVehicleIsInGarage(licensePlate);

            if (vehicleIsInTheGarage)
            {
                GarageCarCard vehicleCard = Garage.GetVehicleCard(licensePlate);
                UserInterface.PresentVehicleInfo(vehicleCard);
            }
            else
            {
                UserInterface.InformUserVehicleIsNotInTheGarage();
            }
        }

        private static void setPropertiesForNewVehicle(Vehicle i_NewVehicle, eVehicleType i_VehicleType)
        {
            bool isElectric = (i_VehicleType == eVehicleType.ElectricCar ||
                               i_VehicleType == eVehicleType.ElectricMotorcycle);
            setGeneralVehicleProperties(i_NewVehicle);
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                case eVehicleType.RegularCar:
                    setCarProperties(i_NewVehicle);
                    break;
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.RegularMotorcycle:
                    setMotorcycleProperties(i_NewVehicle);
                    break;
                case eVehicleType.Truck:
                    setTruckProperties(i_NewVehicle);
                    break;
            }
        }

        private static void setGeneralVehicleProperties(Vehicle i_NewVehicle)
        {
            string modelName = HandleIO.GetStringValue("Model Name");
            float energyPercentage = HandleIO.GetFloatValue("Energy Percentage");
            string wheelManufacturer = HandleIO.GetStringValue("Wheel Manufacturer");
            float wheelCurrentAirPressure = HandleIO.GetFloatValue("Wheels current air pressure");
            
            i_NewVehicle.Model = modelName;
            i_NewVehicle.CurrentEnergyPercentage = energyPercentage;

            foreach (Wheel wheel in i_NewVehicle.Wheels)
            {
                wheel.Manufacturer = wheelManufacturer;
                wheel.CurrentAirPressure = wheelCurrentAirPressure;
            }
        }

        private static void setCarProperties(Vehicle i_NewVehicle)
        {
            eCarColor o_CarColor;
            eNumberOfDoors o_NumOfDoors;

            Enum.TryParse(HandleIO.GetUserChoiseFromMultipleOptions(GarageDictionaries.s_CarColorTypes), out o_CarColor);
            Enum.TryParse(HandleIO.GetUserChoiseFromMultipleOptions(GarageDictionaries.s_NumberOfDoors), out o_NumOfDoors);

            (i_NewVehicle as Car).CarColor = o_CarColor;
            (i_NewVehicle as Car).NumberOfDoors = o_NumOfDoors;
        }

        private static void setMotorcycleProperties(Vehicle i_NewVehicle)
        {
            eMotorcycleLicenseType o_LicenseType;
            int engineCapacity;

            Enum.TryParse(HandleIO.GetUserChoiseFromMultipleOptions(GarageDictionaries.s_LicenseTypes), out o_LicenseType);
            engineCapacity = HandleIO.GetIntValue("Engine Capacity");
            (i_NewVehicle as Motorcycle).LicenseType = o_LicenseType;
            (i_NewVehicle as Motorcycle).EngineCapacity = engineCapacity;
        }

        private static void setTruckProperties(Vehicle i_NewVehicle)
        {
            bool coolingEnabled = HandleIO.GetBoolValue("Cooling enabled");
            float cargoVolume = HandleIO.GetFloatValue("Cargo Volume");
            
            (i_NewVehicle as Truck).CoolingEnabled = coolingEnabled;
            (i_NewVehicle as Truck).CargoVolume = cargoVolume;
        }

        private static GarageCarCard createNewCard(Vehicle i_Vehicle)
        {
            string ownersName = HandleIO.GetStringValue("Vehicles owner name");
            string ownersPhoneNumber = HandleIO.GetStringValue("Vehicles owner phone number");
            GarageCarCard vehiclesCard = new GarageCarCard(i_Vehicle, ownersName, ownersPhoneNumber);
            
            return vehiclesCard;
        }
    }
}