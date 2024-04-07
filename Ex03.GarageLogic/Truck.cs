using System.Text;


namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_CoolingEnabled;
        private float m_CargoVolume;

        public Truck(string i_LicensePlate, Engine i_Engine, Wheel[] i_Wheels) : base(i_LicensePlate, i_Engine, i_Wheels)
        {
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value;}
        }

        public bool CoolingEnabled
        {
            get { return m_CoolingEnabled; }
            set { m_CoolingEnabled = value;}
        }

        public override string ToString()
        {
            StringBuilder truckStringB = new StringBuilder();

            truckStringB.AppendLine(base.ToString());
            truckStringB.AppendLine("Truck's Data:");
            truckStringB.AppendLine(string.Format("Does Cooling Enabled: {0} | Cargo Volume: {1}", CoolingEnabled, CargoVolume));

            return truckStringB.ToString();
        }
    }
}
