using Ex03.GarageLogic.eNumsForGarage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        private eFuelType m_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_MaxEnergy) : base(i_MaxEnergy)
        {
            m_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }
        public void AddEnergy(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != FuelType)
            {
                throw new ArgumentException("Fuel type does not match.");
            }

            float fuelAfterRefuel = i_FuelToAdd + CurrentEnergy;
            CurrentEnergy = fuelAfterRefuel;
        }

        public override string ToString()
        {
            StringBuilder engineStringB = new StringBuilder();

            engineStringB.AppendLine(base.ToString());
            engineStringB.AppendLine("Fuel Engine's Data: ");
            engineStringB.AppendLine(string.Format("Fuel Type: {0}", FuelType));
            
            return engineStringB.ToString();
        }
    }
}
