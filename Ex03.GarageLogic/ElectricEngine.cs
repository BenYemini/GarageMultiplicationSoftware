using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergy) : base(i_MaxEnergy) { }

        public void AddEnergy(float i_HoursToAdd)
        {
            float hoursAfterRecharge = i_HoursToAdd + CurrentEnergy;
            CurrentEnergy = hoursAfterRecharge;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
