using System;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Engine
{
    internal class ElectricEngine : Engine
    {
        private readonly float r_MaxAmountOfBattery = 0f;
        private readonly eEnergyTypes r_EnergyType;
        private float m_CurrentAmountOfBatteryLeft = 0f;
        
        internal ElectricEngine(float i_CurrentAmountOfBatteryLeft, float i_MaxAmountOfBattery) :
            base(i_CurrentAmountOfBatteryLeft, i_MaxAmountOfBattery)
        {
            r_EnergyType = eEnergyTypes.Electricity;
            m_CurrentAmountOfBatteryLeft = i_CurrentAmountOfBatteryLeft;
            r_MaxAmountOfBattery = i_MaxAmountOfBattery;
        }

        internal override void FuelVehicle(eEnergyTypes i_Energy, float i_AmountOfGasToPump)
        {
            throw new ArgumentException();
        }

        internal override void RechargeVehicle(float i_NumberOfHoursToCharge)
        {
            if(i_NumberOfHoursToCharge + m_CurrentAmountOfBatteryLeft > r_MaxAmountOfBattery)
            {
                throw new ValueOutOfRangeException(r_MaxAmountOfBattery, 0);
            }

            m_CurrentAmountOfBatteryLeft += i_NumberOfHoursToCharge;
        }

        public override string ToString()
        {
            StringBuilder engineString = new StringBuilder();
            engineString.AppendLine("Energy Type : " + r_EnergyType.ToString());
            engineString.AppendLine("Battery Level : " + m_CurrentAmountOfBatteryLeft);
            engineString.AppendLine("Battery Max : " + r_MaxAmountOfBattery);

            return engineString.ToString();
        }
    }
}
