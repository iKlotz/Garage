using Ex03.ConsoleUI.Enums;
using Ex03.ConsoleUI.Validations;

namespace Ex03.ConsoleUI
{
    public class UserMenuGarageHandler
    {
        private GarageHandler m_GarageHandler = null;
        private int m_MenuOptions = 0;
        private bool m_WithClear = false;

        public UserMenuGarageHandler()
        {
            m_GarageHandler = new GarageHandler();
            UserMessages.WelcomeToGarageMsg();

            UserMessages.PleaseEnterMenuOption(m_WithClear);

            GarageManager();
        }

        public void GarageManager()
        {
            while (m_MenuOptions != (int)eMenuOptions.CloseGarage)
            {
                if(!m_WithClear)
                {
                    m_WithClear = true;
                }
                else
                {
                    UserMessages.PleaseEnterMenuOption();
                }

                m_MenuOptions = UserInputValidation.GetValidMenuOptionFromUser(typeof(eMenuOptions));

                if (m_MenuOptions == (int)eMenuOptions.InsertNewVehicle)
                {
                    m_GarageHandler.CreateNewVehicle();
                }
                else if (m_MenuOptions == (int)eMenuOptions.DisplayAllVehicles)
                {
                    m_GarageHandler.ViewListOfLicenseAndStatus();
                }
                else if (m_MenuOptions == (int)eMenuOptions.ChangeVehicleStatus)
                {
                    m_GarageHandler.UpdateVehicleStatus();
                }
                else if (m_MenuOptions == (int)eMenuOptions.InflateTires)
                {
                    m_GarageHandler.InflateTiresInVehicle();
                }
                else if (m_MenuOptions == (int)eMenuOptions.RefuelFuelBasedVehicle)
                {
                    m_GarageHandler.FuelBasedVehicle();
                }
                else if (m_MenuOptions == (int)eMenuOptions.RechargeElectricVehicle)
                {
                    m_GarageHandler.ChargeBasedVehicle();
                }
                else if (m_MenuOptions == (int)eMenuOptions.DisplayVehicleDetails)
                {
                    m_GarageHandler.DisplayVehicleInfo();
                }
            }
        }
    }
}
