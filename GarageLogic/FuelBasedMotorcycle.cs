﻿﻿﻿using System;
using System.Text;
using System.Collections.Generic;

namespace GarageLogic
{
    public class FuelBasedMotorcycle : Motorcycle
    {

        /*** Data Members ***/
        private const FuelBasedEngine.eFuelType k_FuelTypeForMotorcycle = FuelBasedEngine.eFuelType.Octance95;
        private const float k_MaxAmountOfFuelForMotorcycle = 5.5f;

		/*** Getters and Setters ***/

		/*** Class Logic ***/

		public FuelBasedMotorcycle(string i_LicenceNumber, string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, List<Vehicle.Wheel> i_Wheels)
			: base(i_LicenceNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_Wheels)
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
