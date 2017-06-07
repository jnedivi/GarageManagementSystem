﻿using System;
namespace GarageLogic
{
    public class FuelBasedTruck : Truck
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

        //Twelve tires with max air pressure of 32 (psi), Octane 96 fuel, 135 liter fuel tank

        public FuelBasedTruck()
        {
            this.FuelEngine.FuelType = FuelBasedEngine.eFuelType.Octance96; //TODO
            this.FuelEngine.MaxAmountOfFuel = 135f;
        }
    }
}
