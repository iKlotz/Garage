using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private string m_VehicleOwnerName = null;
        private string m_VehicleOwnerPhoneNumber = null;
        private eVehicleGarageStatus m_VehicleGarageStatus;

        private string m_ModelName = null;
        private string m_LicenseNumber = null;
        private float m_RemainingEnergy = 0;
        private List<Tires> m_Tires = null;

        protected Engine.Engine m_VehicleEngine;

        protected Vehicle(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, string i_OwnerName, string i_PhoneNumber, eVehicleGarageStatus i_VehicleStatus )
        {
            m_VehicleOwnerName = i_OwnerName;
            m_VehicleOwnerPhoneNumber = i_PhoneNumber;
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergy = i_RemainingEnergyPercentage;
            m_Tires = new List<Tires>();
            m_VehicleGarageStatus = i_VehicleStatus;
        }

        internal string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        internal string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        internal float RemainingEnergyPercentage
        {
            get
            {
                return m_RemainingEnergy;
            }

            set
            {
                m_RemainingEnergy = value;
            }
        }

        internal string OwnerName
        {
            get
            {
                return m_VehicleOwnerName;
            }

            set
            {
                m_VehicleOwnerName = value;
            }
        }

        internal string PhoneNumber
        {
            get
            {
                return m_VehicleOwnerPhoneNumber;
            }

            set
            {
                m_VehicleOwnerPhoneNumber = value;
            }
        }

        internal List<Tires> Tires
        {
            get
            {
                return m_Tires;
            }

            set
            {
                m_Tires = value;
            }
        }

        internal eVehicleGarageStatus VehicleStatus
        {
            get
            {
                return m_VehicleGarageStatus;
            }

            set
            {
                m_VehicleGarageStatus = value;
            }
        }

        internal Engine.Engine VehicleEngine
        {
            get
            {
                return m_VehicleEngine;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();
            
            vehicleString.AppendLine("Model Name : " + LicenseNumber);
            vehicleString.AppendLine("Owner Name : " + OwnerName);
            vehicleString.AppendLine("Phone Number : " + PhoneNumber);
            vehicleString.AppendLine("Status in Garage : " + VehicleStatus);
            vehicleString.AppendLine("Tire Manufacturer : " + Tires[0].Manufacturer);
            int tireNumber = 1;

            vehicleString.Append(m_VehicleEngine.ToString());

            foreach (Tires tire in Tires)
            {
                vehicleString.Append(string.Format("Tires {0} PSI: {1}", tireNumber, tire.ToString()));
                tireNumber++;
            }
            
            return vehicleString.ToString();
        }
    }
}