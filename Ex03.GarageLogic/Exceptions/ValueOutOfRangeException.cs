using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        public float m_MaxValue = 0;
        public float m_MinValue = 0;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
        {
            this.m_MaxValue = i_MaxValue;
            this.m_MinValue = i_MinValue;
        }
    }
}