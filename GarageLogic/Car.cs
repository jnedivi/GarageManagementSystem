﻿using System;
using System.Text;
using System.Collections.Generic;

namespace GarageLogic
{

	public abstract class Car : Vehicle
	{

        /*** Data Members ***/

        private const float k_MaxAirPressureCar = 30.0f; 
        private const int k_NumberOfWheelsForCar = 4;
        private const string k_Color = "Color";
        private const string k_NumberOfDoors = "NumberOfDoors";
		private eColor m_Color;
        private eNumOfDoors m_NumberOfDoors;
        
        /*** Getters and Setters***/

        public String Color
        {
            get { return this.m_Color.ToString(); }
            set
            {
                if(!Enum.IsDefined(typeof(eColor), value))
                {
                    throw new FormatException(k_Color);
                }

                try
                {
                    m_Color = (eColor)Enum.Parse(typeof(eColor), value);
                }
                catch(ArgumentException)
                {
                    throw new ArgumentException(k_Color);
                }                   
            }
        }

		public String NumberOfDoors
		{
			get { return this.m_NumberOfDoors.ToString(); }
			set
            {
                if (!Enum.IsDefined(typeof(eNumOfDoors), value))
                {
                    throw new FormatException(k_NumberOfDoors);
                }

                try
                {
                    m_NumberOfDoors = (eNumOfDoors)Enum.Parse(typeof(eNumOfDoors), value);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException(k_NumberOfDoors);
                }
            }
		}

        public enum eColor
		{
			Yellow,
			White,
			Black,
			Blue,
		}

		public enum eNumOfDoors
		{
			Two = 2, // ?
			Three,
			Four,
			Five,
		}

		protected Car(string i_LicenceNumber, string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, List<Vehicle.Wheel> i_Wheels)
			: base(i_LicenceNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_Wheels)
        {
            Color = eColor.Black.ToString();
            NumberOfDoors = eNumOfDoors.Two.ToString();
            this.Wheels = CreateWheels(k_NumberOfWheelsForCar, k_MaxAirPressureCar);

        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            string carOutput = string.Format(@"Color: {0}
Number Of Doors: {1}", m_Color, m_NumberOfDoors);

            output.Append(base.ToString());
            output.Append(carOutput);
            output.Append(Environment.NewLine);

            return output.ToString();
        }
    }
}
