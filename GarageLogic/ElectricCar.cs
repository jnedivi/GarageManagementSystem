﻿using System;
namespace GarageLogic
{
    public class ElectricCar : Car
    {
		//4 tires with max air pressure of 30 (psi), Max battery life – 2.5 hours

		/*** Data Members ***/

        private ElectricBasedEngine m_ElectricEngine;



		/*** Getters and Setters ***/


		/*** Class Logic ***/


		public ElectricCar()
        {
            this.RemainingEnergyPercentage = 2.5f;
           // this.VehicleWheels.ReccomendedAirPressure = 30f;

        }
    }
}
