using System.Collections.Generic;
using Ex03.ConsoleUI.Validations;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.ConsoleUI.VehicleInfo
{
    public static class CarInfo
    {
        private static readonly int sr_NumberOfTires = Car.sr_NumberOfTires;
        private static readonly float sr_MaxPsi = Car.sr_MaxPsiLevel;

        public static void AddSpecificCarInfo(Dictionary<string, object> i_NewCarInfoDictionary)
        {
            AddTiresToVehicle.AddTiresToDictionary(sr_NumberOfTires, sr_MaxPsi, i_NewCarInfoDictionary);
            i_NewCarInfoDictionary["CarColor"] = requestValidCarColor();
            i_NewCarInfoDictionary["NumberOfDoors"] = requestValidNumberOfDoors();
        }

        private static int requestValidNumberOfDoors()
        {
            UserMessages.EnterNumberOfDoorsInCarMsg();
            return UserInputValidation.GetValidMenuOptionFromUser(typeof(eNumberOfDoors));
        }

        private static int requestValidCarColor()
        {
            UserMessages.EnterCarColorMsg();
            return UserInputValidation.GetValidMenuOptionFromUser(typeof(eCarColors));
        }
    }
}
