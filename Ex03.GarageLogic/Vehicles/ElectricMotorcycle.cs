using System.Text;
using Ex03.GarageLogic.Engine;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaximumChargeTimeOfBattery = 1.4f;

        internal ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, string i_OwnerName, string i_PhoneNumber, eVehicleGarageStatus i_VehicleStatus)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_OwnerName, i_PhoneNumber, i_VehicleStatus)
        {
            float currentEnergy = (RemainingEnergyPercentage / 100f) * k_MaximumChargeTimeOfBattery;
            m_VehicleEngine = new ElectricEngine(currentEnergy, k_MaximumChargeTimeOfBattery);
        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();

            vehicleString.Append(base.ToString());

            return vehicleString.ToString();
        }
    }
}
