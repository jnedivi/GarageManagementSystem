﻿

namespace GarageLogic
{
    public abstract class Engine
    {
        private float m_RemainingEnergyPercentage;

        protected Engine()
        {
            m_RemainingEnergyPercentage = 0.0f;
        }

        public float RemainingEnergyPercentage
        {
            get { return this.m_RemainingEnergyPercentage; }
            set { this.m_RemainingEnergyPercentage = value; }
        }

        public override string ToString()
        {
            string output = string.Format("Remaining Energy Percentage: {0}%", RemainingEnergyPercentage);

            return output;
        }
    }
}