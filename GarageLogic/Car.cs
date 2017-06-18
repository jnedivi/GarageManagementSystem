﻿﻿using System;
using System.Text;
using System.Collections.Generic;

namespace GarageLogic
{

	public abstract class Car : Vehicle
	{

        /*** Data Members ***/

        private const float k_MaxAirPressureCar = 30.0f; 
        private const byte k_NumberOfWheelsForCar = 4;
       
        private const string k_Color = "Color";
        private const string k_NumberOfDoors = "NumberOfDoors";
		private eColor m_Color;
        private eNumOfDoors m_NumberOfDoors;
       
        
        /*** Getters and Setters***/

        public eColor Color
        {
            get { return this.m_Color; }
            set { this.m_Color = value; }
        }

        public eNumOfDoors NumberOfDoors
		{
			get { return this.m_NumberOfDoors; }
			set { this.m_NumberOfDoors = value; }
		}

		/*** Constructor ***/


		protected Car(string i_LicenceNumber, string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName)
            : base(i_LicenceNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName , k_NumberOfWheelsForCar , k_MaxAirPressureCar)
		{

		}

        /*** Class Logic ***/

        public void SetCarDoorsAndColor(Car.eColor i_Color, Car.eNumOfDoors i_NumOfDoors)
        {
            m_Color = i_Color;
            m_NumberOfDoors = i_NumOfDoors;
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
			Two, 
			Three,
			Four,
			Five,
		}

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            string carOutput = string.Format(@"Car Information:
Color: {0}
Number Of Doors: {1}
", m_Color, m_NumberOfDoors);

            output.Append(base.ToString());
            output.Append(carOutput);
            output.Append(Environment.NewLine);

            return output.ToString();
        }
    }
}
