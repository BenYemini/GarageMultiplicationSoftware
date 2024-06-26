﻿namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        public float MinValue
        {
            get { return m_MinValue; }
        }
        
        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue) : base(string.Format("{0} is out of range, it should be between {1} - {2}", i_Message, i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
