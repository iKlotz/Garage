using System;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Car : Vehicle
    {
        public static readonly int sr_NumberOfTires = 4;
        public static readonly int sr_MaxPsiLevel = 31;

        private eCarColors m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        protected Car(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, string i_OwnerName, string i_PhoneNumber, eVehicleGarageStatus i_VehicleStatus)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_OwnerName, i_PhoneNumber, i_VehicleStatus)
        {
        }

        internal eCarColors Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        internal eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();

            vehicleString.Append(base.ToString());
            vehicleString.AppendLine("Car Color : " + m_Color);
            vehicleString.AppendLine("Number of Doors : " + m_NumberOfDoors);

            return vehicleString.ToString();
        }
    }
}
