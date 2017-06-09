﻿﻿using System;
using System.Collections.Generic;

namespace GarageLogic
{

    public abstract class Vehicle
    {
        /*** Constants ***/
        
		/*** Data Members ***/

		private string m_ModelName;
        private string m_LicenseNumber;
        private string m_OwnerName;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
        //private int m_NumberOfWheels;
        private eVehicleStatus m_VehicleStatus;
        

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            PayedFor
        }

        public virtual Dictionary<string, string> CreateVehicleInformation()
        {
            Dictionary<string, string> vehicleInformation = new Dictionary<string, string>();
            vehicleInformation.Add("Owner Name", m_OwnerName);
            vehicleInformation.Add("Model Name", m_ModelName);
            vehicleInformation.Add("License Number", m_LicenseNumber);
            vehicleInformation.Add("Vehicle Status", m_VehicleStatus.ToString());

            return vehicleInformation;
        }

        protected Vehicle()
        {
            m_ModelName = string.Empty;
            m_LicenseNumber = string.Empty;
            m_RemainingEnergyPercentage = 0.0f;
            m_RemainingEnergyPercentage = 0.0f;
        }

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

        /*public int NumberOfWheels
        {
            get { return this.m_NumberOfWheels; }
            set { this.m_NumberOfWheels = value; }
        }*/

        public List<Wheel> Wheels
        {
            get { return this.m_Wheels; }
            set { this.m_Wheels = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return this.m_VehicleStatus; }
            set { this.m_VehicleStatus = value; }
        }

		/*** Class Logic ***/

		/*** Nested Class ***/
		public class Wheel
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
				set { this.m_CurrentAirPressure = value; } 
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

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel tire = i_Tire;
                Wheels.Add(tire);
            }
        }

        public void InflateAllTiresToMax()
        {
            foreach(Wheel tire in m_Wheels)
            {
                tire.InflateAction(tire.MaxAirPressure - tire.CurrentAirPressure);
            }
        }
    }
}
