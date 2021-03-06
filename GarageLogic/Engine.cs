﻿using System;

namespace GarageLogic
{
    public abstract class Engine
    {
		/*** Data Members ***/

        private float m_RemainingEnergyPercentage;

		/*** Getters and Setters ***/

		public float RemainingEnergyPercentage
		{
			get { return this.m_RemainingEnergyPercentage; }
			set { this.m_RemainingEnergyPercentage = value; }
		}

		/*** Constructor ***/

        protected Engine()
        {
            m_RemainingEnergyPercentage = 0.0f;
        }

		/*** Class Logic ***/

		public override string ToString()
        {
            string output = string.Format(@"Engine Information:
Remaining Energy Percentage: {0}%
", Math.Round((RemainingEnergyPercentage * 100), 2));

            return output;
        }
    }
}
