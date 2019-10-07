using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public static class AddTiresToVehicle
    {

        public static void AddTiresToDictionary(int i_NumberOfTires, float i_MaxPsi, Dictionary<string, object> i_NewVehicleInfoDictionary)
        {
            string tire = "Tire";
            for (int i = 1; i <= i_NumberOfTires; i++)
            {
                UserMessages.PleaseEnterCurrentTirePressureMsg(i);
                i_NewVehicleInfoDictionary[(tire + i.ToString())] = validateTireFromUserInput(i_NumberOfTires, i_MaxPsi, i_NewVehicleInfoDictionary);
            }
        }
        private static float validateTireFromUserInput(int i_NumberOfTires, float i_MaxPsi, Dictionary<string, object> i_NewVehicleInfoDictionary)
        {
            string currentTirePressure = Console.ReadLine();
            bool isFloat = float.TryParse(currentTirePressure, out float floatTirePressure);

            if (!isFloat)
            {
                UserMessages.PleaseEnterValidTireFloatMsg();
                floatTirePressure = validateTireFromUserInput(i_NumberOfTires, i_MaxPsi, i_NewVehicleInfoDictionary);
            }
            else
            {
                if (!(floatTirePressure >= 0 && floatTirePressure <= i_MaxPsi))
                {
                    UserMessages.PleaseEnterValidTirePressureNumberMsg();
                    floatTirePressure = validateTireFromUserInput(i_NumberOfTires, i_MaxPsi, i_NewVehicleInfoDictionary);
                }
            }

            return floatTirePressure;
        }
    }
}
