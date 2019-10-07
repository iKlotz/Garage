using System.Text;
using Ex03.GarageLogic.Engine;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    public class FuelBasedTruck : Truck
    {
        private const float k_MaximumFuelInTankByLiter = 110f;
        private readonly eEnergyTypes m_FuelType = eEnergyTypes.Soler;

        public FuelBasedTruck(
            string i_ModelName,
            string i_LicenseNumber,
            float i_RemainingEnergyPercentage,
            string i_OwnerName,
            string i_PhoneNumber,
            eVehicleGarageStatus i_VehicleStatus)
            : base(
                i_ModelName,
                i_LicenseNumber,
                i_RemainingEnergyPercentage,
                i_OwnerName,
                i_PhoneNumber,
                i_VehicleStatus)
        {
            float currentEnergy = (RemainingEnergyPercentage / 100f) * k_MaximumFuelInTankByLiter;
            m_VehicleEngine = new FuelEngine(m_FuelType, currentEnergy, k_MaximumFuelInTankByLiter);
        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();

            vehicleString.Append(base.ToString());

            return vehicleString.ToString();
        }
    }
}