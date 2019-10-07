using System;
using System.Collections.Generic;
using Ex03.ConsoleUI.Validations;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.ConsoleUI.VehicleInfo
{
    public static class MotorcycleInfo
    {
        private static readonly int sr_NumberOfTires = Motorcycle.sr_NumberOfTires;
        private static readonly float sr_MaxPsi = Motorcycle.sr_MaxPsiLevel;

        public static void AddSpecificMotorCycleInfo(Dictionary<string, object> i_NewMotorCycleInfoDictionary)
        {
            AddTiresToVehicle.AddTiresToDictionary(sr_NumberOfTires, sr_MaxPsi, i_NewMotorCycleInfoDictionary);
            i_NewMotorCycleInfoDictionary["MotorcycleLicenseType"] = requestLicenseTypeFromUser();
            i_NewMotorCycleInfoDictionary["EngineVolume"] = requestValidEngineVol();
        }

        private static int requestValidEngineVol()
        {
            UserMessages.EnterValidEngineVolMsg();
            string engineVolume = Console.ReadLine();
            int engineVolumeInt;
            
            while(!int.TryParse(engineVolume, out engineVolumeInt))
            {
                UserMessages.EnterValidEngineVolAsIntMsg();
                engineVolume = Console.ReadLine(); 
            }

            return engineVolumeInt;
        }

        private static int requestLicenseTypeFromUser()
        {
            UserMessages.ChooseMotorLicense();
            return UserInputValidation.GetValidMenuOptionFromUser(typeof(eMotorcycleLicenseType));
        }
    }
}
