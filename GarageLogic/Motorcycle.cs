﻿using System;
using System.Text;

namespace GarageLogic
{

    public abstract class Motorcycle : Vehicle
    {
        /*** Data Members ***/
        private const float k_MaxAirPressureForMotorcycle = 33.0f;
        private const int k_NumberOfWheelsForMotorcycle = 2;

        private float m_EngineVolume;
        private eLicenseType m_LicenceType;
        


        /*** Getters and Setters***/
        public eLicenseType LicenceType
        {
            get { return this.m_LicenceType; }
            set { this.m_LicenceType = value; }
        }

        public float EngineVolume
        {
            get { return this.m_EngineVolume; }
            set { this.m_EngineVolume = value; }
        }


        public enum eLicenseType
        {
            A,
            AB,
            A2,
            B1,
        };

        public Motorcycle()
        {
            this.Wheels = CreateWheels(k_NumberOfWheelsForMotorcycle, k_MaxAirPressureForMotorcycle);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            string motorcycleOutput = string.Format(@"License Type: {0}
Engine Volume: {1}", m_LicenceType, m_EngineVolume);

            output.Append(base.ToString());
            output.Append(motorcycleOutput);

            return output.ToString();
        }
    }
}
