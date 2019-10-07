using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class UserMessages
    {
        private const string k_WelcomeToGarageMsg = "Welcome to garage manager";
        private const string k_EnterValidTirePressureNumberMsg = "Illegal input! Pressure should be in correct PSI range";
        private const string k_EnterValidTireFloatMsg = "Illegal input! Please enter a valid number representing the tire preassure";
        private const string k_GetTireManufacturerMsg = "Please enter your vehicle's tire manufacturer name";
        private const string k_EnterCurrentEnergyPercentageMsg = "Please enter your vehicle's current energy percentage";
        private const string k_EnterValidPercentageMsg = "Illegal input! Please enter a number in range" 
                                                         + " <0 - 100> representing your energy percentage";
        private const string k_EnterValidFloatMsg = "Illegal input! Please enter a number";
        private const string k_EnterModelNameMsg = "Please enter your vehicle's model";
        private const string k_VehicleIsAlreadyInGarageMsg = "Your car is already registered to our garage!"
                                                         + " We'll check you in as in repair";
        private const string k_VehicleSuccessfullyAdded = "Vehicle successfully added to garage system";
        private const string k_EnterOwnerNameMsg = "Please enter owners name";
        private const string k_EnterLicenseNumberMsg = "Please enter license plate number";
        private const string k_EnterValidEngineVolMsg = "Please enter the engine volume";
        private const string k_EnterYourPhoneNumberMsg = "Please enter your phone number";
        private static string k_InvalidVehicleEnteredMsg = string.Format(
                                                                        "Oops, it seems like you entered an invalid vehicle type.{0}"
                                                                        + "Please enter a valid type: <FuelCar, ElectricCar, "
                                                                        + "FuelMotorcycle, ElectricMotorcycle, FuelTruck>",
                                                                        Environment.NewLine);
        private static string k_ChooseFromTheFollowingVehicles = string.Format(
																			   "1 - FuelCar{0}" +
                                                                               "2 - ElectricCar{0}" +
                                                                               "3 - FuelMotorcycle{0}" +
                                                                               "4 - ElectricMotorcycle{0}" +
                                                                               "5 - FuelTruck{0}{0}" + 
                                                                               "Please enter your vehicle type, choose from the list:",
                                                                                Environment.NewLine);
        private static string k_EnterMenuOption = string.Format(
                                                                "Menu Options:{0}{0}" +
                                                                "1 - Insert a new vehicle to the garage{0}" + 
                                                                "2 - View a list of license plates of vehicles currently in the garage{0}" +
                                                                "3 - To change a vehicle's status{0}" + 
                                                                "4 - To inflate your vehicle's tires{0}" +
                                                                "5 - To refuel your vehicle{0}" +
                                                                "6 - To charge your vehicle{0}" + 
                                                                "7 - To display all details of a vehicle{0}" +
                                                                "8 - To close the Garage{0}{0}" +
                                                                "Please choose the number of the desired option: ",
                                                                Environment.NewLine);
        private static string k_IncorrectMenuOptionMessage = "Illegal Input! Please Enter a number from the menu above!";
        private static string k_CheckTruckHasDangerousCargoMsg = "Please Enter 'Yes' if Truck contains a dangerous Cargo and 'No' Otherwise";
        private static string k_EnterYesOrNoOnlyMsg = "Please Enter 'Yes' or 'No' ONLY!";
        private static string k_EnterValidCargoVolMsg = "Please enter the volume of your cargo in liters";
        private static string k_EnterValidEngineVolAsIntMsg = "Please enter a number!";
        private static string k_EnterCarColorMsg = string.Format(
                                                                 "1 - Red{0}" +
                                                                 "2 - Blue{0}" +
                                                                 "3 - Black{0}" +
                                                                 "4 - Grey{0}{0}" +
                                                                 "Please choose the number of the desired Car Color: ", 
                                                                 Environment.NewLine);
        private static string k_EnterNumberOfDoorsInCarMsg = string.Format(
                                                                           "1 - Two{0}" +
                                                                           "2 - Three{0}" +
                                                                           "3 - Four{0}" +
                                                                           "4 - Five{0}{0}" +
                                                                           "Please choose the number of doors in your car: ", 
                                                                           Environment.NewLine);
        private static string k_ChooseMotorLicense = string.Format(
                                                                   "1 - A{0}" +
                                                                   "2 - A1{0}" +
                                                                   "3 - A2{0}" +
                                                                   "4 - B{0}{0}" +
                                                                   "Please choose your license type: ", 
                                                                   Environment.NewLine);
        private static string k_VehicleStatusMsg = string.Format(
                                                                 "0 - Undefined{0}" +
                                                                 "1 - InRepair{0}" +
                                                                 "2 - Repaired{0}" +
                                                                 "3 - PayedFor{0}{0}" +
                                                                 "Please choose your license type: ", 
                                                                 Environment.NewLine);
        private static string k_PressAnyKeyToContinue = string.Format("{0}{0}Press Any key to continue", Environment.NewLine);
        private static string k_WouldYouLikeToFilterByStatus = "Would you like to filter by car status- 'Yes' or 'No'?";
        private static string k_FuelTypeMsgRequest = string.Format(
                                                                    "1 - Octane95{0}" +
                                                                    "2 - Octane96{0}" +
                                                                    "3 - Octane98{0}" +
                                                                    "4 - Soler{0}" +
                                                                    "5 - Electricity{0}{0}" +
                                                                    "Please choose your Fuel Type: ",
                                                                    Environment.NewLine);
        


        private static void clearScreenAndPrintConsole(string i_AnyTypeOfString)
        {
            Console.Clear();
            Console.WriteLine(i_AnyTypeOfString);
        }

        private static void printConsoleAndWaitForApprove(string i_AnyTypeOfString)
        {
            Console.Clear();
            string waitForAnyKeyMessage = i_AnyTypeOfString + k_PressAnyKeyToContinue;
            Console.WriteLine(waitForAnyKeyMessage);
            Console.ReadLine();
        }

        public static void WelcomeToGarageMsg()
        {
            Console.WriteLine(k_WelcomeToGarageMsg + Environment.NewLine);
        }

        public static void PleaseEnterMenuOption(bool i_WithClear = true)
        {
            if(i_WithClear)
            {
                clearScreenAndPrintConsole(k_EnterMenuOption);
            }
            else
            {
                Console.WriteLine(k_EnterMenuOption);
            }
        }

        public static void PleaseChooseFromTheFollowingVehicles()
        {
            clearScreenAndPrintConsole(k_ChooseFromTheFollowingVehicles);
        }

        public static void InvalidVehicleEnteredMsg()
        {
            Console.WriteLine(k_InvalidVehicleEnteredMsg);
        }

        public static void VehicleIsAlreadyInGarageMsg()
        {
           printConsoleAndWaitForApprove(k_VehicleIsAlreadyInGarageMsg);
        }

        public static void EnterModelNameMsg()
        {
            clearScreenAndPrintConsole(k_EnterModelNameMsg);
        }

        public static void EnterCurrentEnergyPercentageMsg()
        {
            clearScreenAndPrintConsole(k_EnterCurrentEnergyPercentageMsg);
        }

        public static void PleaseEnterValidFloatMsg()
        {
            Console.WriteLine(k_EnterValidFloatMsg);
        }

        public static void PleaseEnterValidPercentageMsg()
        {
            Console.WriteLine(k_EnterValidPercentageMsg);
        }

        public static void GetTireManufacturerMsg()
        {
            clearScreenAndPrintConsole(k_GetTireManufacturerMsg);
        }

        public static void PleaseEnterCurrentTirePressureMsg(int i_CurrentTireNumberToAddMessageTo)
        {
            string enterCurrentTirePressureMsg = string.Format(
                                                               "Please enter the pressure of " 
                                                               + "tire number {0}", 
                                                               i_CurrentTireNumberToAddMessageTo);
            clearScreenAndPrintConsole(enterCurrentTirePressureMsg);
        }

        public static void PleaseEnterValidTireFloatMsg()
        {
            Console.WriteLine(k_EnterValidTireFloatMsg);
        }

        public static void PleaseEnterValidTirePressureNumberMsg()
        {
            Console.WriteLine(k_EnterValidTirePressureNumberMsg);
        }
        
        public static void IncorrectMenuOptionMessage()
        {
            Console.WriteLine(k_IncorrectMenuOptionMessage);
        }

        public static void CheckTruckHasDangerousCargoMsg()
        {
            clearScreenAndPrintConsole(k_CheckTruckHasDangerousCargoMsg);
        }

        public static void EnterYesOrNoOnlyMsg()
        {
            Console.WriteLine(k_EnterYesOrNoOnlyMsg);
        }

        public static void EnterValidCargoVolMsg()
        {
            clearScreenAndPrintConsole(k_EnterValidCargoVolMsg);
        }

        public static void EnterValidEngineVolAsIntMsg()
        {
            Console.WriteLine(k_EnterValidEngineVolAsIntMsg);
        }

        public static void EnterCarColorMsg()
        {
            clearScreenAndPrintConsole(k_EnterCarColorMsg);
        }
        
        public static void EnterNumberOfDoorsInCarMsg()
        {
            clearScreenAndPrintConsole(k_EnterNumberOfDoorsInCarMsg);
        }

        public static void EnterValidEngineVolMsg()
        {
            clearScreenAndPrintConsole(k_EnterValidEngineVolMsg);
        }

        public static void EnterYourPhoneNumberMsg()
        {
            clearScreenAndPrintConsole(k_EnterYourPhoneNumberMsg);
        }

        public static void ChooseMotorLicense()
        {
            clearScreenAndPrintConsole(k_ChooseMotorLicense);
        }

        public static void EnterLicenseNumberMsg()
        {
            clearScreenAndPrintConsole(k_EnterLicenseNumberMsg);
        }

        public static void EnterOwnerNameMsg()
        {
            clearScreenAndPrintConsole(k_EnterOwnerNameMsg);
        }

        public static void VehicleAddedToGarageMsg()
        {
            printConsoleAndWaitForApprove(k_VehicleSuccessfullyAdded);
        }

        public static void ChooseFilteringOption()
        {
            Console.WriteLine(k_WouldYouLikeToFilterByStatus);
        }


        public static void ChooseVehicleStatusFromListMsg()
        {
            clearScreenAndPrintConsole(k_VehicleStatusMsg);
        }

        public static void NoCarsInTheGarageMsg()
        {
            printConsoleAndWaitForApprove("There aren't any vehicles in the Garage at the moment");
        }

        public static void NoVehicleWithThisLicenseInGarage()
        {
            printConsoleAndWaitForApprove("There isn't a vehicle with this license number");
        }

        public static void RequestFuelTypeFromUserMsg()
        {
            clearScreenAndPrintConsole(k_FuelTypeMsgRequest);
        }

        public static void InvalidFuelTypeGivenMsg()
        {
            printConsoleAndWaitForApprove("Invalid fuel type given!");
        }

        public static void InvalidFuelAmountMessage(float i_MaxValue, float i_MinValue)
        {
            string errorMsg = string.Format(
                "The fuel given exceeds max fuel in the tank. Max:{0} , Min:{1}",
                i_MaxValue,
                i_MinValue);
            printConsoleAndWaitForApprove(errorMsg);
        }

        public static void InvalidAmountOfHoursToCharge(float i_MaxValue, float i_MinValue)
        {
            string errorMsg = string.Format(
                "The hours to charge given exceeds max fuel in the tank. Max:{0} , Min:{1}",
                i_MaxValue,
                i_MinValue);
            printConsoleAndWaitForApprove(errorMsg);
        }

        public static void RequestAmountOfFuelToPump()
        {
            clearScreenAndPrintConsole("Please enter the amount of fuel you want to pump");
        }

        public static void RequestAmountOfHoursToCharge()
        {
            clearScreenAndPrintConsole("Please enter the amount of hours you would want to charge");
        }

        public static void NotPossibleToFuelElectricCar()
        {
            printConsoleAndWaitForApprove("Impossible to fuel electric vehicles");
        }

        public static void NotPossibleToChareFuelVehicle()
        {
            printConsoleAndWaitForApprove("Impossible to charge fuel vehicles");
        }

        public static void NoCarsWithThisStatus()
        {
            Console.WriteLine("No cars with this status");
        }

        public static void TiresHaveBeenFilled()
        {
            printConsoleAndWaitForApprove("All tires have bin filled");
        }

        public static void EnergyAddedToVehicle()
        {
            printConsoleAndWaitForApprove("We have updated the vehicles energy");
        }

        public static void IncorrectPhoneNumberMsg()
        {
            printConsoleAndWaitForApprove("Phone number should have numbers only!");
        }
    }
}