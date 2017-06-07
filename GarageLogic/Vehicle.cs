﻿using System;
using System.Collections.Generic;

namespace GarageLogic
{

    public abstract class Vehicle
    {

		/*** Data Members ***/

		private string m_ModelName;
        private string m_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private Wheel m_Wheel;
        private List<Wheel> m_Tires;
        private byte m_NumberOfWheels;

		/*** Getters and Setters ***/

		public string ModelName
		{
			get { return this.m_ModelName; }
			set { this.m_ModelName = value; }
		}
		public string LicenseNumber
		{
			get { return this.m_LicenseNumber; }
			set { this.m_LicenseNumber = value; }
		}
		public float RemainingEnergyPercentage
		{
			get { return this.m_RemainingEnergyPercentage; }
			set { this.m_RemainingEnergyPercentage = value; }
		}
        public byte NumberOfWheels
        {
            get { return this.m_NumberOfWheels; }
            set { this.m_NumberOfWheels = value; }
        } 
		public Wheel VehicleWheel
		{
			get { return this.m_Wheel; }
			set { this.m_Wheel = value; }
		}
        public List<Wheel> Tires
        {
            get { return this.m_Tires; }
            set { this.m_Tires = value; }
        }

		/*** Class Logic ***/

		/*** Nested Class ***/
		public class Wheel
        {

			/*** Data Members ***/

			private string m_ManufacturerName;
            private float m_CurrentAirPressure;
            private float m_ReccomendedAirPressure;

			/*** Getters and Setters ***/

			public string ManufacturerName
			{
				get { return this.m_ManufacturerName; }
				set { this.m_ManufacturerName = value; }
			}
			public float CurrentAirPressure
			{
				get { return this.m_CurrentAirPressure; }
				set { this.m_CurrentAirPressure = value; }
			}
			public float MaxAirPressure
			{
				get { return this.m_ReccomendedAirPressure; }
				set { this.m_ReccomendedAirPressure = value; }
			}


			/*** Class Logic ***/

			public void inflateAction(float i_AirToAdd)
            {
                if (this.m_CurrentAirPressure + i_AirToAdd <= this.m_ReccomendedAirPressure)
                {
                    this.m_CurrentAirPressure += i_AirToAdd;
                }
            }
        }
    }
}
