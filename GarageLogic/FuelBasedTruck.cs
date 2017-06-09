﻿using System;
using System.Text;

namespace GarageLogic
{
    public class FuelBasedTruck : Truck
    {

        /*** Data Members ***/
        private const FuelBasedEngine.eFuelType k_FuelTypeForTruck = FuelBasedEngine.eFuelType.Octance96;
        private const float k_MaxAmountOfFuelForTruck = 135.0f;
        private readonly FuelBasedEngine r_FuelEngine;

		/*** Getters and Setters ***/
        public FuelBasedEngine FuelEngine
        {
            get { return this.r_FuelEngine; }
        }

        /*** Class Logic ***/

        public FuelBasedTruck()
        {
            r_FuelEngine = new FuelBasedEngine(0.0f, k_MaxAmountOfFuelForTruck, k_FuelTypeForTruck);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.Append(r_FuelEngine.ToString());

            return output.ToString();
        }
    }
}
