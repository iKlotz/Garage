using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Ex03.ConsoleUI.Validations;
using Ex03.ConsoleUI.VehicleInfo;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.ConsoleUI
{
    public class GarageHandler
    {
        private const int k_CreateNewVehicle = 1;
        private Garage m_MyGarage = null;

        public GarageHandler()
        {
            m_MyGarage = new Garage();
        }

        public void CreateNewVehicle()
        {
            UserMessages.PleaseChooseFromTheFollowingVehicles();
            int newVehicle = UserInputValidation.GetValidMenuOptionFromUser(typeof(VehicleFactory.eVehicleTypes));
            UserMessages.EnterLicenseNumberMsg();
            string licenseNumber = Console.ReadLine();

            if(!IsCarInGarage(licenseNumber))
            {
                Dictionary<string, object> newVehicleInfo = new Dictionary<string, object>();
                newVehicleInfo["VehicleType"] = (VehicleFactory.eVehicleTypes)newVehicle;
                newVehicleInfo["LicenseNumber"] = licenseNumber;

                VehicleInformationFromUser.GetVehicleInformationFromUser(newVehicleInfo);
                m_MyGarage.AddNewCarToGarage(newVehicleInfo);
                UserMessages.VehicleAddedToGarageMsg();
            }
            else
            {
                m_MyGarage.UpdateVehicleStatus(licenseNumber, eVehicleGarageStatus.InRepair);
                UserMessages.VehicleIsAlreadyInGarageMsg();
            }
        }

        public void ViewListOfLicenseAndStatus()
        {
            Dictionary<string, eVehicleGarageStatus> statusDictionary = new Dictionary<string, eVehicleGarageStatus>();

            UserMessages.ChooseFilteringOption();
            if (!UserInputValidation.YesOrNoAnswer())
            {
                statusDictionary = m_MyGarage.GetLicenseDictionaryByStatus(true);
            }
            else
            {
                UserMessages.ChooseVehicleStatusFromListMsg();
                int userStatus = UserInputValidation.GetValidMenuOptionFromUser(typeof(eVehicleGarageStatus));

                statusDictionary = m_MyGarage.GetLicenseDictionaryByStatus(false, (eVehicleGarageStatus)userStatus);
            }

            InformationPrinter.PrintVehicleStatuses(statusDictionary);

        }

        public bool IsCarInGarage(string i_LicenseNumber)
        {
            return m_MyGarage.KeyInDictionary(i_LicenseNumber);
        }

        public void UpdateVehicleStatus()
        {
            UserMessages.EnterLicenseNumberMsg();
            string userLicenseInput = Console.ReadLine();

            if(IsCarInGarage(userLicenseInput))
            {
                UserMessages.ChooseVehicleStatusFromListMsg();
                int userStatus = UserInputValidation.GetValidMenuOptionFromUser(typeof(eVehicleGarageStatus));

                m_MyGarage.UpdateVehicleStatus(userLicenseInput, (eVehicleGarageStatus)userStatus);
            }
            else
            {
                UserMessages.NoVehicleWithThisLicenseInGarage();
            }
        }

        public void InflateTiresInVehicle()
        {
            UserMessages.EnterLicenseNumberMsg();
            string userLicenseInput = Console.ReadLine();

            if(IsCarInGarage(userLicenseInput))
            {
                m_MyGarage.InflateTiresToMaximum(userLicenseInput);
                UserMessages.TiresHaveBeenFilled();
            }
            else
            {
                UserMessages.NoVehicleWithThisLicenseInGarage();
            }
        }

        public void FuelBasedVehicle()
        {
            UserMessages.EnterLicenseNumberMsg();
            string userLicenseInput = Console.ReadLine();

            if(IsCarInGarage(userLicenseInput))
            {
                if(!m_MyGarage.IsElectricVehicle(userLicenseInput))
                {
                    try
                    {
                        UserMessages.RequestFuelTypeFromUserMsg();
                        int fuelTypeFromUser = UserInputValidation.GetValidMenuOptionFromUser(typeof(eEnergyTypes));

                        UserMessages.RequestAmountOfFuelToPump();
                        float amountOfFuelToPump = UserInputValidation.ParseUserInputToFloat();

                        m_MyGarage.FuelVehicle(userLicenseInput, (eEnergyTypes)fuelTypeFromUser, amountOfFuelToPump);
                        UserMessages.EnergyAddedToVehicle();
                    }
                    catch(ArgumentException)
                    {
                        UserMessages.InvalidFuelTypeGivenMsg();
                        FuelBasedVehicle();
                    }
                    catch(ValueOutOfRangeException VORE)
                    {
                        UserMessages.InvalidFuelAmountMessage(VORE.m_MaxValue, VORE.m_MinValue); 
                        FuelBasedVehicle();
                    }
                }
                else
                {
                    UserMessages.NotPossibleToFuelElectricCar();
                }
            }
            else
            {
                UserMessages.NoVehicleWithThisLicenseInGarage();
            }
        }

        public void ChargeBasedVehicle()
        {
            UserMessages.EnterLicenseNumberMsg();
            string userLicenseInput = Console.ReadLine();

            if(IsCarInGarage(userLicenseInput))
            {
                if(m_MyGarage.IsElectricVehicle(userLicenseInput))
                {
                    try
                    {
                        UserMessages.RequestAmountOfHoursToCharge();
                        float amountOfHoursToCharge = UserInputValidation.ParseUserInputToFloat();

                        m_MyGarage.RechargeVehicle(userLicenseInput, amountOfHoursToCharge);
                        UserMessages.EnergyAddedToVehicle();
                    }
                    catch (ValueOutOfRangeException VORE)
                    {
                        UserMessages.InvalidAmountOfHoursToCharge(VORE.m_MaxValue, VORE.m_MinValue);
                        ChargeBasedVehicle();
                    }
                }
                else
                {
                    UserMessages.NotPossibleToChareFuelVehicle();
                }
            }
            else
            {
                UserMessages.NoVehicleWithThisLicenseInGarage();
            }
        }

        public void DisplayVehicleInfo()
        {
            UserMessages.EnterLicenseNumberMsg();
            string userLicenseInput = Console.ReadLine();

            if(IsCarInGarage(userLicenseInput))
            {
                Console.Clear();
                Console.WriteLine(m_MyGarage.GetInfoFromAboutVehicle(userLicenseInput));
                Console.WriteLine("Press Any Key To Return To Menu");
                Console.ReadLine();
            }
            else
            {
                UserMessages.NoVehicleWithThisLicenseInGarage();
            }
        }
    }
}
