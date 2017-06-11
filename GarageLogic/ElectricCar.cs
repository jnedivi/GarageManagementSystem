﻿using System;
using System.Text;

namespace GarageLogic
{
    public class ElectricCar : Car
    {

        /*** Data Members ***/
        const float k_MaxBatteryLifeCar = 2.5f;

        /*** Class Logic ***/

        public ElectricCar()
        {
            Engine = new ElectricBasedEngine(0.0f, k_MaxBatteryLifeCar);
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
