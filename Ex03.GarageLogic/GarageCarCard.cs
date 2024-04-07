using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eNumsForGarage;

namespace Ex03.GarageLogic
{
    public class GarageCarCard
    {
        private Vehicle m_vehicle;
        private readonly string r_OwnersName;
        private readonly string r_OwnersPhoneNumber;
        private eVehicleState m_VehicleState = eVehicleState.UnderRepair;

        public GarageCarCard(Vehicle vehicle, string ownersName, string ownersPhoneNumber)
        {
            m_vehicle = vehicle;
            r_OwnersName = ownersName;
            r_OwnersPhoneNumber = ownersPhoneNumber;
        }

        public eVehicleState VehicleState
        {
            get { return m_VehicleState; }
            set
            {
                m_VehicleState = value;
            }
        }

        public string OwnersName
        {
            get { return r_OwnersName; }
        }

        public string OwnersPhoneNumber
        {
            get { return r_OwnersPhoneNumber; }
        }

        public Vehicle Vehicle
        {
            get { return m_vehicle; }
        }

        public override string ToString()
        {
            StringBuilder cardStringBuilder = new StringBuilder();

            cardStringBuilder.AppendLine("Garage Car Card Data: ");
            cardStringBuilder.AppendLine(string.Format(
                "Veihcle State: {0} | Owners Name: {1} | Owner's Phone Number: {2}", VehicleState, OwnersName,
                OwnersPhoneNumber));
            cardStringBuilder.AppendLine();
            if (Vehicle is Car)
            {
                cardStringBuilder.AppendLine((Vehicle as Car).ToString());
            }
            else if (Vehicle is Motorcycle)
            {
                cardStringBuilder.AppendLine((Vehicle as Motorcycle).ToString());
            }
            else if (Vehicle is Truck)
            {
                cardStringBuilder.AppendLine((Vehicle as Truck).ToString());
            }
            else
            {
                cardStringBuilder.AppendLine(Vehicle.ToString());
            }

            cardStringBuilder.AppendLine();

            return cardStringBuilder.ToString();
        }
    }
}
