﻿﻿using System;
using System.Collections.Generic;

namespace GarageLogic
{

    public abstract class Vehicle
    {
        /*** Constants ***/
        private const string k_LicenseNumber = "License Number:";
        private const string k_ModelName = "Model Name:";
        private const string k_Owner = "Owner:";
        private const string k_VehicleStatus = "Vehicle Status:";
		/*** Data Members ***/

		private string m_ModelName;
        private string m_LicenseNumber;
        private string m_OwnerName;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Tires;
        private int m_NumberOfWheels;
        private eVehicleStatus m_VehicleStatus;
        internal Dictionary<string, string> m_VehicleInformation;

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            PayedFor
        }

        public virtual void CreateVehicleInformation()
        {
            m_VehicleInformation.Add(k_Owner, null);
            m_VehicleInformation.Add(k_ModelName, null);
            m_VehicleInformation.Add(k_LicenseNumber, null);
            m_VehicleInformation.Add(k_VehicleStatus, null);
        }

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

        public string OwnerName
        {
            get { return this.m_OwnerName; }
            set { this.m_OwnerName = value; }
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

        public List<Wheel> Tires
        {
            get { return this.m_Tires; }
            protected set { this.m_Tires = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return this.m_VehicleStatus; }
            set { this.m_VehicleStatus = value; }
        }

		/*** Class Logic ***/

		/*** Nested Class ***/
		private class Wheel
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
                if ((this.m_CurrentAirPressure + i_AirToAdd > this.m_MaxAirPressure) || i_AirToAdd < 0)
                {
                    throw new ValueOutOfRangeException("Tire", 0f, this.m_MaxAirPressure - this.m_CurrentAirPressure);
                }
                else
                {
                    this.m_CurrentAirPressure += i_AirToAdd;
                }
            }
        }

        public void CreateTires(int i_NumOfWheels, Wheel i_Tire)
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
