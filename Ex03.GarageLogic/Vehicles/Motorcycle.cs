using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Motorcycle : Vehicle
    {
        public static readonly int sr_NumberOfTires = 2;
        public static readonly int sr_MaxPsiLevel = 33;

        private int m_EngineVolume = 0;
        private eMotorcycleLicenseType m_LicenseType;

        protected Motorcycle(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, string i_OwnerName, string i_PhoneNumber, eVehicleGarageStatus i_VehicleStatus)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_OwnerName, i_PhoneNumber, i_VehicleStatus)
        {
        }

        internal eMotorcycleLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        internal int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();

            vehicleString.Append(base.ToString());
            vehicleString.AppendLine("Engine Volume : " + m_EngineVolume);
            vehicleString.AppendLine("License Type : " + m_LicenseType);

            return vehicleString.ToString();
        }
    }
}
