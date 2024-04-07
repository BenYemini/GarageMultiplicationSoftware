using Ex03.GarageLogic.eNumsForGarage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_LicensePlate, Engine i_Engine, Wheel[] i_Wheels) : base(i_LicensePlate, i_Engine, i_Wheels) { }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value;}
        }

        public eCarColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public override string ToString()
        {
            StringBuilder carStringB = new StringBuilder();
            carStringB.AppendLine(base.ToString());
            carStringB.AppendLine("Car's data: ");
            carStringB.AppendLine(string.Format("Color: {0} | Number Of Doors: {1}", CarColor, NumberOfDoors));

            return carStringB.ToString();
        }
    }
}
