﻿using System;
using System.Text;

namespace GarageLogic
{
    public class FuelBasedCar : Car
    {

        /*** Data Members ***/
        private const FuelBasedEngine.eFuelType k_FuelTypeForCar = FuelBasedEngine.eFuelType.Octane98;
        private const float k_MaxAmountOfFuelForCar = 42.0f;

        /*** Getters and Setters ***/


        /*** Class Logic ***/

        public FuelBasedCar()
        {
            Engine = new FuelBasedEngine(0.0f, k_MaxAmountOfFuelForCar, k_FuelTypeForCar);
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
