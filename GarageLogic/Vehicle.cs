﻿﻿using System;
using System.Collections.Generic;

namespace GarageLogic
{

    public abstract class Vehicle
    {

		/*** Data Members ***/

		private string m_ModelName;
        private string m_LicenseNumber;
        private string m_OwnerName;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Tires;
        //private Wheel m_Wheel;
        private byte m_NumberOfWheels;
        private eVehicleStatus m_VehicleStatus;

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            PayedFor
        }

        public virtual Dictionary<>

        /*protected Vehicle()
        {
            m_ModelName = string.Empty;
            m_LicenseNumber = string.Empty;
            m_RemainingEnergyPercentage = 0.0f;
            m_RemainingEnergyPercentage = 0.0f;
        }*/

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

		/*public Wheel Tire
		{
			get { return this.m_Wheel; }
			set { this.m_Wheel = value; }
		}*/

        public List<Wheel> Tires
        {
            get { return this.m_Tires; }
            set { this.m_Tires = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return this.m_VehicleStatus; }
            set { this.m_VehicleStatus = value; }
        }

		/*** Class Logic ***/

		/*** Nested Class ***/
		class Wheel
        {

			/*** Data Members ***/

			private string m_ManufacturerName;
            private float m_CurrentAirPressure;
            private float m_MaxAirPressure;
            
            public Wheel()
            {
                m_ManufacturerName = string.Empty;
                m_CurrentAirPressure = 0.0f;
                MaxAirPressure = 0.0f;
            }

			/*** Getters and Setters ***/

			public string ManufacturerName
			{
				get { return this.m_ManufacturerName; }
				set { this.m_ManufacturerName = value; }
			}
			public float CurrentAirPressure
			{
				get { return this.m_CurrentAirPressure; }
				set {
                    float airPressureValue;
                    try
                    {
                        this.m_CurrentAirPressure = value;
                    }
                    
                }
			}
			public float MaxAirPressure
			{
				get { return this.m_MaxAirPressure; }
				set { this.m_MaxAirPressure = value; }
			}


            /*** Class Logic ***/

            public void InflateAction(float i_AirToAdd)
            {
                if (this.m_CurrentAirPressure + i_AirToAdd <= this.m_MaxAirPressure)
                {
                    this.m_CurrentAirPressure += i_AirToAdd;
                }
            }
        }

        public void CreateTires(byte i_NumOfWheels, Wheel i_Tire)
        {

            for (int i = 0; i < this.NumberOfWheels; i++)
            {
                Wheel tire = i_Tire;
                Tires.Add(tire);
            }
        }
        private makeSingleWheel
    }
}
