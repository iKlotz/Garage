using System;
using System.Collections.Generic;
using Ex03.ConsoleUI.Validations;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI.VehicleInfo
{
    public static class VehicleInformationFromUser
    {
        private const int k_NumbeOfMotorcycleTires = 2;
        private const int k_NumbeOfCarTires = 4;
        private const int k_NumbeOfTruckTires = 12;

        public static void GetVehicleInformationFromUser(Dictionary<string, object> i_NewVehicleInfoDictionary)
        {
            UserMessages.EnterOwnerNameMsg();
            i_NewVehicleInfoDictionary["OwnerName"] = Console.ReadLine();
            i_NewVehicleInfoDictionary["PhoneNumber"] = UserInputValidation.GetPhoneNumberFromUser();
            UserMessages.EnterModelNameMsg();
            i_NewVehicleInfoDictionary["ModelName"] = Console.ReadLine();
            i_NewVehicleInfoDictionary["RemainingEnergyPercentage"] = UserInputValidation.GetEnergyPercentageStatusFromUser();
            UserMessages.GetTireManufacturerMsg();
            i_NewVehicleInfoDictionary["TireManufacturer"] = Console.ReadLine();

            getSpecificInfoPerVehicle(i_NewVehicleInfoDictionary);
        }

        private static void getSpecificInfoPerVehicle(Dictionary<string, object> i_NewVehicleInfoDictionary)
        {
            switch (i_NewVehicleInfoDictionary["VehicleType"])
            {
                case VehicleFactory.eVehicleTypes.ElectricMotorcycle:
                case VehicleFactory.eVehicleTypes.FuelMotorcycle:
                    {
                        MotorcycleInfo.AddSpecificMotorCycleInfo(i_NewVehicleInfoDictionary);
                        break;
                    }

                case VehicleFactory.eVehicleTypes.ElectricCar:
                case VehicleFactory.eVehicleTypes.FuelCar:
                    {
                        CarInfo.AddSpecificCarInfo(i_NewVehicleInfoDictionary);
                        break;
                    }

                case VehicleFactory.eVehicleTypes.FuelTruck:
                    {
                        TruckInfo.AddSpecificTruckInfo(i_NewVehicleInfoDictionary);
                        break;
                    }
            }
        }
    } 
}
