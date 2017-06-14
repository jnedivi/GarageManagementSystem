﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{

    public abstract class Vehicle
    {
        /*** Constants ***/

        
		/*** Data Members ***/

        private const string k_LicenseNumber = "License Number:";
        private const string k_ModelName = "Model Name:";
        private const string k_Owner = "Owner:";
        private const string k_VehicleStatus = "Vehicle Status:";
        private const string k_OwnerPhoneNumber = "Owner Phone Number";
        /*** Data Members ***/

        //private const string k_OwnerPhoneNumber = "Owner Phone Number";
        // private const string k_LicenseNumber = "License Number";
        //private const string k_VehicleStatus = "Vehicle Status";

        private const byte k_LegalLicenseNumberLength = 7;
        private const byte k_MinPhoneNumLength = 6;
        private const byte k_MaxPhoneNumLength = 9;
        private readonly byte r_NumberOfWheels;
        private readonly float r_MaxWheelAirPressure;
       
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private string m_ModelName;
        private string m_LicenseNumber;
        
        private List<Wheel> m_Wheels;
        private eVehicleStatus m_VehicleStatus;
        private Engine m_Engine;


		protected Vehicle(string i_LicenceNumber, string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, byte i_NumberOfWheels, float i_MaxAirPressure)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenceNumber;
            m_VehicleStatus = eVehicleStatus.InRepair;
            r_NumberOfWheels = i_NumberOfWheels;
            r_MaxWheelAirPressure = i_MaxAirPressure;

        }


        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            PayedFor
        }

        private static bool isLegalLicenseNumber(string i_LicenseNumber)
        {
            bool isLegal = false;

            if (i_LicenseNumber.Length == k_LegalLicenseNumberLength)
            {
                isLegal = true;

                foreach(char character in i_LicenseNumber)
                {
                    isLegal = isLegal && char.IsDigit(character);
                }

                if (!isLegal)
                {
                    throw new System.ArgumentException(k_LicenseNumber);
                }
            }

            return isLegal;
        }

        private static bool isLegalPhoneNumber(string i_PhoneNumber)
        {
            bool isLegal = false;

            if(!((i_PhoneNumber.Length >= k_MinPhoneNumLength) && (i_PhoneNumber.Length <= k_MaxPhoneNumLength)))
            {
                throw new ValueOutOfRangeException(k_OwnerPhoneNumber, k_MinPhoneNumLength, k_MaxPhoneNumLength);
            }
            else
            {
                isLegal = true;

                foreach(char digit in i_PhoneNumber)
                {
                    isLegal = isLegal && char.IsDigit(digit);
                }

                if (!isLegal)
                {
                    throw new System.ArgumentException(k_OwnerPhoneNumber);
                }
            }

            return isLegal;
        }

        /*** Getters and Setters ***/

        public string ModelName
        {
            get { return this.m_ModelName; }
            set { this.m_ModelName = value; }
        }

        public float MaxAirPressure
        {
            get { return this.r_MaxWheelAirPressure; }
        }

        public string LicenseNumber
        {
            get { return this.m_LicenseNumber; }
            set
            {
                bool isLegal = isLegalLicenseNumber(value);

                if (!isLegal)
                {
                    throw new System.ArgumentException("License Number");
                }

                this.m_LicenseNumber = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get { return this.m_OwnerPhoneNumber; }
            set
            {
                bool isLegal = isLegalPhoneNumber(value);

                if (!isLegal)
                {
                    throw new System.ArgumentException(k_OwnerPhoneNumber);
                }

                this.m_OwnerPhoneNumber = value;
            }
        }

        public string OwnerName
        {
            get { return this.m_OwnerName; }
            set { this.m_OwnerName = value; }
        }

        public List<Wheel> Wheels
        {
            get { return this.m_Wheels; }
            set { this.m_Wheels = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return this.m_VehicleStatus; }
            set
            {
                if (!Enum.IsDefined(typeof(eVehicleStatus), value))
                {
                    throw new FormatException(k_VehicleStatus);
                }

                m_VehicleStatus = value;
            }
        }

        public Engine Engine
        {
            get { return this.m_Engine; }
            protected set { this.m_Engine = value; }
        }

        public byte NumberOfWheels
        {
            get
            {
                return this.r_NumberOfWheels;  
            }


        }
            

        /*** Class Logic ***/


        /*** Nested Class ***/
        public class Wheel
        {

            /*** Data Members ***/

            private string m_ManufacturerName;
            private float m_CurrentAirPressure;
            private float m_MaxAirPressure;


            public Wheel(string i_ManufacturerName, float i_currentAirPressure, float i_MaxAirPressure)
            {
				this.ManufacturerName = i_ManufacturerName;
				this.MaxAirPressure = i_MaxAirPressure;
				this.CurrentAirPressure = i_currentAirPressure;
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

            public override string ToString()
            {
                string output = string.Format(@"Manufacturer Name: {0}
Current Air Pressure: {1}
Maximum Air Pressure: {2}", m_ManufacturerName, m_CurrentAirPressure, m_MaxAirPressure);

                return output;
            }
        }

		public enum eTireAirPressureStatus
		{
			Yes,
			No
		}


        
        public void UpdateWheelsManufacturerName(string i_ManufacturerName)
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
            }
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateAction(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            string vehicleOutput = string.Format(@"General Vehicle Information:
Owner Name: {0}
Phone Number: {1}
Model Name: {2}
License Number: {3}
Vehicle Status: {4}

Wheels Information:", m_OwnerName, m_OwnerPhoneNumber ,m_ModelName, m_LicenseNumber, m_VehicleStatus);

            output.Append(vehicleOutput);
            output.Append(Environment.NewLine);

            int wheelIndex = 1;
            foreach(Wheel wheel in Wheels)
            {
                string wheelOutput = string.Format(@"Wheel {0}: 
{1}
", wheelIndex, wheel.ToString());
                output.Append(wheelOutput);
                output.Append(Environment.NewLine);
                wheelIndex++;
            }

            return output.ToString();
        }
    }
}

