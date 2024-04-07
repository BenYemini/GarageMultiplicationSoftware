using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected readonly string r_LicensePlate;
        protected float m_CurrentEnergyPercentage;
        protected Wheel[] m_Wheels;
        protected readonly Engine r_Engine;

        public Vehicle(string i_LicensePlate, Engine i_Engine, Wheel[] i_Wheels)
        {
            r_LicensePlate = i_LicensePlate;
            r_Engine = i_Engine;
            m_Wheels = i_Wheels;
        }

        public string Model
        {
            get { return m_Model; }
            set
            {
                m_Model = value;
            }
        }

        public string LicensePlate
        {
            get { return r_LicensePlate; }
        }

        public Engine Engine
        {
            get { return r_Engine; }
        }

        public Wheel[] Wheels
        {
            get { return m_Wheels; }
            set
            {
                m_Wheels = value;
            }
        }

        public float CurrentEnergyPercentage
        {
            get
            {
                CalcEnergyPercentage();

                return m_CurrentEnergyPercentage;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ValueOutOfRangeException("Engine's Energy percentage ", 0, 100);
                }

                m_CurrentEnergyPercentage = value;
                Engine.CurrentEnergy = Engine.MaximalEnergy * (value / 100);
            }
        }

        public void CalcEnergyPercentage()
        {
            m_CurrentEnergyPercentage = (r_Engine.CurrentEnergy / r_Engine.MaximalEnergy) * 100;
        }

        public override string ToString()
        {
            StringBuilder vehicleStringB = new StringBuilder("");

            vehicleStringB.AppendLine(Engine.ToString());
            vehicleStringB.AppendLine("General Vehicle Data: ");
            vehicleStringB.AppendLine(string.Format(
                "Number Of Wheels: {0} | License Plate: {1} | Energy Percentage: {2}% | Model: {3}", Wheels.Length,
                LicensePlate, CurrentEnergyPercentage, Model));
            vehicleStringB.AppendLine();
            foreach (Wheel wheel in Wheels)
            {
                vehicleStringB.AppendLine(wheel.ToString());
            }

            return vehicleStringB.ToString();
        }
    }
}
