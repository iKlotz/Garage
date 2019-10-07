using System;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Engine
{
    internal class FuelEngine : Engine
    {
        private readonly eEnergyTypes r_FuelType;
        private readonly float r_MaxAmountOfFuel = 0f;
        private float m_CurrentAmountOfFuel = 0f;
        
        internal FuelEngine(eEnergyTypes i_FuelType, float i_CurrentAmountOfFuel, float i_MaxAmountOfFuel) : 
            base(i_CurrentAmountOfFuel, i_MaxAmountOfFuel)
        {
            r_FuelType = i_FuelType;
            m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
            r_MaxAmountOfFuel = i_MaxAmountOfFuel;
        }

        internal override void FuelVehicle(eEnergyTypes i_Energy, float i_AmountOfGasToPump)
        {
            if(i_Energy != r_FuelType)
            {
                throw new ArgumentException();
            }

            if(m_CurrentAmountOfFuel + i_AmountOfGasToPump > r_MaxAmountOfFuel)
            {
                throw new ValueOutOfRangeException(r_MaxAmountOfFuel, 0);
            }

            m_CurrentAmountOfFuel += i_AmountOfGasToPump;
        }

        internal override void RechargeVehicle(float i_NumberOfHoursToCharge)
        {
            throw new ArgumentException();
        }

        public override string ToString()
        {
            StringBuilder engineString = new StringBuilder();
            engineString.AppendLine("Fuel Type : " + r_FuelType.ToString());
            engineString.AppendLine("Fuel Amount : " + m_CurrentAmountOfFuel);
            engineString.AppendLine("Max Fuel : " + r_MaxAmountOfFuel);

            return engineString.ToString();
        }
    }
}
