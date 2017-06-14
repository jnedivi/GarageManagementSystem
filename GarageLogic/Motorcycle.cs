﻿﻿using System;
using System.Text;
using System.Collections.Generic;

namespace GarageLogic
{

    public abstract class Motorcycle : Vehicle
    {
        /*** Data Members ***/

        private const float k_MaxAirPressureForMotorcycle = 33.0f;
        private const byte k_NumberOfWheelsForMotorcycle = 2;
        private const string k_LicenseType = "License Type";
        private float m_EngineVolume;
        private eLicenseType m_LicenceType;

        /*** Getters and Setters***/

        public String LicenceType
        {
            get { return this.m_LicenceType.ToString(); }
            set
            {
                if (!Enum.IsDefined(typeof(eLicenseType), value))
                {
                    throw new FormatException(k_LicenseType);
                }

                try
                {
                    m_LicenceType = (eLicenseType)Enum.Parse(typeof(eLicenseType), value);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException(k_LicenseType);
                }
            }
        }

        public string EngineVolume
        {
            get { return this.m_EngineVolume.ToString(); }
            set
            {
                try
                {
                    m_EngineVolume = float.Parse(value);
                }
                catch (FormatException)
                {
                    throw new FormatException("Engine Volume");
                }
            }
        }

		/*** Constructor ***/

		protected Motorcycle(string i_LicenceNumber, string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName)
            : base(i_LicenceNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName , k_NumberOfWheelsForMotorcycle , k_MaxAirPressureForMotorcycle)
		{
			LicenceType = eLicenseType.A.ToString();
			EngineVolume = 0f.ToString();
		}

		/*** Class Logic ***/

		public enum eLicenseType
        {
            A,
            AB,
            A2,
            B1,
        };

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            string motorcycleOutput = string.Format(@"Motorcycle Information:
License Type: {0}
Engine Volume: {1}
", m_LicenceType, m_EngineVolume);

            output.Append(base.ToString());
            output.Append(Environment.NewLine);
            output.Append(motorcycleOutput);
            output.Append(Environment.NewLine);
            output.Append(Environment.NewLine);

            return output.ToString();
        }
    }
}
