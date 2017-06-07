﻿﻿using System;
namespace GarageLogic
{
    public class FuelBasedMotorcycle : Motorcycle
    {
		//2 tires with max air pressure of 33 (psi), Octane 95 (fuel), 5.5 liters fuel tank


		/*** Data Members ***/
        private FuelBasedEngine m_FuelEngine;


		/*** Getters and Setters ***/


		/*** Class Logic ***/

        public FuelBasedMotorcycle()
        {
            //this.VehicleWheels.ReccomendedAirPressure = 33f;
            this.m_FuelEngine.FuelType = FuelBasedEngine.eFuelType.Octance95;
            this.m_FuelEngine.MaxAmountOfFuel = 5.5f;



        }

	}
}
