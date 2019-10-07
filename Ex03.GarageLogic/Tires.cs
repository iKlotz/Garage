using System.Text;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Tires
    {
        private readonly float r_MaxPsi = 0;
        private string m_Manufacturer = null;
        private float m_CurrentPsi = 0;
        
        internal Tires(string i_Manufacturer, float i_CurrentPsi, float i_MaxPsi)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentPsi = i_CurrentPsi;
            r_MaxPsi = i_MaxPsi;
        }

        internal string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }
        }

        internal void InflateTireToMaximum()
        {
            m_CurrentPsi = r_MaxPsi;
        }

        internal void PumpAir(float i_AirToBeAdded)
        {
            if(i_AirToBeAdded + m_CurrentPsi > r_MaxPsi)
            {
                throw new ValueOutOfRangeException(r_MaxPsi, 0);
            }

            m_CurrentPsi += i_AirToBeAdded;
        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();

            vehicleString.AppendLine(string.Empty + m_CurrentPsi);

            return vehicleString.ToString();
        }
    }
}
