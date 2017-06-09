﻿using System;
namespace GarageLogic
{

    public abstract class Motorcycle : Vehicle
    {
        /*** Data Members ***/
        private const float k_MaxAirPressureForMotorcycle = 33.0f;
        private const int k_NumberOfWheelsForMotorcycle = 2;

        private float m_EngineVolume;
        private eLicenseType m_LicenceType;
        



        public Motorcycle()
        {
            this.Wheels = CreateWheels(k_NumberOfWheelsForMotorcycle, k_MaxAirPressureForMotorcycle);
        }

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
    }
}
