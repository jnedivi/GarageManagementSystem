﻿using System;
namespace GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
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

        //2 tires with max air pressure of 33 (psi), Max battery life – 2.7 hours

        public ElectricMotorcycle()
        {
            this.ElectricEngine.MaxTimeOfOperation = 2.7f;
        }
    }
}
