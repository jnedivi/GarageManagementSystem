﻿using System;
namespace GarageLogic
{
    public class FuelBasedCar : Car
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

        //4 tires with max air pressure of 30 (psi), Octane 98 fuel, 42 liter fuel tank

        public FuelBasedCar()
        {
            this.FuelEngine.FuelType = FuelBasedEngine.eFuelType.Octane98; //TODO
            this.FuelEngine.MaxAmountOfFuel = 42f;
        }
    }
}
