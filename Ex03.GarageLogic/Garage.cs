using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Engine;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_VehiclesInGarage;

        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, Vehicle>();
        }
        
        public void AddNewCarToGarage(Dictionary<string, object> i_VehicleItems)
        {
            m_VehiclesInGarage.Add((string)i_VehicleItems["LicenseNumber"], VehicleFactory.BuildVehicle(i_VehicleItems));
        }

        public Dictionary<string, eVehicleGarageStatus> GetLicenseDictionaryByStatus(bool i_GetAllVehicles, eVehicleGarageStatus i_EVehicleGarageStatus = eVehicleGarageStatus.InRepair)
        {
            Dictionary<string, eVehicleGarageStatus> licenseByStatus = new Dictionary<string, eVehicleGarageStatus>();

            foreach (KeyValuePair<string, Vehicle> vehicleEntry in m_VehiclesInGarage)
            {
                if(i_GetAllVehicles)
                {
                    licenseByStatus[vehicleEntry.Value.LicenseNumber] = vehicleEntry.Value.VehicleStatus;
                }
                else if(vehicleEntry.Value.VehicleStatus == i_EVehicleGarageStatus)
                {
                    licenseByStatus[vehicleEntry.Value.LicenseNumber] = vehicleEntry.Value.VehicleStatus;
                }
            }

            return licenseByStatus;
        }

        public void UpdateVehicleStatus(string i_LicenseNumber, eVehicleGarageStatus i_VehicleStatus)
        {
            m_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_VehicleStatus;
        }

        public bool KeyInDictionary(string i_KeyInDicitionary)
        {
            return m_VehiclesInGarage.ContainsKey(i_KeyInDicitionary);
        }

        public void InflateTiresToMaximum(string i_LicenseNumber)
        {
            foreach(Tires vehicleTire in m_VehiclesInGarage[i_LicenseNumber].Tires)
            {
                vehicleTire.InflateTireToMaximum();
            }
        }

        public void FuelVehicle(string i_LicenseNumber, eEnergyTypes i_FuelTypeFromUser, float i_AmountOfFuelToPump)
        {
            m_VehiclesInGarage[i_LicenseNumber].VehicleEngine.FuelVehicle(i_FuelTypeFromUser, i_AmountOfFuelToPump);
        }

        public void RechargeVehicle(string i_LicenseNumber, float i_AmountOfHoursToCharge)
        {
            m_VehiclesInGarage[i_LicenseNumber].VehicleEngine.RechargeVehicle(i_AmountOfHoursToCharge);
        }

        public bool IsElectricVehicle(string i_LicenseNumber)
        {
            return m_VehiclesInGarage[i_LicenseNumber].VehicleEngine is ElectricEngine;
        }

        public string GetInfoFromAboutVehicle(string i_LicenseNumber)
        {
            return m_VehiclesInGarage[i_LicenseNumber].ToString();
        }
    }
}
