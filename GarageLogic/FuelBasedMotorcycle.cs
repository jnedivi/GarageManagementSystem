﻿﻿using System;
namespace GarageLogic
{
    public class FuelBasedMotorcycle : Motorcycle
    {

		/*** Data Members ***/
        private FuelBasedEngine m_FuelEngine;

        /*** Getters and Setters ***/
        public FuelBasedEngine FuelEngine
        {
            get { return this.m_FuelEngine; }
            set { this.m_FuelEngine = value; }
        }

        /*** Class Logic ***/

        //2 tires with max air pressure of 33 (psi), Octane 95 (fuel), 5.5 liters fuel tank

        public FuelBasedMotorcycle()
        {
            this.FuelEngine.FuelType = FuelBasedEngine.eFuelType.Octance95; //TODO
            this.FuelEngine.MaxAmountOfFuel = 5.5f;
        }
	}
}
