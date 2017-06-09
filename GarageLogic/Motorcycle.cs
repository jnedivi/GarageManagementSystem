﻿using System;
namespace GarageLogic
{

    public abstract class Motorcycle : Vehicle
    {
        /*** Data Members ***/
        private float m_EngineVolume;
        private eLicenseType m_LicenceType;
        



        public Motorcycle()
        {
            this.NumberOfWheels = 2;
            this.Tire.MaxAirPressure = 33f;
            this.CreateTires(NumberOfWheels, Tire);
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
