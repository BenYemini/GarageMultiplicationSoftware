using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer = "";
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaximalAirPressure;
        private static readonly float r_MinimalAirPressure = 0; 

        public Wheel(float i_MaximalAirPressure)
        {
            r_MaximalAirPressure = i_MaximalAirPressure;
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value >= 0 && value <= r_MaximalAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("Wheel's air pressure ", MinimalAirPressure, MaximalAirPressure);
                }
            }
        }

        public float MaximalAirPressure
        {
            get { return r_MaximalAirPressure; }
        }

        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set
            {
                m_Manufacturer = value;
            }
        }

        public float MinimalAirPressure
        {
            get { return r_MinimalAirPressure; }
        }

        public void Inflate(float i_AirPressureToAdd)
        {
            float airPressAfterInflation = CurrentAirPressure + i_AirPressureToAdd;
            CurrentAirPressure = airPressAfterInflation;
        }

        public void Inflate()
        {
            CurrentAirPressure = r_MaximalAirPressure;
        }

        public override string ToString()
        {
            StringBuilder wheelStringB = new StringBuilder("");

            wheelStringB.AppendLine("Wheel's Data: ");
            wheelStringB.AppendLine(string.Format(
                "Manufacturer: {0} | Current Air Pressure: {1} | Maximum Air Pressure: {2}", Manufacturer,
                CurrentAirPressure, MaximalAirPressure));

            return wheelStringB.ToString();
        }
    }
}