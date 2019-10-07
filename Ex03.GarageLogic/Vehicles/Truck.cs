using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Truck : Vehicle
    {
        public static readonly int sr_NumberOfTires = 12;
        public static readonly float sr_MaxPsiLevel = 26;

        private bool m_HasDangerousMaterials = true;
        private float m_VolumeOfCargo = 0;

        protected Truck(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, string i_OwnerName, string i_PhoneNumber, eVehicleGarageStatus i_VehicleStatus)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_OwnerName, i_PhoneNumber, i_VehicleStatus)
        {
        }

        internal bool IsSafe
        {
            get
            {
                return m_HasDangerousMaterials;
            }

            set
            {
                m_HasDangerousMaterials = value;
            }
        }

        internal float CargoVolume
        {
            get
            {
                return m_VolumeOfCargo;
            }

            set
            {
                m_VolumeOfCargo = value;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();

            vehicleString.Append(base.ToString());
            vehicleString.AppendLine("Contains Dangerous Material : " + IsSafe);
            vehicleString.AppendLine("Cargo Volume : " + CargoVolume);
            
            return vehicleString.ToString();
        }
    }
}
