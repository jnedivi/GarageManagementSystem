﻿using System;
using System.Text;

namespace GarageLogic
{
    public class FuelBasedCar : Car
    {

        /*** Data Members ***/
        private const FuelBasedEngine.eFuelType k_FuelTypeForCar = FuelBasedEngine.eFuelType.Octane98;
        private const float k_MaxAmountOfFuelForCar = 42.0f;
        private readonly FuelBasedEngine r_FuelEngine;

        /*** Getters and Setters ***/
        public FuelBasedEngine FuelEngine
        {
            get { return this.r_FuelEngine; }
        }

        /*** Class Logic ***/

        public FuelBasedCar()
        {
            r_FuelEngine = new FuelBasedEngine(0.0f, k_MaxAmountOfFuelForCar, k_FuelTypeForCar);
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
