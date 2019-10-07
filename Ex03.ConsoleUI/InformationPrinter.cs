using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.ConsoleUI
{
    internal class InformationPrinter
    {
        public static void PrintVehicleStatuses(Dictionary<string, eVehicleGarageStatus> i_VehicleStatusDictionary)
        {
            StringBuilder garageStatus = new StringBuilder();

            Console.Clear();

            if (i_VehicleStatusDictionary.Count == 0)
            {
                UserMessages.NoCarsWithThisStatus();
            }
            else
            {
                garageStatus.AppendLine("The Current Garage Vehicle Status:");
                garageStatus.AppendLine("License Numbers : Vehicle Status");

                foreach (KeyValuePair<string, eVehicleGarageStatus> dictionaryEntry in i_VehicleStatusDictionary)
                {
                    garageStatus.AppendLine(string.Format("{0} : {1}", dictionaryEntry.Key, dictionaryEntry.Value.ToString()));
                }
            }

            garageStatus.AppendLine();
            garageStatus.AppendLine("Press Any Key To Continue");

            Console.WriteLine(garageStatus.ToString());
            Console.ReadLine();
        }
    }
}
