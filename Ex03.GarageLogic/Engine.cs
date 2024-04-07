using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eNumsForGarage;

namespace Ex03.GarageLogic
{
    public abstract class Engine 
    {
        private float m_CurrentEnergy;
        private readonly float r_MaximalEnergy;
        private readonly float m_MinimalEnergy = 0; // Here For maintance reasons.

        protected Engine(float i_MaxEnergy)
        {
            r_MaximalEnergy = i_MaxEnergy;
        }

        public float CurrentEnergy {
            get { return m_CurrentEnergy;}
            set
            {
                if (value >= MinimalEnergy && value <= MaximalEnergy)
                {
                    m_CurrentEnergy = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("Engine's capacity ", MinimalEnergy, MaximalEnergy);
                }
            }
        }

        public float MaximalEnergy {
            get { return r_MaximalEnergy;}
        }

        public float MinimalEnergy {
            get { return m_MinimalEnergy; }
        }

        public override string ToString()
        {
            StringBuilder engineStringB = new StringBuilder();
            engineStringB.AppendLine("Engine's Data: ");
            if (this is FuelEngine)
            {
                engineStringB.Append("Engine is fuel engine |");
            }
            else
            {
                engineStringB.Append("Engine is electric engine |");
            } 
            engineStringB.AppendLine(string.Format("Maximal Energy: {0} | Current Energy: {1}", MaximalEnergy, CurrentEnergy));

            return engineStringB.ToString();
        }
    }
}
