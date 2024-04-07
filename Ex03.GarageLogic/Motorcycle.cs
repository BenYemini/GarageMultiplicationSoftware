using Ex03.GarageLogic.eNumsForGarage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(string i_LicensePlate, Engine i_Engine, Wheel[] i_Wheels) : base(i_LicensePlate, i_Engine, i_Wheels)
        {
        }

        public eMotorcycleLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Engine's Capacity must be positive.");
                }

                m_EngineCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder motorcycleStringB = new StringBuilder();

            motorcycleStringB.Append(base.ToString());
            motorcycleStringB.AppendLine("Motorcycle's Data: ");
            motorcycleStringB.AppendLine(string.Format("License Type: {0} | Engine Capacity: {1}", LicenseType, EngineCapacity));

            return motorcycleStringB.ToString();
        }
    }
}
