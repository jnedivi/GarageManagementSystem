﻿using System;
namespace GarageLogic
{
    public class ElectricCar : Car
    {

		/*** Data Members ***/

        private ElectricBasedEngine m_ElectricEngine;

        /*** Getters and Setters ***/
        public ElectricBasedEngine ElectricEngine
        {
            get { return this.m_ElectricEngine; }
            set { this.m_ElectricEngine = value; }
        }

        /*** Class Logic ***/

        //4 tires with max air pressure of 30 (psi), Max battery life – 2.5 hours

        public ElectricCar()
        {
            this.ElectricEngine.MaxBatteryLife = 2.7f;
        }
    }
}
