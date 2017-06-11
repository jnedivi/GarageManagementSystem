﻿using System;
using System.Text;

namespace GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {

        /*** Data Members ***/
        private const float k_MaxBatteryLifeMotorcycle = 2.7f;

        /*** Class Logic ***/

        public ElectricMotorcycle()
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
