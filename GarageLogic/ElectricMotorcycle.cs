﻿using System;
using System.Text;

namespace GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {

        /*** Data Members ***/
        private const float k_MaxBatteryLifeMotorcycle = 2.7f;
        private readonly ElectricBasedEngine r_ElectricEngine;

		/*** Getters and Setters ***/
        public ElectricBasedEngine ElectricEngine
        {
            get { return this.r_ElectricEngine; }
        }

        /*** Class Logic ***/

        public ElectricMotorcycle()
        {
            this.r_ElectricEngine = new ElectricBasedEngine(0.0f, k_MaxBatteryLifeMotorcycle);
        }
        
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append(base.ToString());
            output.Append(r_ElectricEngine.ToString());

            return output.ToString();
        }
    }
}
