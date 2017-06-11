﻿﻿using System;
using System.Text;

namespace GarageLogic
{
    public class FuelBasedMotorcycle : Motorcycle
    {

        /*** Data Members ***/
        private const FuelBasedEngine.eFuelType k_FuelTypeForMotorcycle = FuelBasedEngine.eFuelType.Octance95;
        private const float k_MaxAmountOfFuelForMotorcycle = 5.5f;

        /*** Getters and Setters ***/

        /*** Class Logic ***/

        public FuelBasedMotorcycle()
        {
            Engine = new FuelBasedEngine(0.0f, k_MaxAmountOfFuelForMotorcycle, k_FuelTypeForMotorcycle);
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
