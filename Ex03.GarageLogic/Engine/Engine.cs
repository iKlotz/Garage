using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Engine
{
    public abstract class Engine
    {
        private readonly float r_MaxAmountOfEnergy = 0;
        private float m_CurrentAmountOfEnergy = 0;
        
        protected Engine(float i_CurrentAmountOfEnergy, float i_MaxAmountOfEnergy)
        {
            m_CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
            r_MaxAmountOfEnergy = i_MaxAmountOfEnergy;
        }

        internal abstract void FuelVehicle(eEnergyTypes i_Energy, float i_AmountOfGasToPump);

        internal abstract void RechargeVehicle(float i_NumberOfHoursToCharge);

        public abstract override string ToString();
    }
}
