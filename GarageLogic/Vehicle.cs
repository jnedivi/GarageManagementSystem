﻿﻿using System;
using System.Collections.Generic;

namespace GarageLogic
{

    public abstract class Vehicle
    {
        /*** Data Members ***/

        private const string k_LicenseNumber = "License Number:";
        private const string k_ModelName = "Model Name:";
        private const string k_Owner = "Owner:";
        private const string k_VehicleStatus = "Vehicle Status:";
        private const byte k_LegalLicenseNumberLength = 7;
        private const byte k_MinPhoneNumLength = 6;
        private const byte k_MaxPhoneNumLength = 9;

        private string m_ModelName;
        private string m_LicenseNumber;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
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
            set
            {
                this.m_LicenseNumber = value;
            }
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





            /*** Getters and Setters ***/

            public string ManufacturerName
            {
                get { return this.m_ManufacturerName; }
                set { this.m_ManufacturerName = value; }
            }

            public float CurrentAirPressure
            {
                get { return this.m_CurrentAirPressure; }
                set
                {
                    if (value < 0 || value > MaxAirPressure)
                    {
                        throw new ValueOutOfRangeException("Current Air Pressure", 0f, MaxAirPressure);
                    }

                    try
                    {
                        this.m_CurrentAirPressure = value;
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Current Air Pressure");
                    }
                }
            }

            public float MaxAirPressure
            {
                get { return this.m_MaxAirPressure; }
                internal set { this.m_MaxAirPressure = value; }
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

            internal static Wheel CreateNewWheel(float i_MaxAirPressure)
            {
                Wheel wheel = new Wheel();
                wheel.ManufacturerName = null;
                wheel.MaxAirPressure = i_MaxAirPressure;
                wheel.CurrentAirPressure = 0.0f;

                return wheel;
            }
        }

        public List<Wheel> CreateWheels(int i_NumOfWheels, float i_MaxAirPressure)
        {
            List<Wheel> newWheels = new List<Wheel>();
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel tire = Wheel.CreateNewWheel(i_MaxAirPressure);
                newWheels.Add(tire);
            }

            return newWheels;
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel tire in m_Wheels)
            {
                tire.InflateAction(tire.MaxAirPressure - tire.CurrentAirPressure);
            }
        }
    }
}

