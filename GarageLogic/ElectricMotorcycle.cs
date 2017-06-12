﻿﻿using System;
using System.Text;
using System.Collections.Generic;

namespace GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {

        /*** Data Members ***/
        private const float k_MaxBatteryLifeMotorcycle = 2.7f;

        /*** Class Logic ***/
        public ElectricMotorcycle(string i_LicenceNumber, string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, List<Vehicle.Wheel> i_Wheels)
            : base(i_LicenceNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_Wheels)
        {
            Engine = new ElectricBasedEngine(0.0f, k_MaxBatteryLifeMotorcycle);
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
