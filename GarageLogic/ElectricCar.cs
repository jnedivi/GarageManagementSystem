﻿using System;
using System.Text;

namespace GarageLogic
{
    public class ElectricCar : Car
    {

        /*** Data Members ***/
        const float k_MaxBatteryLifeCar = 2.5f;
        private readonly ElectricBasedEngine r_ElectricEngine;

        /*** Getters and Setters ***/
        public ElectricBasedEngine ElectricEngine
        {
            get { return this.r_ElectricEngine; }
        }

        /*** Class Logic ***/

        public ElectricCar()
        {
            r_ElectricEngine = new ElectricBasedEngine(0.0f, k_MaxBatteryLifeCar);
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
