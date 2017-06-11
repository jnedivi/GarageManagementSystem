﻿using System;
using System.Text;

namespace GarageLogic
{
    public class FuelBasedTruck : Truck
    {

        /*** Data Members ***/
        private const FuelBasedEngine.eFuelType k_FuelTypeForTruck = FuelBasedEngine.eFuelType.Octance96;
        private const float k_MaxAmountOfFuelForTruck = 135.0f;
        

		/*** Getters and Setters ***/


        /*** Class Logic ***/

        public FuelBasedTruck()
        {
            Engine = new FuelBasedEngine(0.0f, k_MaxAmountOfFuelForTruck, k_FuelTypeForTruck);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.Append(Engine.ToString());

            return output.ToString();
        }
    }
}
