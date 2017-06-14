﻿﻿using System;
using System.Text;
using System.Collections.Generic;

namespace GarageLogic
{
    public class FuelBasedTruck : Truck
    {

        /*** Data Members ***/

        private const FuelBasedEngine.eFuelType k_FuelTypeForTruck = FuelBasedEngine.eFuelType.Octance96;
        private const float k_MaxAmountOfFuelForTruck = 135.0f;

		/*** Constructor ***/

		public FuelBasedTruck(string i_LicenceNumber, string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName)
			: base(i_LicenceNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName)
        {
            Engine = new FuelBasedEngine(0.0f, k_MaxAmountOfFuelForTruck, k_FuelTypeForTruck);
        }

		/*** Class Logic ***/

		public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.Append(Engine.ToString());

            return output.ToString();
        }
    }
}
