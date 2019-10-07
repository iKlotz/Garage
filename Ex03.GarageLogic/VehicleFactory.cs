using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        internal static Vehicle BuildVehicle(Dictionary<string, object> i_NewVehicleInfoDictionary)
        {
            eVehicleTypes vehicleType = (eVehicleTypes)i_NewVehicleInfoDictionary["VehicleType"];
            Vehicle newVehicle;

            string modelName = (string)i_NewVehicleInfoDictionary["ModelName"];
            string licenseNumber = (string)i_NewVehicleInfoDictionary["LicenseNumber"];
            float remainingEnergyPercentage = (float)i_NewVehicleInfoDictionary["RemainingEnergyPercentage"];
            string ownerName = (string)i_NewVehicleInfoDictionary["OwnerName"];
            string phoneNumber = (string)i_NewVehicleInfoDictionary["PhoneNumber"];
            eVehicleGarageStatus vehicleStatus = eVehicleGarageStatus.InRepair;

            switch (vehicleType)
            {
                case eVehicleTypes.FuelMotorcycle:
                    newVehicle = new FuelBasedMotorcycle(modelName, licenseNumber, remainingEnergyPercentage, ownerName, phoneNumber, vehicleStatus);
                    updateMotorcycleInfo((FuelBasedMotorcycle)newVehicle, i_NewVehicleInfoDictionary);
                    break;
                case eVehicleTypes.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle(modelName, licenseNumber, remainingEnergyPercentage, ownerName, phoneNumber, vehicleStatus);
                    updateMotorcycleInfo((ElectricMotorcycle)newVehicle, i_NewVehicleInfoDictionary);
                    break;
                case eVehicleTypes.FuelCar:
                    newVehicle = new FuelBasedCar(modelName, licenseNumber, remainingEnergyPercentage, ownerName, phoneNumber, vehicleStatus);
                    updateCarInfo((FuelBasedCar)newVehicle, i_NewVehicleInfoDictionary);
                    break;
                case eVehicleTypes.ElectricCar:
                    newVehicle = new ElectricCar(modelName, licenseNumber, remainingEnergyPercentage, ownerName, phoneNumber, vehicleStatus);
                    updateCarInfo((ElectricCar)newVehicle, i_NewVehicleInfoDictionary);
                    break;
                case eVehicleTypes.FuelTruck:
                    newVehicle = new FuelBasedTruck(modelName, licenseNumber, remainingEnergyPercentage, ownerName, phoneNumber, vehicleStatus);
                    updateTruckInfo((FuelBasedTruck)newVehicle, i_NewVehicleInfoDictionary);
                    break;
                default:
                    throw new Exception("This vehicle is not supported");
            }

            return newVehicle;
        }

        private static void updateMotorcycleInfo(Motorcycle i_NewMotorcycle, Dictionary<string, object> i_NewVehicleInfoDictionary)
        {
            i_NewMotorcycle.LicenseType = (eMotorcycleLicenseType)i_NewVehicleInfoDictionary["MotorcycleLicenseType"];
            i_NewMotorcycle.EngineVolume = (int)i_NewVehicleInfoDictionary["EngineVolume"];
            i_NewMotorcycle.Tires = setTiresForVehicle(
                Motorcycle.sr_MaxPsiLevel,
                (string)i_NewVehicleInfoDictionary["TireManufacturer"],
                i_NewVehicleInfoDictionary, 
                Motorcycle.sr_NumberOfTires);
        }

        private static List<Tires> setTiresForVehicle(
            float i_MaxPsiLevel,
            string i_TireManufacturer, 
            Dictionary<string, object> i_NewVehicleInfoDictionary, 
            int i_NumberOfTires)
        {
            List<Tires> tires = new List<Tires>();

            for (int i = 1; i <= i_NumberOfTires; i++)
            {
                tires.Add(new Tires(i_TireManufacturer, (float)i_NewVehicleInfoDictionary[("Tire" + i.ToString())], i_MaxPsiLevel));
            }

            return tires;
        }

        private static void updateCarInfo(Car i_NewCar, Dictionary<string, object> i_NewVehicleInfoDictionary)
        {
            i_NewCar.Color = (eCarColors)i_NewVehicleInfoDictionary["CarColor"];
            i_NewCar.NumberOfDoors = (eNumberOfDoors)i_NewVehicleInfoDictionary["NumberOfDoors"];
            i_NewCar.Tires = setTiresForVehicle(
                Car.sr_MaxPsiLevel,
                (string)i_NewVehicleInfoDictionary["TireManufacturer"],
                i_NewVehicleInfoDictionary, 
                Car.sr_NumberOfTires);
        }

        private static void updateTruckInfo(Truck i_NewTruck, Dictionary<string, object> i_NewVehicleInfoDictionary)
        {
            i_NewTruck.IsSafe = (bool)i_NewVehicleInfoDictionary["IsSafeCargo"];
            i_NewTruck.CargoVolume = (float)i_NewVehicleInfoDictionary["CargoVolume"];
            i_NewTruck.Tires = setTiresForVehicle(
                Truck.sr_MaxPsiLevel,
                (string)i_NewVehicleInfoDictionary["TireManufacturer"],
                i_NewVehicleInfoDictionary, 
                Truck.sr_NumberOfTires);
        }

        public enum eVehicleTypes
        {
            FuelCar = 1,
            ElectricCar = 2,
            FuelMotorcycle = 3,
            ElectricMotorcycle = 4,
            FuelTruck = 5
        }
    }
}
