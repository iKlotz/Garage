using System;
using System.Collections.Generic;
using Ex03.ConsoleUI.Validations;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.ConsoleUI.VehicleInfo
{
    public class TruckInfo
    {
        private static readonly int sr_NumberOfTires = Truck.sr_NumberOfTires;
        private static readonly float sr_MaxPsi = Truck.sr_MaxPsiLevel;

        public static void AddSpecificTruckInfo(Dictionary<string, object> i_NewTruckInfoDictionary)
        {
            AddTiresToVehicle.AddTiresToDictionary(sr_NumberOfTires, sr_MaxPsi, i_NewTruckInfoDictionary);
            i_NewTruckInfoDictionary["IsSafeCargo"] = checkIfSafe();
            i_NewTruckInfoDictionary["CargoVolume"] = requestValidCargoVol();
        }

        private static bool checkIfSafe()
        {
            UserMessages.CheckTruckHasDangerousCargoMsg();

            return UserInputValidation.YesOrNoAnswer();
        }


        private static float requestValidCargoVol()
        {
            UserMessages.EnterValidCargoVolMsg();
            string cargoVolInput = Console.ReadLine();

            bool isFloat = float.TryParse(cargoVolInput, out float cargoVolumeFloat);

            if (!isFloat)
            {
                UserMessages.EnterValidEngineVolAsIntMsg();
                cargoVolumeFloat = requestValidCargoVol();
            }

            return cargoVolumeFloat;
        }
    }
}
